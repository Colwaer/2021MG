using System.Collections;
using UnityEngine;

public class SeekState : PlayerState
{
    private float m_AnimTime = 2f;
    private float m_AnimTimer = 2f;
    public override void Enter()
    {
        SwitchAnim();
        m_AnimTimer = m_AnimTime;
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
        m_AnimTimer -= Time.deltaTime;
        if (m_AnimTimer <= 0)
            fsm.SwitchState("IdleState");
    }

    protected override void SwitchAnim()
    {
        fsm.SwitchAnim("Seek");
    }
}
