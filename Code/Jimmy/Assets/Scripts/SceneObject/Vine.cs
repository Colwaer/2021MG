using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class Vine : MonoBehaviour
{
    private PlayerController m_PlayerController;

    private CapsuleCollider2D m_SelfCollider;

    private BoxCollider2D m_HiddenPlatform;
    private void Start()
    {
        m_SelfCollider = GetComponent<CapsuleCollider2D>();        
        m_PlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        m_HiddenPlatform = GetComponentInChildren<BoxCollider2D>();
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
        //if (m_HiddenPlatform.enabled)
        //{
            
        //}
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
