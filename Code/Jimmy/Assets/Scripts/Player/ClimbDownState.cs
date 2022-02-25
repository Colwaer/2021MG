using System.Collections;
using UnityEngine;

public class ClimbDownState : PlayerState
{
    private float m_AnimTime = 1.5f;
    private float m_AnimTimer = 1.5f;

    private Transform climbDownPoint;
    private Transform climbUpPoint;

    private int direction = 1;

    Vector2 startPos;
    Vector2 endPos;

    float upTime = 0.5f;
    float upStopTime = 1.1f;
    float rightTime = 0.7f;
    float endStopTime = 0.8f;

    bool up = false;
    bool upStop = false;
    bool right = false;
    bool endStop = false;

    float totalTime = 3.15f;
    float upDistance;
    float rightDistance;
    Vector2 downPos;
    Vector2 upPos;
    float timer;
    public override void Enter()
    {
        up = false;
        upStop = false;
        right = false;
        endStop = false;


        fsm.DeliverGravity(0);
        fsm.DeliverHorizontal(0);

        GetData();     // 得到方向信息
        SwitchAnim();

        downPos = (fsm.BlackBoard["ClimbDownPoint"] as Transform).position;
        upPos = (fsm.BlackBoard["ClimbUpPoint"] as Transform).position;

        upDistance = startPos.y - endPos.y;
        rightDistance = Mathf.Abs(endPos.x - startPos.x);

        timer = 0f;


        if (direction == 1)
            fsm.SetDirection(false);
        else
            fsm.SetDirection(true);
        startPos = fsm.transform.position;

        fsm.transform.position += (Vector3)(upPos - downPos + Vector2.down * 0.6f);
    }

    public override void Exit()
    {
        fsm.DeliverGravity(1f);
        fsm.DeliverHorizontal(0);

        if (direction == 1)
            fsm.SetDirection(false);
        else
            fsm.SetDirection(true);
    }

    protected override void HandleInput()
    {

    }
    public override void Update()
    {
        base.Update();

        timer += Time.deltaTime;

        if (timer >= totalTime)
        {
            //Debug.Log("changepos" + (endPos - startPos));
            

            fsm.SwitchState("IdleState");
        }


        //if (timer >= 0f && !endStop)
        //{
        //    endStop = true;
        //    fsm.Freeze(endStopTime);
        //}
        //else if (timer >= endStopTime && !right)
        //{
        //    right = true;
        //    float speed = rightDistance / rightTime * 1.1f;
        //    fsm.GoTo(Vector2.right * direction, speed, rightTime);
        //    Debug.Log("enter right speed : " + speed + " time : " + rightTime);

        //}
        //else if (timer >= endStopTime + rightTime && !upStop)
        //{
        //    upStop = true;
        //    fsm.Freeze(upStopTime);
        //}
        //else if (timer >= endStopTime + rightTime + upStopTime && !up)
        //{
        //    Debug.Log("Enter first goto");

        //    up = true;
        //    float speed = upDistance / upTime * 1.1f;

        //    fsm.GoTo(Vector2.down, speed, upTime);
        //}
        //else if (timer >= upTime + upStopTime + rightTime + endStopTime)
        //{
        //    fsm.SwitchState("IdleState");
        //}

    }

    protected override void SwitchAnim()
    {
        fsm.SwitchAnim("ClimbDown");
    }

    public void GetData()
    {
        bool rightSide = (bool)fsm.BlackBoard["RightSide"];
        if (rightSide)
            direction = 1;
        else
            direction = -1;

        climbUpPoint = fsm.BlackBoard["ClimbUpPoint"] as Transform;
    }
}