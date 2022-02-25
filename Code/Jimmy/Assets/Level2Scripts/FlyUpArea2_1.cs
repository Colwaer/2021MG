using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyUpArea2_1 : MonoBehaviour
{
    CPlayer player;

    public Animator animator;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CPlayer>();
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player.ReceiveInput)
            {
                player.ReceiveInput = false;
                player.FlyUp();

                animator.Play("Çý¸ÏÒ¹Ýº");
                
            }
                
        }
    }

}
