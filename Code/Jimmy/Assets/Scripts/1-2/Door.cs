using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool TP;
    public GameObject smallRoom;
    private Animator anim;

    private void Awake() {
        anim = smallRoom .GetComponent<Animator>();
    }

    private void Update() {
        if(TP && Input.GetKeyDown(KeyCode.E))
        {
            if( anim.GetCurrentAnimatorStateInfo(0).IsName("fall"))
            {
                anim.Play("up");
            }
            else
            {
                anim.Play("fall");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            TP = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            TP = false;
        }
    }
}
