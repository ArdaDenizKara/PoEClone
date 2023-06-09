using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    private Enemy enemy;
    [SerializeField] private Transform player;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private int attackRange;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField]private  bool isAttacking;
    private bool canAttack = true;
    private float attackCooldown = 3f;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        enemyAnimator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        attackRange = GetComponent<Enemy>().attackRange;
    }
    private void Update()
    {
        gameObject.transform.rotation = Quaternion.identity;
        bool isPlayerCloseEnough = Vector3.Distance(transform.position, player.position) < attackRange;
        if (isPlayerCloseEnough)
        {
            StopMoving();
            if (!isAttacking&& canAttack)
            {
                Attack();
            }
        }
        else
        {
            if (!isAttacking)
            {
                MoveToPlayer();    
            }
        }
    }
    void MoveToPlayer()
    {
        enemyAnimator.SetBool("Idle",false);
        enemyAnimator.SetBool("Walk",true);
        navMeshAgent.SetDestination(player.position);
    }
    void Attack()
    {
        float attackDelay = 3f;
        enemyAnimator.SetBool("Idle",false);
        enemyAnimator.SetTrigger("Attack");
        StartCoroutine(ResumeMovementAfterDelay(attackDelay));
        StartCoroutine(AttackCooldown(attackCooldown));
    }
    IEnumerator ResumeMovementAfterDelay(float delay)
    {
        player.GetComponent<PlayerStats>().TakeDamage(enemy.enemyDamage);
        yield return new WaitForSeconds(delay);
        navMeshAgent.isStopped = false;
        isAttacking = false;
    }

    void StopMoving()
    {
        navMeshAgent.isStopped = true;
        enemyAnimator.SetBool("Walk",false);
    }
    IEnumerator AttackCooldown(float cooldown)
    {
        canAttack = false;
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }
    
}
