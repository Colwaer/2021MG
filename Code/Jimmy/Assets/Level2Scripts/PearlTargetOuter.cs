using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearlTargetOuter : ScrapTargetOuter
{
    public GameObject checkActive;

    public Goblet goblet1;
    public Goblet goblet2;
    public DraggableObjPlus drag1;
    public DraggableObjPlus drag2;


    //检测条件
    protected override void CheckCondition()
    {
        if (OuterCheck())
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
        //贴纸被正确吸附 && 男人偶位置正确 && 女人偶位置正确
        return checkActive.activeInHierarchy && goblet1.Full && goblet2.Full && drag1.CorrectlyPlaced && drag2.CorrectlyPlaced;
    }
}
