using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClimbState
{
    DisableClimb, EnableClimbUp, EnableClimbDown, EnableClimbVine, EnableClimbLadder
}

public class PlayerController : MonoBehaviour
{
    public Vector2 speed = new Vector2(3f, 1f);
    
    private Rigidbody2D m_Rigidbody2D;
    private Animator m_Animator;

    private float m_HorizontalSpeed;
    private float m_VerticalSpeed;

    private bool m_ReceiveInput = true;
    public bool ReceiveInput => m_ReceiveInput;
    private bool m_ReceiveHorizontalInput = true;
    public bool ReceiveHorizontalInput => m_ReceiveHorizontalInput;
    private bool m_ReceiveVerticalInput = true;
    public bool ReceiveVerticalInput => m_ReceiveVerticalInput;

    public ClimbState climbState;

    public AK.Wwise.Event footStep;
    public AK.Wwise.Event shocked;
    public Collider2D climbArea;

    private bool m_EnableMove = true;

    private LayerMask groundLayer;
    public bool enableFallDown = true;
    public bool OnGround => m_Rigidbody2D.IsTouchingLayers(groundLayer);
    private void Awake()
    {
        m_Rigidbody2D = GetComponentInChildren<Rigidbody2D>();
        m_Animator = GetComponentInChildren<Animator>();

        groundLayer = LayerMask.GetMask("Platform");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            PlayFootStepSound();
    }

    private void FixedUpdate()
    {
        if (m_EnableMove)
        {
            Move();
        }
        
        SwitchAnim();


    }

    private void SwitchAnim()
    {
        # region Check OnGround
        // 场景搭好了后和动画有了后再确定写不写
        # endregion
        m_Animator.SetFloat("Horizontal", m_HorizontalSpeed);
        m_Animator.SetBool("Move", Mathf.Abs(m_HorizontalSpeed) > 0.05f);
        // climbUP 和 climbDown需要被单独处罚
    }
    public void ChangeClimbState(ClimbState climbState, Type type)
    {
        Debug.Log(type + " changed climbState to " + climbState);
        this.climbState = climbState;
    }
    public void SwitchAnim_Seek()
    {
        m_Animator.SetTrigger("Seek");
    }
    public void SwitchAnim_ClimbUp()
    {
        m_Animator.SetTrigger("ClimbUp");
    }
    
    public void SwitchAnim_ClimbDown()
    {
        m_Animator.SetTrigger("ClimbDown");
    }
    public void SwitchAnim_Pose()
    {
        m_Animator.SetTrigger("Pose");
    }
    public void SwitchAnim(string name)
    {
        m_Animator.Play(name);
    }
    public void StartClimbVine()
    {
        m_Rigidbody2D.gravityScale = 0f;
    }
    public void ChangeAnimTimeScale(float val)
    {
        m_Animator.speed = val;
    }
    public void EndClimbVine()
    {
        m_Rigidbody2D.gravityScale = 1f;
    }
    
    public void SetDirection(bool right)
    {
        if (right)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);
    }
    IEnumerator _IGoto;
    public void GoTo(Vector2 dir, float speed, float time)
    {
        m_EnableMove = false;
        DeliverGravity(0f);
        if (_IGoto != null)
            StopCoroutine(_IGoto);

        _IGoto = IGoTo(dir, speed, time);
        StartCoroutine(_IGoto);
    }
    IEnumerator IGoTo(Vector2 dir, float speed, float time)
    {
        float timer = 0;
        while (timer < time)
        {
            Debug.Log("change velocity to : " + speed * dir);
            timer += Time.deltaTime;
            transform.position += (Vector3)dir * speed * Time.deltaTime;
            yield return null;
        }
        DeliverGravity(1f);
        m_EnableMove = true;
    }
    public void Freeze(float time)
    {
        m_EnableMove = false;
        DeliverGravity(0f);
        StartCoroutine(IFreeze(time));
    }
    IEnumerator IFreeze(float time)
    {
        float timer = 0f;
        while (timer < time)
        {
            timer += Time.deltaTime;
            m_Rigidbody2D.velocity = Vector2.zero;
            yield return null;
        }
        DeliverGravity(1f);
        m_EnableMove = true;
    }

    public void GoToDes(Vector2 pos, float speed)
    {
        m_EnableMove = false;
        m_Rigidbody2D.gravityScale = 0;

        StartCoroutine(IGoToDes(pos, speed));
    }
    IEnumerator IGoToDes(Vector2 pos, float speed)
    {
        Vector2 dir = (pos - m_Rigidbody2D.position).normalized;
        while (Vector2.Distance(pos, m_Rigidbody2D.position) > 0.1f)
        {
            Debug.Log(dir);
            m_Rigidbody2D.velocity = dir * speed / 5f;
            yield return new WaitForFixedUpdate();
        }
        m_Rigidbody2D.gravityScale = 1f;
        m_EnableMove = true;
    }
    public void Jump(float height)
    {
        m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, Mathf.Sqrt(2f * -Physics2D.gravity.y * height));
    }

    public void EndClimb()
    {
        
    }

    private void Move()
    {
        float verticalSpeed = m_Rigidbody2D.velocity.y;
        if (m_Rigidbody2D.gravityScale == 0)
            verticalSpeed = m_VerticalSpeed * speed.y;
        m_Rigidbody2D.velocity = new Vector2(m_HorizontalSpeed * speed.x, verticalSpeed);
    }
    public void DeliverHorizontalSpeed(float val)
    {
        m_HorizontalSpeed = val;
    }
    public void DeliverVerticalSpeed(float val)
    {
        m_VerticalSpeed = val;
    }
    public void PlayFootStepSound()
    {
        footStep.Post(gameObject);
    }
    public void PlayShockedSound()
    {
        shocked.Post(gameObject);
    }
    public void DeliverGravity(float val)
    {
        m_Rigidbody2D.gravityScale = val;
    }
}
