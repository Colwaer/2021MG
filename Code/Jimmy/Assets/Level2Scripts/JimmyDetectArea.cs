using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JimmyDetectArea : MonoBehaviour
{
    public GameObject airWall;

    CPlayer player;
    public GameObject dialogue;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CPlayer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.CompareTag("Player"))
            {
                if (player.HasPearl)
                {
                    dialogue.SetActive(true);

                    player.PlayReturnPearlAnim();
                    

                    player.enabled = false;

                    Destroy(airWall.gameObject);
                    Destroy(this);
                }
                else
                {

                }
            }


        }
    }
}
