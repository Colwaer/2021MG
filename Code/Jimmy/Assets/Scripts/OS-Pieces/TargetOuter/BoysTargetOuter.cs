using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoysTargetOuter : ScrapTargetOuter
{
    StateMachine fsm;
    public GameObject checkActive;
    public List<DraggableObjPlus> trees;

    private void Awake()
    {
        fsm = GameObject.FindGameObjectWithTag("Player").GetComponent<StateMachine>();

    }
    //�������
    protected override void CheckCondition()
    {
        Debug.Log("checkactive :  " + checkActive + "checktreePlace �� " + CheckTreesPlace() + " statename : " + fsm.stateName);
        if (checkActive.activeInHierarchy && CheckTreesPlace() && fsm.CompareAnimName("Pose3"))//������Ұں��˶���
        {
            SetActive = true;
            transform.GetChild(1).gameObject.SetActive(true);

            GameManager1_3.Instance.OnThirdPupilShown();
        }
        else
        {

            transform.GetChild(1).gameObject.SetActive(false);
        }

    }

    bool CheckTreesPlace()
    {
        foreach (var item in trees)
        {
            if (!item.CorrectlyPlaced)
                return false;
        }
        return true;
    }

    public override bool OuterCheck()
    {
        return CheckTreesPlace() && fsm.CompareAnimName("Pose3");
    }
}
