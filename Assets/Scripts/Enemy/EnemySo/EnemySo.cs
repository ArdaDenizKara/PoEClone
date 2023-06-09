using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class EnemySo : ScriptableObject
{
    public string Enemyname;
    public int enemyHealth;
    public int enemyDamage;
    public int enemyArmor;
    public List<string> enemySkills;
    public int attackRange;
    public float speed;
}
