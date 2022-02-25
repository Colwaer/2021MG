using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Transform dropLightTrans;

    public KeyTargetOuter keyTargetOuter;
    private void OnEnable() {
        if(keyTargetOuter.OuterCheck())
        {
            transform.SetParent(dropLightTrans);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            GameManager1_2.instance.getKey = true;
        }
    }
}
