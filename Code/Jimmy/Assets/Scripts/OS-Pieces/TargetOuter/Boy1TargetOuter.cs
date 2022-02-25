using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy1TargetOuter : ScrapTargetOuter
{
    StateMachine fsm;
    public GameObject checkActive;


    private void Start()
    {
        fsm = GameObject.FindGameObjectWithTag("Player").GetComponent<StateMachine>();
    }
    //检测条件
    protected override void CheckCondition()
    {

        Debug.Log("DRAG" + drag.CorrectlyPlaced);
        Debug.Log("CheckActive" + checkActive.activeInHierarchy);
        Debug.Log(fsm.stateName);


        if (drag.CorrectlyPlaced && checkActive.activeInHierarchy && fsm.CompareAnimName("Pose1"))//并且玩家摆好了动作
        {
            

            SetActive = true;
            transform.GetChild(1).gameObject.SetActive(true);

            GameManager1_3.Instance.OnFistPupilShown();
        }   
        else
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }
            
    }

    public override bool OuterCheck()
    {
        return drag.CorrectlyPlaced && checkActive.activeInHierarchy && fsm.CompareAnimName("Pose1");
    }
}
