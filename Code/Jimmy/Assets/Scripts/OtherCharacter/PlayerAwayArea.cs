using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwayArea : MonoBehaviour
{
    private StateMachine fsm;
    private Giant giant;
    public float runAwayDistance = 5f;

    public bool needGiantScript = true;

    public bool climbDown = false;

    public bool Enable = true;

    public bool showDialog1_1 = false;
    public bool showDialog1_3 = false;
    private void Awake()
    {
        fsm = GameObject.FindGameObjectWithTag("Player").GetComponent<StateMachine>();
        giant = transform.parent.GetComponent<Giant>();
        

    }
    private void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Enable)
            return;

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player enter guard away area");

            fsm.BlackBoard["PlayerAwayArea"] = this;
            fsm.BlackBoard["RunAwayDistance"] = runAwayDistance;
            Debug.Log("Show dialog" + showDialog1_1);
            if (showDialog1_1)
            {
                Debug.Log("Show dialog");
                transform.parent.GetComponent<DialogueController>().OnClick();
            }
            if (showDialog1_3)
            {
                Debug.LogWarning("Show replace");
                transform.parent.GetComponent<GiantDialog1_3>().ShowReplaceDialog();
            }

            if (needGiantScript)
            {
                if (giant.giantState == GiantState.None)
                {

                    fsm.SwitchState("RunAwayState");
                }
                else if (giant.giantState == GiantState.ChasePupil && fsm.stateName != "HideState")
                {
                    if (fsm.stateName != "DuckState")
                        fsm.SwitchState("DuckState");
                }
            }
            else if (!climbDown)
            {
                Debug.Log("Switch away");
                if (fsm.stateName != "RunAwayState")
                    fsm.SwitchState("RunAwayState");
            }
            else
            {
                fsm.SwitchState("ClimbDownState");
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!Enable)
            return;

        if (collision.CompareTag("Player"))
        {
            if (needGiantScript)
            {
                if (giant.giantState == GiantState.None)
                {

                }
                else if (giant.giantState == GiantState.ChasePupil && fsm.stateName != "HideState")
                {
                    fsm.SwitchState("IdleState");
                }
            }           
        }
    }
}
