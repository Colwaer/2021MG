using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondFloorTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager1_3.Instance.OnEnterSecondFloor();
            Destroy(this.gameObject);
        }
    }
}
