using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private PlayerState m_currentState;
    private PlayerController m_PlayerController;
    private string m_StateName;
    public string stateName => m_StateName;

    public ClimbState climbState => m_PlayerController.climbState;

    private bool m_ReceiveInput = true;
    public bool ReceiveInput => m_ReceiveInput;
    public Vector2 footOffset;
    private Dictionary<string, PlayerState> dic = new Dictionary<string, PlayerState>();
    public Dictionary<string, object> BlackBoard = new Dictionary<string, object>();

    public bool OnGround => m_PlayerController.OnGround;
    public bool EnableFallDown => m_PlayerController.enableFallDown;
    private Animator animator;


    float climbStartY;
    float climbEndY;
    bool adjustClimbPos = false;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        m_PlayerController = GetComponent<PlayerController>();
        CreateStates();
        m_currentState = dic["IdleState"];
        BlackBoard["FootOffset"] = footOffset;
        BlackBoard["RunAwayDistance"] = 5f;
        
    }
    private void Update()
    {
        m_currentState.Update();
        Debug.Log(m_currentState);



    }

    private void CreateStates()
    {
        IdleState idleState = new IdleState();
        idleState.Init(this);
        dic.Add("IdleState", idleState);

        MoveState moveState = new MoveState();
        moveState.Init(this);
        dic.Add("MoveState", moveState);

        ClimbVineState climbVineState = new ClimbVineState();
        climbVineState.Init(this);
        dic.Add("ClimbVineState", climbVineState);

        PoseState poseState = new PoseState();
        poseState.Init(this);
        dic.Add("PoseState", poseState);

        SeekState seekState = new SeekState();
        seekState.Init(this);
        dic.Add("SeekState", seekState);

        HideState hideState = new HideState();
        hideState.Init(this);
        dic.Add("HideState", hideState);

        ClimbUpState climbUpState = new ClimbUpState();
        climbUpState.Init(this);
        dic.Add("ClimbUpState", climbUpState);

        ClimbDownState climbDownState = new ClimbDownState();
        climbDownState.Init(this);
        dic.Add("ClimbDownState", climbDownState);

        RunAwayState runAwayState = new RunAwayState();
        runAwayState.Init(this);
        dic.Add("RunAwayState", runAwayState);

        DuckState duckState = new DuckState();
        duckState.Init(this);
        dic.Add("DuckState", duckState);

        StareTreeState stareTreeState = new StareTreeState();
        stareTreeState.Init(this);
        dic.Add("StareTreeState", stareTreeState);

        LadderFallState ladderFallState = new LadderFallState();
        ladderFallState.Init(this);
        dic.Add("LadderFallState", ladderFallState);
    }



    public void StartAdjustClimbPos()
    {
        
    }
    public void EndAdjustClimbPos()
    {

    }



    public void SwitchState(string stateName)
    {
        m_StateName = stateName;

        PlayerState state = dic[stateName];
        m_currentState.Exit();
        m_currentState = state;
        state.Enter();
    }
    public bool CompareAnimName(string name)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(name);
    }
    public void SwitchAnim(string name)
    {
        m_PlayerController.SwitchAnim(name);
    }
    public void ChangeAnimTimeScale(float val)
    {
        m_PlayerController.ChangeAnimTimeScale(val);
    }
    public void DeliverHorizontal(float val)
    {
        m_PlayerController.DeliverHorizontalSpeed(val);
    }
    public void DeliverVertical(float val)
    {
        m_PlayerController.DeliverVerticalSpeed(val);
    }
    public void StartClimbVine()
    {
        m_PlayerController.StartClimbVine();
    }
    public void EndClimbVine()
    {
        m_PlayerController.EndClimbVine();
    }
    public void GoToDes(Vector2 pos, float speed)
    {
        Debug.Log("GoToDes : " + pos);
        m_PlayerController.GoToDes(pos, speed);
    }
    public void Jump(float height)
    {
        Debug.Log("jump height : " + height);
        m_PlayerController.Jump(height);
    }
    public void SetDirection(bool right)
    {
        m_PlayerController.SetDirection(right);
    }
    public void DeliverGravity(float val)
    {
        m_PlayerController.DeliverGravity(val);
    }
    public void GoTo(Vector2 dir, float speed, float time)
    {
        m_PlayerController.GoTo(dir, speed, time);
    }
    public void Freeze(float time)
    {
        m_PlayerController.Freeze(time);
    }
}
