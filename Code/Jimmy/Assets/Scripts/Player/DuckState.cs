using System.Collections;
using UnityEngine;

public class DuckState : PlayerState
{
    float runAwayDistance = 3f;

    Vector2 originPos;

    float speed = 2f;

    bool goRight = false;

    float goRightTime = 2.3f;
    float timer = 0f;
    public override void Enter()
    {
        goRight = false;
        timer = 0f;
        SwitchAnim();
        originPos = fsm.transform.position;
        fsm.SetDirection(false);
        fsm.DeliverHorizontal(0);
        fsm.Freeze(0.1f);
        fsm.GoTo(Vector2.left, speed, goRightTime);
    }

    public override void Exit()
    {
        fsm.Freeze(0.3f);
    }

    protected override void HandleInput()
    {
        
    }
    public override void Update()
    {
        base.Update();

        timer += Time.deltaTime;

        if (timer >= goRightTime && !goRight)
        {
            fsm.SetDirection(true);
            goRight = true;
            fsm.SwitchAnim("Duck");
            fsm.GoTo(Vector2.right, speed / 2, goRightTime / 3);
        }
        else if (timer >= goRightTime * 1.3)
        {
            fsm.SwitchState("MoveState");
        }
        

    }
    protected override void SwitchAnim()
    {
        fsm.SwitchAnim("Duck");
    }
}
