using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs = new List<GameObject>();
    [SerializeField] private List<GameObject> cloneEnemies = new List<GameObject>();
    private void Start()
    {
        SpawnEnemy();
    }
    public void SpawnEnemy()
    {
        foreach (GameObject enemyprefab in enemyPrefabs)
        {
            var createdEnemy = GameObject.Instantiate(enemyprefab, new Vector3(-7, 0, 0), Quaternion.identity);
            cloneEnemies.Add(createdEnemy);
        }
    }
}
