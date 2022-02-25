using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbDownPoint : MonoBehaviour
{
    private PlayerController m_PlayerController;
    private StateMachine m_StateMachine;
    public bool rightSide;
    public Transform climbUpPoint;

    public bool takeEffect = true;

    public bool disableFallDown = false;
    // public Vector2 tarPos;
    private void Start()
    {
        m_PlayerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        m_StateMachine = GameObject.FindWithTag("Player").GetComponent<StateMachine>();
    }
    // 如果攀爬区域重合会出bug
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (disableFallDown && other.CompareTag("Player") && other.transform.position.y > transform.position.y)
        {
            m_PlayerController.enableFallDown = false;
            m_StateMachine.BlackBoard["RightSide"] = rightSide;
        }

        if (takeEffect && other.CompareTag("Player") && other.transform.position.y > transform.position.y)
        {
            m_PlayerController.climbState = ClimbState.EnableClimbDown;
            m_StateMachine.BlackBoard["ClimbUpPoint"] = climbUpPoint;
            m_StateMachine.BlackBoard["RightSide"] = rightSide;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (takeEffect && collision.CompareTag("Player") && collision.transform.position.y > transform.position.y)
        {
            m_PlayerController.climbState = ClimbState.EnableClimbDown;
            m_StateMachine.BlackBoard["ClimbUpPoint"] = climbUpPoint;
            m_StateMachine.BlackBoard["RightSide"] = rightSide;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (disableFallDown && other.CompareTag("Player"))
        {
            m_PlayerController.enableFallDown = true;
        }
        if (takeEffect && other.CompareTag("Player"))
        {
            m_PlayerController.climbState = ClimbState.DisableClimb;
        }
    }
}
