using System.Collections;
using UnityEngine;

public class PoseState : PlayerState
{
    string poseType;

    public override void Enter()
    {
        poseType = fsm.BlackBoard["PoseType"] as string;
        SwitchAnim();

        fsm.SetDirection(true);
        
    }

    public override void Exit()
    {
        
    }

    protected override void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            fsm.SwitchState("IdleState");
        }
    }

    protected override void SwitchAnim()
    {
        fsm.SwitchAnim("Pose" + poseType);
    }
}
