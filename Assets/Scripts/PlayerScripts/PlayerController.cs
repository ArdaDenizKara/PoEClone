using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    public float moveSpeed = 5f;
    public float runThreshold = 0.1f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector2 movement;
    [SerializeField]
    private Animator animator;
    private bool isRunning;
    private bool isAttacking;
    [SerializeField] public Transform attackPoint;
    public LayerMask enemyLayers;
    public Vector2 attackSize = new Vector2(1, 1);
    public Enemy enemyScript;
    public float hitDelay = 1f;
    private float hitDelayTimer = 0f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        isRunning = false;
        isAttacking = false;
    }
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        isRunning = movement.magnitude > runThreshold;
        
        if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
            attackPoint.localPosition = new Vector2(-attackPoint.localPosition.x, attackPoint.localPosition.y);
        }
        else if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
            attackPoint.localPosition = new Vector2(Mathf.Abs(attackPoint.localPosition.x), attackPoint.localPosition.y);
        }
        if (Input.GetMouseButtonDown(0)&& hitDelayTimer <= 0f)
        {
                isAttacking = true;
                animator.SetBool("isAttacking", true);
                Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position, attackSize, 0, enemyLayers);
                foreach (Collider2D enemy in hitEnemies)
                {
                    enemy.GetComponent<Enemy>().TakeDamage(playerStats.currentAttackDamage);
                }
            hitDelayTimer = hitDelay;
        }
        else
        {
            isAttacking = false;
            animator.SetBool("isAttacking", false);
        }
        if (hitDelayTimer > 0f)
        {
            hitDelayTimer -= Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        animator.SetBool("isRunning", isRunning);
    }
}
