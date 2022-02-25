using System.Collections;
using UnityEngine;

public class HideState : PlayerState
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
        
    }

    protected override void SwitchAnim()
    {
        fsm.SwitchAnim("Hide");
    }
    
}
