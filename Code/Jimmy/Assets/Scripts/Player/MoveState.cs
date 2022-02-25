using UnityEditor;
using UnityEngine;


public class MoveState : PlayerState
{

    public override void Enter()
    {
        SwitchAnim();
    }

    public override void Exit()
    {
        fsm.DeliverHorizontal(0f);
    }

    protected override void HandleInput()
    {
        if (!fsm.ReceiveInput)
            return;

        float horizontal = Input.GetAxisRaw("Horizontal");

        //Debug.Log("movestate horizontal : " + horizontal);

        if (!fsm.EnableFallDown)
        {
            bool right = (bool)fsm.BlackBoard["RightSide"];
            Debug.Log("enter check");
            if (right)
            {
                if (horizontal > 0f)
                    horizontal = 0f;
            }
            else
            {
                if (horizontal < 0f)
                    horizontal = 0f;
            }
        }

        if (horizontal > 0)
            fsm.SetDirection(true);
        else if (horizontal < 0)
            fsm.SetDirection(false);

        fsm.DeliverHorizontal(horizontal);
        if (horizontal == 0)
        {
            
            fsm.SwitchState("IdleState");
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
        else if (Input.GetKeyDown(KeyCode.S))
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
        fsm.SwitchAnim("Move");
    }
}
