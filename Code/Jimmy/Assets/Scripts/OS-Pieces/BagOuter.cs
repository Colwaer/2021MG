using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagOuter : MonoBehaviour
{
    private Camera mainCamera;
    private LayerMask bagLayer;
    private Animator anim;

    private void Awake() {
        mainCamera = Camera.main;
        bagLayer = LayerMask.GetMask("Bag");
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(CheckMouseInBag())
        {
            anim.Play("Down");
        }
        else
        {
            anim.Play("Up");
        }

    }

    //检测鼠标是否在背包UI中
    public bool CheckMouseInBag()
    {
        RaycastHit2D[] hitRes = Physics2D.CircleCastAll(mainCamera.ScreenToWorldPoint(Input.mousePosition), 
            0.2f, Vector2.zero, 200 , bagLayer);

        foreach(var obj in hitRes)
            if(obj.collider.gameObject.layer == 10)//bag的layer
                return true;

        return false;
    }
}
