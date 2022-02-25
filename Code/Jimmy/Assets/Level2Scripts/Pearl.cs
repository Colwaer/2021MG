using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pearl : MonoBehaviour
{
    public bool enter = false;
    CPlayer player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CPlayer>();
    }


    private void Update()
    {
        if (enter)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.GetPearl();


                Destroy(this.gameObject);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            enter = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            enter = false;
    }
}
