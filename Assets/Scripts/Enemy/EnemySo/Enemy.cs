using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemySo enemySo;
    [SerializeField] public int enemyHealth;
    [SerializeField] public int currentEnemyHealth;
    [SerializeField] private int enemyArmor;
    [SerializeField] public int enemyDamage;
    [SerializeField] public int attackRange;
    [SerializeField] private List<string> enemySkills;
    [SerializeField] private float enemySpeed;
    private void Start()
    {
        enemyHealth = enemySo.enemyHealth;
        currentEnemyHealth = enemyHealth;
        enemyArmor = enemySo.enemyArmor;
        enemyDamage = enemySo.enemyDamage;
        attackRange = enemySo.attackRange;
        enemySkills = enemySo.enemySkills;
        enemySpeed = enemySo.speed;
    }
    
    public void TakeDamage(int damageAmount)
    {
        currentEnemyHealth -= damageAmount;
        if (currentEnemyHealth <= 0)
        {
            Die();
        }
        Debug.Log(damageAmount);
    }
    public void Die()
    {
        Destroy( GameObject.FindGameObjectWithTag("Enemy"));
    }
}
