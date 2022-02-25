using System;
using UnityEngine;
using System.Collections.Generic;

public class InputManager : Singleton<InputManager>
{
    private IClickable[] currentInteractingObj;

    public LayerMask InteractableLayer;
    private Camera mainCamera;

    private PlayerController m_PlayerController;
    protected override void Awake()
    {
        base.Awake();
        mainCamera = Camera.main;
    }

    private void Start()
    {
        //m_PlayerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        #region InteractableMouseControl
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D[] hit = Physics2D.CircleCastAll(mainCamera.ScreenToWorldPoint(Input.mousePosition), 0.2f, Vector2.zero, 0, InteractableLayer);
            if (hit.Length != 0)
            {
                
                int len = hit.Length;
                for (int i = 0; i < hit.Length; i++)
                {
                    int ranIndex = UnityEngine.Random.Range(0, len - 1);
                    currentInteractingObj = hit[ranIndex].collider.gameObject.GetComponents<IClickable>();
                    break;
                      
                }
                // Debug.Log(currentInteractingObj);
            }
            else
            {
                // Debug.Log(Input.mousePosition);
                // Debug.Log(hit);
            }
            if (currentInteractingObj != null)
            {
                //Debug.Log("Inputmanager mousebuttondown");
                foreach (var item in currentInteractingObj)
                {
                    item.OnMouseButtonDown();
                }
                

            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (currentInteractingObj != null)
            {
                foreach (var item in currentInteractingObj)
                {
                    item.OnMouseButtonUp();
                }
                currentInteractingObj = null;
            }
        }

        #endregion

        //if (!m_PlayerController.ReceiveInput)
        //    return;
        
        //#region PlayerControl
        
        //if (m_PlayerController.ReceiveHorizontalInput)
        //{
        //    float horizontal = Input.GetAxisRaw("Horizontal");
        //    m_PlayerController.DeliverHorizontalSpeed(horizontal);
        //}

        
        //if (m_PlayerController.ReceiveVerticalInput)
        //{
        //    if (Input.GetKey(KeyCode.W))
        //    {
        //        m_PlayerController.ClimbUp();
        //    }
        //    else if (Input.GetKey(KeyCode.S))
        //    {
        //        m_PlayerController.ClimbDown();
        //    }
        //}
        
        
        //#endregion
        

        
    }
}
