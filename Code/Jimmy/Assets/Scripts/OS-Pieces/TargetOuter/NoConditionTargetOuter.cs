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
    //�������
    protected override void CheckCondition()
    {




        if (checkActive.activeInHierarchy)//������Ұں��˶���
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
