using System.Collections;
using UnityEngine;

public class StareTreeState : PlayerState
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
        if (Input.anyKeyDown)
        {
            fsm.SwitchState("IdleState");
        }

    }

    protected override void SwitchAnim()
    {
        fsm.SwitchAnim("StareTree");
    }
}
