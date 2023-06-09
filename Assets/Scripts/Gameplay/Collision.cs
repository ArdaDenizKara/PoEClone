using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] private  PlayerStats playerStats;
    [SerializeField] private GameObject player;
    bool isPlayer;
    private void Start()
    {
        isPlayer = player;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="SpikeTrap")
        {
            if (isPlayer)
            {
                playerStats.currentHealth -= 5;
                Debug.Log("hit");
            }
            
        }
    }
}
