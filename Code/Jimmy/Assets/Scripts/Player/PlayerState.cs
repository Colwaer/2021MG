using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    protected StateMachine fsm;
    public abstract void Enter();

    protected abstract void SwitchAnim();
    public abstract void Exit();
    public virtual void Update()
    {
        HandleInput();
    }
    protected abstract void HandleInput();

    public virtual void Init(StateMachine stateMachine)
    {
        fsm = stateMachine;
    }
}
