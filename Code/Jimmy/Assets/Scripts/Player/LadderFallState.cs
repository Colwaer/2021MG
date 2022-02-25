using System.Collections;
using UnityEngine;

public class LadderFallState : PlayerState
{


    public override void Enter()
    {
        SwitchAnim();
        fsm.Freeze(0.9f);
    }

    public override void Exit()
    {
        
    }

    protected override void HandleInput()
    {

    }
    public override void Update()
    {
        base.Update();

        if (fsm.OnGround)
        {
            fsm.SwitchState("IdleState");
        }
    }

    protected override void SwitchAnim()
    {
        fsm.SwitchAnim("TearWall");
    }
}
