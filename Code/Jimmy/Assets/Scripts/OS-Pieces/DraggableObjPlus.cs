using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObjPlus : DraggableObj
{
    public delegate void PlacedDelegate();// 吸附成功后触发的委托

    public float dragVelocity;//鼠标拖拽的速度 

    private Vector2 lastFramePos , curFramePos;

    [Header("矩形对角的两个顶点，物体只能在这个矩形内移动")]
    public Transform pointTrans1;
    public Transform pointTrans2;
    private Vector2 point1 , point2;

    private float left , right , up , down;

    public bool limitDragArea;

    public bool Placed => m_currentAttachPoint != null && ! CorrectlyPlaced;//摆在非正确位置上

    protected override void Awake()
    {
        base.Awake();
        if (transform.childCount == 0)
            Debug.Log(gameObject.name);
        checkAttachPoint = transform.GetChild(0);
        limitDragArea = !(pointTrans1 == null && pointTrans2 == null);
        if (limitDragArea)
            GetEdgeLimit();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (limitDragArea)
        {
            GetEdgeLimit();
            LimitDragArea();
        }
        dragVelocity = CaculateDragVelocity();
        //Debug.Log(dragVelocity);
    }

    //获取边界值
    private void GetEdgeLimit()
    {
        point1 = pointTrans1.position;
        point2 = pointTrans2.position;

        if(point1.x < point2.x)
        {
            right = point2.x;
            left = point1.x;
        }
        else
        {
            right = point1.x;
            left = point2.x;
        }

        if(point1.y < point2.y)
        {
            up = point2.y;
            down = point1.y;
        }
        else
        {
            up = point1.y;
            down = point2.y;
        }
    }


    //被拖拽时，在FixedUpdate中的最后调用
    private void LimitDragArea()
    {
        if(transform.position.x > right)
            transform.position = new Vector2(right , transform.position.y);

        if(transform.position.x < left)
            transform.position = new Vector2(left , transform.position.y);

        if(transform.position.y > up)
            transform.position = new Vector2(transform.position.x , up);

        if(transform.position.y < down)
            transform.position = new Vector2(transform.position.x , down);
    }

    public override void OnMouseButtonDown()
    {
        base.OnMouseButtonDown();
        Debug.Log("receive mouse");

        lastFramePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        curFramePos = lastFramePos;
    }

    private float CaculateDragVelocity()
    {
        float velocity , distance;
        
        curFramePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        distance = Vector2.Distance(lastFramePos , curFramePos);
        velocity = distance / 0.02f;

        lastFramePos = curFramePos;

        return velocity;
    }


}
