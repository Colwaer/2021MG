using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetTheBird : MonoBehaviour
{
    public GameObject birdDia;
    public GameObject backgroundMove;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            birdDia.SetActive(true);
            backgroundMove.SetActive(false);
        }
    }
}
