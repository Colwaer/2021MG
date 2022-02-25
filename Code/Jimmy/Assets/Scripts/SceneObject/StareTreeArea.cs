using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StareTreeArea : InteractableObj
{
    StateMachine fsm;

    private void Awake()
    {
        fsm = GameObject.FindGameObjectWithTag("Player").GetComponent<StateMachine>();
    }

    protected override void Update()
    {
        base.Update();
        
    }


    protected override void PlayAnim()
    {
        Debug.Log("Tree Play Anim");
    }
    protected override void DoInteract(StateMachine fsm)
    {

        Debug.Log("Tree DoInteract" + " StateName : " + fsm.stateName);
        if (fsm.stateName == "PoseState")
        {
            fsm.SwitchState("IdleState");
        }
        else
        {
            fsm.BlackBoard["PoseType"] = "3";
            fsm.SwitchState("PoseState");
        }
        PlayAnim();
    }

}
