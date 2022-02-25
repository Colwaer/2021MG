using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class Ladder1_3 : MonoBehaviour
{
    private PlayerController m_PlayerController;

    private StateMachine fsm;

    private CapsuleCollider2D m_SelfCollider;

    private Collider2D collider;

    public Transform fallPoint;
    private void Start()
    {
        m_SelfCollider = GetComponent<CapsuleCollider2D>();        

        m_PlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        fsm = GameObject.FindGameObjectWithTag("Player").GetComponent<StateMachine>();

        collider = GetComponent<Collider2D>();
    }
    private void OnEnable()
    {
        
    }

    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {


            m_PlayerController.ChangeClimbState(ClimbState.EnableClimbVine, typeof(Vine));
            m_PlayerController.climbArea = m_SelfCollider;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Mathf.Abs(fallPoint.position.y - collision.transform.position.y) < 0.5f)
        {
            collider.enabled = false;

            fsm.SwitchState("LadderFallState");

            GameManager1_3.Instance.OnFallingFromLadder();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_PlayerController.ChangeClimbState(ClimbState.DisableClimb, typeof(Vine));
            m_PlayerController.climbArea = null;
        }
    }
}
