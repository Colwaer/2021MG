using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbUpPoint : MonoBehaviour
{
    private PlayerController m_PlayerController;
    private StateMachine m_StateMachine;
    public bool rightSide;
    public Transform climbDownPoint;
    private void Start()
    {
        m_PlayerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        m_StateMachine = GameObject.FindWithTag("Player").GetComponent<StateMachine>();
    }
    // 如果攀爬区域重合会出bug
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger enter");
        if (other.CompareTag("Player") && other.transform.position.y > transform.position.y)
        {
            m_PlayerController.climbState = ClimbState.EnableClimbUp;
            m_StateMachine.BlackBoard["ClimbDownPoint"] = climbDownPoint;
            m_StateMachine.BlackBoard["ClimbUpPoint"] = transform;
            m_StateMachine.BlackBoard["RightSide"] = rightSide;
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.transform.position.y > transform.position.y)
        {
            m_PlayerController.climbState = ClimbState.EnableClimbUp;
            m_StateMachine.BlackBoard["ClimbDownPoint"] = climbDownPoint;
            m_StateMachine.BlackBoard["ClimbUpPoint"] = transform;
            m_StateMachine.BlackBoard["RightSide"] = rightSide;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            m_PlayerController.climbState = ClimbState.DisableClimb;
        }   
    }
}
