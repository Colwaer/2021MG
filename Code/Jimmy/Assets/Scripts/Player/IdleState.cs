using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState
{

    public override void Enter()
    {
        SwitchAnim();
    }

    public override void Exit()
    {
        
    }

    protected override void HandleInput()
    {
        if (!fsm.ReceiveInput)
            return;

        float horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal != 0)
        {
            //Debug.Log("Enter movestate");
            //fsm.DeliverHorizontal(horizontal);
            fsm.SwitchState("MoveState");
            return;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (fsm.climbState == ClimbState.EnableClimbVine)
            {
                fsm.SwitchState("ClimbVineState");
            }
            else if (fsm.climbState == ClimbState.EnableClimbUp)
            {
                fsm.SwitchState("ClimbUpState");
            }
        }
        else  if (Input.GetKeyDown(KeyCode.S))
        {
            if (fsm.climbState == ClimbState.EnableClimbVine)
            {
                fsm.SwitchState("ClimbVineState");
            }
            else if (fsm.climbState == ClimbState.EnableClimbDown)
            {
                fsm.SwitchState("ClimbDownState");
            }
        }
    }

    protected override void SwitchAnim()
    {
        fsm.SwitchAnim("Idle");
    }
   
}
