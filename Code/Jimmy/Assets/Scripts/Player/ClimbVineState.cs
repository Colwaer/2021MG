using System.Collections;
using UnityEngine;

public class ClimbVineState : PlayerState
{
    public override void Enter()
    {
        SwitchAnim();
        fsm.StartClimbVine();


    }

    public override void Exit()
    {
        fsm.DeliverVertical(0f);
        fsm.EndClimbVine();
    }

    protected override void HandleInput()
    {
        if (fsm.climbState != ClimbState.EnableClimbVine)
        {
            fsm.SwitchState("IdleState");
        }
        float vertical = Input.GetAxisRaw("Vertical");

        fsm.DeliverVertical(vertical);
        if (vertical == 0f)
        {
            fsm.ChangeAnimTimeScale(0);
        }
        else
        {
            fsm.ChangeAnimTimeScale(1);
        }
        
    }

    protected override void SwitchAnim()
    {
        fsm.SwitchAnim("ClimbVine");
    }
}
