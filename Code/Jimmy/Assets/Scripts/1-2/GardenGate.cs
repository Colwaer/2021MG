using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenGate : MonoBehaviour
{
    private Animator anim;
    private bool unlock;
    public GameObject curtain , tip;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    private void Update() {
        if(unlock && Input.GetKeyDown(KeyCode.E))
        {
            anim.Play("open");
            Invoke("OpenCurtain" , 3f);
        }

        if(unlock && ! tip.activeSelf)
            tip.SetActive(true);
        else if( ! unlock)
            tip.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && GameManager1_2.instance.getKey &&
         !anim.GetCurrentAnimatorStateInfo(0).IsName("open"))
        {
            unlock = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            unlock = false;
        }
    }

    private void OpenCurtain()
    {
        curtain.SetActive(true);
    }

}
