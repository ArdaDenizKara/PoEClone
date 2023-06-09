using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public int maxHealth = 100;
    [SerializeField] public int currentHealth;
    [SerializeField] private int baseAttackDamage = 10;
    [SerializeField] public int currentAttackDamage;
    [SerializeField] public int maxMana = 100;
    [SerializeField] public int currentMana;
    [SerializeField] private int baseArmor = 0;
    [SerializeField] private int currentArmor;
    private int startExperience = 0;
    [SerializeField] public int currentExperience;
    private int startLevel = 1;
    [SerializeField] public int currentLevel;
    [SerializeField] public int neededExperince = 500;
    [SerializeField] public float attackRange = 0.5f;
    [SerializeField] public float currentAttackRange;
    



    private void Awake()
    {
        currentHealth = maxHealth;
        currentAttackDamage = baseAttackDamage;
        currentMana = maxMana;
        currentArmor = baseArmor;
        currentExperience = startExperience;
        currentLevel = startLevel;
        currentAttackRange = attackRange;
    }
    public void TakeDamage(int damageAmount)
    {
        int damageAfterArmor = damageAmount - currentArmor;
        currentHealth -= damageAfterArmor;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

    public void UseMana(int manaCost)
    {
        currentMana -= manaCost;

        if (currentMana < 0)
        {
            currentMana = 0;
        }
    }

    public void IncreaseArmor(int armorAmount)
    {
        currentArmor += armorAmount;
    }

    public void DecreaseArmor(int armorAmount)
    {
        currentArmor -= armorAmount;

        if (currentArmor < 0)
        {
            currentArmor = 0;
        }
    }

    public void IncreaseMaxHealth(int healthAmount)
    {
        maxHealth += healthAmount;
        currentHealth += healthAmount;
    }

    public void DecreaseMaxHealth(int healthAmount)
    {
        maxHealth -= healthAmount;

        if (maxHealth < 1)
        {
            maxHealth = 1;
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void IncreaseMaxMana(int manaAmount)
    {
        maxMana += manaAmount;
        currentMana += manaAmount;
    }

    public void DecreaseMaxMana(int manaAmount)
    {
        maxMana -= manaAmount;

        if (maxMana < 1)
        {
            maxMana = 1;
        }

        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }
    }

    public void IncreaseAttackDamage(int damageAmount)
    {
        currentAttackDamage += damageAmount;
    }

    public void DecreaseAttackDamage(int damageAmount)
    {
        currentAttackDamage -= damageAmount;

        if (currentAttackDamage < 1)
        {
            currentAttackDamage = 1;
        }
    }
    
}
