using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelArea : MonoBehaviour
{
    public GameObject curtain;
    private bool detect = false;
    private void Update()
    {
        if (detect)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                curtain.SetActive(true);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detect = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detect = false;
        }
    }


}
