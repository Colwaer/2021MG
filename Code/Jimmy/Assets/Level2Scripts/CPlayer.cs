using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer : MonoBehaviour
{
    [Header("最高上飞距离")]
    [SerializeField] public float flyUpDis = 4.0f;
    [Header("最高下飞距离")]
    [SerializeField] public float flyDownDis = 20f;
    [Header("最高水平飞距离")]
    [SerializeField] public float horizontalCheckDis = 3.5f;
    [SerializeField] public float groundCheckDis = 0.8f;
    
    [SerializeField] public float flyUpSpeed = 3.0f;
    [SerializeField] public float flyHoriontalSpeed = 3.0f;
    [SerializeField] public float moveSpeed = 3.0f;
    [SerializeField] public float flyDownSpeed = 3.0f;

    [SerializeField] public LayerMask flyCheckLayer;
    [SerializeField] public LayerMask platformLayer;

    Vector2 flyUpPos;
    Vector2 flyDownPos;
    Vector2 flyRightPos;
    Vector2 flyLeftPos;

    [SerializeField] public bool enableFlyUp = false;
    [SerializeField] public bool enableFlyDown = false;
    [SerializeField] public bool enableFlyRight = false;
    [SerializeField] public bool enableFlyLeft = false;
    Rigidbody2D rb;
    Animator animator;


    public bool HasPearl = false;
    bool flying = false;
    public bool ReceiveInput
    {
        set
        {
            if (value)
                receiveInput = value;
            else
            {
                horizontal = 0f;
                receiveInput = value;
            }    
        }
        get
        {
            return receiveInput;
        }
    }
    private bool receiveInput = true;
    float horizontal;
    bool onGround;
    Collider2D standCollider;
    Collider2D selfCollider;
    Collider2D upCollider;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        selfCollider = GetComponent<Collider2D>();
    }
    private void Update()
    {
        if (ReceiveInput)
        {
            HandleInput();
        }


        animator.SetBool("OnGround", onGround);
        animator.SetBool("Flying", flying);
    }
    private void FixedUpdate()
    {
        PhysicalCheck();
        if (ReceiveInput)
            Move();
    }
    public void EnterFlyUpArea()
    {
        ReceiveInput = false;
        FlyUp();

    }
    public void GetPearl()
    {
        Debug.Log("Player Get Pearl");
        animator.SetTrigger("GetPearl");


        HasPearl = true;
    }
    private void Move()
    {
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
    }
    private void HandleInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal > 0.1f)
        {
            animator.SetBool("Move", true);

            transform.localScale = Vector3.one;
        }
        else if (horizontal < -0.1f)
        {
            animator.SetBool("Move", true);

            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            animator.SetBool("Move", false);
        }
        if (horizontal > 0 && enableFlyRight)
        {
            if (enableFlyRight)
            {
                ReceiveInput = false;
                FlyRight();
            }
        }
        else if (horizontal < 0 && enableFlyLeft)
        {
            if (enableFlyLeft)
            {
                ReceiveInput = false;
                FlyLeft();
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (enableFlyUp)
            {
                ReceiveInput = false;
                FlyUp();
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            
            if (enableFlyDown)
            {
                ReceiveInput = false;
                FlyDown();
            }
        }

    }

    public void PlayReturnPearlAnim()
    {
        animator.Play("ReturnPearl");
    }

    private void FlyRight()
    {
        flying = true;
        rb.gravityScale = 0;
        StartCoroutine(IFlyHorizontal(1f, flyRightPos));
    }
    private void FlyLeft()
    {
        flying = true;
        rb.gravityScale = 0;
        StartCoroutine(IFlyHorizontal(-1f, flyLeftPos));
    }
    public void FlyUp()
    {
        flying = true;
        rb.gravityScale = 0;
        selfCollider.enabled = false;
        StartCoroutine(IFlyUp());
    }
    IEnumerator IFlyHorizontal(float direction, Vector2 tarPos)
    {
        transform.position += new Vector3(0, 0.1f, 0);
        while (Mathf.Abs(transform.position.x - tarPos.x) > 0.3f)
        {
            rb.velocity = new Vector2(flyHoriontalSpeed * direction, 0);
            Debug.Log(flyHoriontalSpeed * direction);
            yield return new WaitForFixedUpdate();
        }
        flying = false;
        rb.gravityScale = 1f;
        selfCollider.enabled = true;
        ReceiveInput = true;
        rb.velocity = Vector2.zero;
    }
    IEnumerator IFlyUp()
    {

        while (Mathf.Abs(transform.position.y - flyUpPos.y) > 0.3f)
        {
            rb.velocity = new Vector2(0, flyUpSpeed);
            yield return new WaitForFixedUpdate();
        }
        rb.gravityScale = 1f;
        selfCollider.enabled = true;
        ReceiveInput = true;
        rb.velocity = Vector2.zero;
        flying = false;
    }
    private  void FlyDown()
    {
        flying = true;
        rb.gravityScale = 0f;
        selfCollider.enabled = false;
        StartCoroutine(IFlyDown());
    }
    IEnumerator IFlyDown()
    {
        while (Mathf.Abs(transform.position.y - flyDownPos.y) > 0.5f)
        {
            rb.velocity = new Vector2(0, -flyDownSpeed);
            yield return new WaitForFixedUpdate();
        }
        rb.gravityScale = 1f;
        selfCollider.enabled = true;
        ReceiveInput = true;
        rb.velocity = Vector2.zero;
        flying = false;
    }

    private void PhysicalCheck()
    {
        if (ReceiveInput)
        {
            RaycastHit2D upHit = Physics2D.Raycast(transform.position, Vector2.up, flyUpDis, flyCheckLayer);
            if (upHit)
            {
                flyUpPos = upHit.point + new Vector2(0, 0.9f);
                enableFlyUp = true;
            }
            else
            {
                enableFlyUp = false;
            }

            RaycastHit2D downHit = Physics2D.Raycast((Vector2)transform.position + Vector2.down * 1.5f, Vector2.down, flyDownDis, flyCheckLayer);
            if (downHit)
            {
                flyDownPos = downHit.point;
                enableFlyDown = true;
            }
            else
            {
                enableFlyDown = false;
            }

            RaycastHit2D rightCheckHit = Physics2D.Raycast(new Vector2(transform.position.x + 0.8f, transform.position.y - 1.3f), Vector2.right, horizontalCheckDis, platformLayer);

            Debug.Log("rightcheckhit collider : " + rightCheckHit.collider + " Onground : " + onGround);
            if (rightCheckHit && (!onGround && rightCheckHit.collider))
            {
                flyRightPos = rightCheckHit.point + new Vector2(0.5f, 0);
                enableFlyRight = true;
            }
            else
            {
                enableFlyRight = false;
            }

            RaycastHit2D leftCheckHit = Physics2D.Raycast(new Vector2(transform.position.x - 0.8f, transform.position.y - 1.3f), Vector2.left, horizontalCheckDis, platformLayer);
            if (leftCheckHit && (!onGround && leftCheckHit.collider))
            {
                flyLeftPos = leftCheckHit.point + new Vector2(-0.5f, 0);
                
                enableFlyLeft = true;
            }
            else
            {
                enableFlyLeft = false;
            }
        }
        

        RaycastHit2D onGroundCheckHit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDis, platformLayer);
        if (onGroundCheckHit)
        {
            
            onGround = true;
            standCollider = onGroundCheckHit.collider;
        }
        else
        {
            onGround = false;
            standCollider = null;
        }

        
    }

    public void PlayAnim(string animName)
    {
        animator.Play(animName);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.up * flyUpDis);
        Gizmos.DrawLine((Vector2)transform.position + Vector2.down * 1.5f, (Vector2)transform.position + Vector2.down * flyDownDis);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.down * groundCheckDis);

        Gizmos.color = Color.grey;
        Gizmos.DrawLine(new Vector2(transform.position.x + 0.6f, transform.position.y - 0.65f),
            new Vector2(transform.position.x + 0.6f, transform.position.y - 0.65f) + Vector2.right * horizontalCheckDis);
        Gizmos.DrawLine(new Vector2(transform.position.x - 0.6f, transform.position.y - 0.65f),
            new Vector2(transform.position.x - 0.6f, transform.position.y - 0.65f) + Vector2.left * horizontalCheckDis);
    }
}
