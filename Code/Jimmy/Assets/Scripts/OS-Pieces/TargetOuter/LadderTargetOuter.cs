using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderTargetOuter : ScrapTargetOuter
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
        Debug.Log("Tree placed : " + CheckTreesPlace());
        if (checkActive.activeInHierarchy && CheckTreesPlace())//������Ұں��˶���
        {
            SetActive = true;
            transform.GetChild(1).gameObject.SetActive(true);
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
        return checkActive.activeInHierarchy && CheckTreesPlace();
    }
}
