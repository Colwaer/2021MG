using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy2TargetOuter : ScrapTargetOuter
{
    StateMachine fsm;
    public GameObject checkActive;
    private DraggableObjPlus[] waters;

    private void Awake()
    {
        fsm = GameObject.FindGameObjectWithTag("Player").GetComponent<StateMachine>();

        waters = GameObject.Find("Waters").GetComponentsInChildren<DraggableObjPlus>();
    }
    //检测条件
    protected override void CheckCondition()
    {
        


        if (checkActive.activeInHierarchy && CheckWaterPlace())//并且玩家摆好了动作
        {
            SetActive = true;
            transform.GetChild(1).gameObject.SetActive(true);

            GameManager1_3.Instance.OnSecondPupilShown();
        }   
        else
        {

            transform.GetChild(1).gameObject.SetActive(false);
        }
            
    }
    
    bool CheckWaterPlace()
    {
        foreach (var item in waters)
        {
            if (!item.CorrectlyPlaced)
                return false;
        }
        return true;
    }

    public override bool OuterCheck()
    {
        return checkActive.activeInHierarchy && CheckWaterPlace();
    }
}
