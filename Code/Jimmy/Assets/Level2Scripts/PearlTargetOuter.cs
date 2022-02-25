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


    //�������
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
        //��ֽ����ȷ���� && ����żλ����ȷ && Ů��żλ����ȷ
        return checkActive.activeInHierarchy && goblet1.Full && goblet2.Full && drag1.CorrectlyPlaced && drag2.CorrectlyPlaced;
    }
}
