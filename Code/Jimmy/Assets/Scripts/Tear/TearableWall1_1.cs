using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearableWall1_1 : MonoBehaviour
{
    public TearObj tearObj;

    bool check = false;

    private void Update()
    {
        if (check)
        {
            if (Input.GetKeyDown(KeyCode.E) && tearObj.TearDown)
            {
                GameManager1_1.Instance.OnPlayerEnter();
                Destroy(this);
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            check = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            check = false;
        }
    }

}
