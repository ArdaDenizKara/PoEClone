using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthbar : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] private Image enemyHealthBar;

    private void Update()
    {
        enemyHealthBar.fillAmount = (float)enemy.currentEnemyHealth / (float)enemy.enemyHealth;
    }
}
