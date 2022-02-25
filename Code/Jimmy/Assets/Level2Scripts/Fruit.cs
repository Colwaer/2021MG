using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    bool picked = false;

    string originTag = "OriginPlate";
    public string targetTag = "TargetPlate";

    Transform originParent;

    Collider2D collision;
    bool enter = false;
    private void Awake()
    {
        originParent = transform.parent;
    }

    private void Update()
    {
        if (enter)
        {
            if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && !picked)
            {
                Debug.Log("Picked");
                picked = true;
                transform.SetParent(collision.transform);
            
            }
            else if (collision.CompareTag(originTag) && Input.GetKeyDown(KeyCode.E) && picked)
            {
                Debug.Log("place back");
                picked = false;
                transform.SetParent(originParent);
            }
            else if (collision.CompareTag(targetTag) && Input.GetKeyDown(KeyCode.E) && picked)
            {
                picked = false;
                transform.SetParent(collision.transform);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("enter");
        enter = true;
        this.collision = collision;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enter = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        
    }


}
