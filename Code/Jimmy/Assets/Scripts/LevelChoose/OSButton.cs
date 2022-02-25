using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSButton : MonoBehaviour
{
    protected Camera mainCamera;
    protected LayerMask dragLayer;
    protected Vector3 rawScale;

    //OSButton只有鼠标扫过放大的功能

    protected virtual void Awake()
    {
        mainCamera = Camera.main;
        dragLayer += LayerMask.GetMask("SceneDraggabble");
        rawScale = transform.localScale;
    }

    protected virtual void Update()
    {
        AdjustScale();
    }
    
    protected void AdjustScale()
    {
        RaycastHit2D[] hitRes = Physics2D.CircleCastAll(mainCamera.ScreenToWorldPoint(Input.mousePosition), 
            0.01f, Vector2.zero, 200 , dragLayer);

        foreach(var obj in hitRes)
        {
            if(obj.collider.gameObject == this.gameObject)
            {
                this.transform.localScale = rawScale * 1.1f;
                return;
            }
        }

        this.transform.localScale = rawScale;
    }
}
