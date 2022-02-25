using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowers : InteractableObj
{
    StateMachine fsm;
    bool check = true;

    private void Awake()
    {
        fsm = GameObject.FindGameObjectWithTag("Player").GetComponent<StateMachine>();
    }

    protected override void Update()
    {
        base.Update();
        if (check && Vector2.Distance(transform.position, fsm.transform.position) < 5f)
        {
            check = false;
            GameManager1_3.Instance.OnVinePicked();
        }
    }


    protected override void PlayAnim()
    {
        Debug.Log("Flowers Play Anim");
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
            fsm.BlackBoard["PoseType"] = "1";
            fsm.SwitchState("PoseState");
        }
        PlayAnim();
    }

}
