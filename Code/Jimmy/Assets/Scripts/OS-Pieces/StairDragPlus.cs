using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairDragPlus : DraggableObjPlus
{
    private Camera mainCamera;
    private Vector3 pos;

    private void Start() {
        mainCamera = Camera.main;
    }

    public override void OnMouseButtonUp()
    {
        base.OnMouseButtonUp();
        pos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if(Vector3.Distance(pos , attachPoints[0].position) > Vector3.Distance(pos , attachPoints[1].position))
            this.transform.position = attachPoints[1].position;
        else
            this.transform.position = attachPoints[0].position;
    }
}
