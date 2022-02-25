using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : InteractableObj
{
    protected override void PlayAnim()
    {
        Debug.Log("Bush Play Anim");
    }
    protected override void DoInteract(StateMachine fsm)
    {
        //if (fsm.stateName == "HideState")
        //{
        //    fsm.SwitchState("IdleState");
        //}
        //else
        //{
        //    fsm.SwitchState("HideState");
        //}
        PlayAnim();
    }



}
