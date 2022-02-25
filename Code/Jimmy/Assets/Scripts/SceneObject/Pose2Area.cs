using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pose2Area : InteractableObj
{
    StateMachine fsm;

    private void Awake()
    {
        fsm = GameObject.FindGameObjectWithTag("Player").GetComponent<StateMachine>();
    }

    protected override void DoInteract(StateMachine fsm)
    {

        Debug.Log("Flower DoInteract" + " StateName : " + fsm.stateName);
        if (fsm.stateName == "PoseState")
        {
            fsm.SwitchState("IdleState");
        }
        else
        {
            fsm.BlackBoard["PoseType"] = "2";
            fsm.SwitchState("PoseState");
        }
        
    }
}
