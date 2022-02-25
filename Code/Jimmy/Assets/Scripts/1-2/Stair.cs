using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : MonoBehaviour
{
    public GameObject tip;
    public Transform target;
    private bool TP;
    private GameObject player;
    private Camera mainCamera;

    private void Awake() {
        player = GameObject.FindWithTag("Player");
        mainCamera = Camera.main;
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

    private void Update() {
        if(TP && Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit2D[] hitRes = Physics2D.CircleCastAll(target.position , 3f , Vector2.zero, 200);

            foreach(var obj in hitRes)
            {
                Debug.Log(obj.collider.name);
                if(obj.collider.gameObject.GetComponent<PlayerAwayArea>() != null)
                {
                    tip.SetActive(true);
                    Invoke("CloseTip" , 2f);
                    return ;
                }
                    
            }

            player.transform.position = target.position;
        }
    }

    private void CloseTip()
    {
        tip.SetActive(false);
    }
}
