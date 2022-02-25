using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObj : MonoBehaviour, IClickable
{
    public Vector2 dragSpeed;

    private bool m_startDrag;

    public float detection = 0.3f;
    public List<Transform> attachPoints;
    public Transform correctAttachPoint;

    protected Transform m_currentAttachPoint;
    public Transform checkAttachPoint;

    private Vector2 originMousePos;
    private Vector3 originPos;

    public bool enableDrag = true;

    public bool disableMoveWithPlayer = false;
    public bool CorrectlyPlaced => m_currentAttachPoint == correctAttachPoint && correctAttachPoint;

    public LayerMask playerLayer;

    new private Collider2D collider;

    private Collider2D selfCollider;

    
    protected virtual void Awake()
    {
        selfCollider = GetComponent<Collider2D>();
        if (disableMoveWithPlayer)
            collider = transform.GetChild(0).GetComponent<Collider2D>();
    }

    private void Update()
    {
        
    }

    protected virtual void FixedUpdate()
    {
        if (!enableDrag)
        {
            selfCollider.enabled = false;
            return;
        }
        else
        {
            selfCollider.enabled = true;
        }
            

        if (disableMoveWithPlayer && collider.IsTouchingLayers(playerLayer))
            return;


        if (!m_startDrag)
        {
            return;
        }
            
        if (!m_currentAttachPoint)
        {
            Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector3)originMousePos;
            offset.z = 0;
            offset *= dragSpeed;
            Vector3 tarPos = offset + originPos;
        
            // 吸附暂且还没写 


            if (attachPoints != null)
            {
                bool attached = false;
                Vector2 checkPos = GetWorldPosOfCheckPoint();
                foreach (var item in attachPoints)
                {
                    if (item == m_currentAttachPoint)
                        continue;
                    ;
                    Vector2 itemPos = item.position;

                    if (Vector2.Distance(itemPos * dragSpeed, checkPos * dragSpeed) < detection)
                    {
                        
                        Vector2 selfPos = transform.position;

                        if (dragSpeed.x > 0.05f)
                            tarPos.x = itemPos.x - checkPos.x + selfPos.x;
                        if (dragSpeed.y > 0.05f)
                            tarPos.y = itemPos.y - checkPos.y + selfPos.y;
                        attached = true;
                        m_currentAttachPoint = item;
                        
                        
                        
                        // 吸附上了就重置一些参数
                        originPos = transform.position;
                        originMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    }
                }

                if (!attached)
                    m_currentAttachPoint = null;
            }
        
            transform.position = tarPos;
        }
        else
        {
            Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector3)originMousePos;
            offset.z = 0;
            offset *= dragSpeed;
            Debug.Log(offset);
            if (offset.magnitude > detection)
            {
                m_currentAttachPoint = null;
                Vector3 tarPos = offset + originPos;
                transform.position = tarPos;
            }
        }
        
    }
    
    private Vector2 GetWorldPosOfCheckPoint()
    {
        Transform selfTransform = transform;
        Vector2 offset = checkAttachPoint.localPosition * (Vector2)selfTransform.localScale;
        Vector2 ret = (Vector2)selfTransform.position + offset;
        return ret;
    }
    public virtual void OnMouseButtonDown()
    {
        m_startDrag = true;
        originMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        originPos = transform.position;
    }

    public virtual void OnMouseButtonUp()
    {
        m_startDrag = false;
    }
}
