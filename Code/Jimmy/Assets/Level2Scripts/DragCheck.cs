using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCheck : MonoBehaviour
{
    public SceneDrag2_1 sceneDrag;





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            sceneDrag.enableDrag = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            sceneDrag.enableDrag = true;
    }

}
