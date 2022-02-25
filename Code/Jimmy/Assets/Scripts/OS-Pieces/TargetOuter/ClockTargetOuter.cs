using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTargetOuter : ScrapTargetOuter
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
        //贴纸被正确吸附 && 守卫在楼上 && 二楼的楼梯没被撕
        return drag.CorrectlyPlaced && checkActive.activeInHierarchy;
    }
}
