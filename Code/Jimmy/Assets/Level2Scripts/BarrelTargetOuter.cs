using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelTargetOuter : ScrapTargetOuter
{
    public GameObject checkActive;
    

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
        return checkActive.activeInHierarchy;
    }
}
