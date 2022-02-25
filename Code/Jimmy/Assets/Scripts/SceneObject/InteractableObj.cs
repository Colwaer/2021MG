using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractableObj : MonoBehaviour
{
    private KeyCode m_interactKey = KeyCode.E;
    protected StateMachine m_StateMachine;

    private bool insideCollider = false;

    protected virtual void Start()
    {
        m_StateMachine = GameObject.FindGameObjectWithTag("Player").GetComponent<StateMachine>();
    }
   
    protected virtual void Update()
    {
        if (insideCollider && Input.GetKeyDown(m_interactKey))
        {
            DoInteract(m_StateMachine);
        }
    }
    protected virtual void DoInteract(StateMachine fsm) { }
    protected virtual void PlayAnim() 
    {
        throw new NotImplementedException();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            insideCollider = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            insideCollider = false;
        }
    }
}
