using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTargetOuter : ScrapTargetOuter
{
    public GameObject checkActive;


    private void Start()
    {
        
    }
    //�������
    protected override void CheckCondition()
    {

        


        if (checkActive.activeInHierarchy)
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
