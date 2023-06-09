using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookAt : MonoBehaviour
{
    [SerializeField] private GameObject player;
    

    private void Start()
    {
        player= GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        Vector3 scale = transform.localScale;
        if (player.transform.position.x>transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1;
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
    /*//TODO(ARDADK): SPRITE 2D OLGUDU İÇİN İSTENİLEN GİBİ ÇALIŞMIYOR İLERDE TEKRAR BAKILMALI
    [SerializeField] Transform target;
    [SerializeField] GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.GetComponent<Transform>();
    }
    void Update()
    {
        transform.LookAt(target);
    }*/
}
