using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoConditionTargetOuter : ScrapTargetOuter
{
    StateMachine fsm;
    public GameObject checkActive;


    private void Awake()
    {
        fsm = GameObject.FindGameObjectWithTag("Player").GetComponent<StateMachine>();
    }
    //检测条件
    protected override void CheckCondition()
    {




        if (checkActive.activeInHierarchy)//并且玩家摆好了动作
        {


            SetActive = true;
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }

    }

    public override bool OuterCheck()
    {
        return checkActive.activeInHierarchy;
    }
}
