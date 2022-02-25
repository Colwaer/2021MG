using System.Collections;
using UnityEngine;

public class ClimbUpState : PlayerState
{


    private LayerMask ignorePlayer = LayerMask.GetMask("Platform");

    private int direction = 1;

    private Transform climbDownPoint;
    private Transform climbUpPoint;

    Vector2 downPos;
    Vector2 upPos;

    float upTime = 0.5f;
    float upStopTime = 1.1f;
    float rightTime = 0.7f;
    float endStopTime = 0.8f;

    float totalTime = 3.15f;

    bool up = false;
    bool upStop = false;
    bool right = false;
    bool endStop = false;


    float upDistance;
    float rightDistance;

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

        //upDistance = startPos.y - endPos.y;
        //rightDistance = Mathf.Abs(endPos.x - startPos.x);

        timer = 0f;
        fsm.Freeze(totalTime - 0.3f);

        if (direction == 1)
            fsm.SetDirection(true);
        else
            fsm.SetDirection(false);




        //startPos = fsm.transform.position;
    }

    public override void Exit()
    {

        fsm.DeliverGravity(1f);
        fsm.DeliverHorizontal(0);

        if (direction == 1)
            fsm.SetDirection(true);
        else
            fsm.SetDirection(false);
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
            Debug.Log("downPos" + downPos);
            Debug.Log("downPos" + upPos);
            fsm.transform.position += (Vector3)(downPos - upPos - Vector2.down * 0.3f);
            
            fsm.SwitchState("IdleState");
        }
        
        /*
        if (timer >= 0f && !up)
        {
            Debug.Log("Enter first goto");
            
            up = true;
            float speed = upDistance / upTime * 1.1f;
            
            fsm.GoTo(Vector2.up, speed, upTime);
        }
        else if (timer >= upTime && !upStop)
        {
            upStop = true;
            fsm.Freeze(upStopTime);
        }
        else if (timer >= upTime + upStopTime && !right)
        {

            
            right = true;
            float speed = rightDistance / rightTime * 1.1f;
            fsm.GoTo(Vector2.right * direction, speed, rightTime);
            Debug.Log("enter right speed : " + speed + " time : " + rightTime);

        }
        else if (timer >= upTime + upStopTime + rightTime && !endStop)
        {
            endStop = true;
            fsm.Freeze(endStopTime);
        }
        else if (timer >= upTime + upStopTime + rightTime + endStopTime)
        {
            fsm.SwitchState("IdleState");
        }
        */

    }
    
    protected override void SwitchAnim()
    {
        fsm.SwitchAnim("ClimbUp");
    }

    public void GetData()
    {
        bool rightSide = (bool)fsm.BlackBoard["RightSide"];
        if (rightSide)
            direction = -1;
        else
            direction = 1;

        climbDownPoint = fsm.BlackBoard["ClimbDownPoint"] as Transform;
    }
}