using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyUpArea : MonoBehaviour
{
    CPlayer player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CPlayer>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.EnterFlyUpArea();
        }
    }
}
