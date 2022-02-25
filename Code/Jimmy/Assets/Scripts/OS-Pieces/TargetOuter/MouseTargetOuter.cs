using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTargetOuter : ScrapTargetOuter
{
   public GameObject checkActive;

    //检测条件
    protected override void CheckCondition()
    {
        if(OuterCheck())
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
        //贴纸被正确吸附 && 茶几被正确吸附
        return drag.CorrectlyPlaced && GameManager1_2.instance.ChaJiCorrectlyPlaced() && checkActive.activeInHierarchy;
    }
}
