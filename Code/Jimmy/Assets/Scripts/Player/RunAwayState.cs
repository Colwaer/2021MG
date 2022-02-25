using UnityEditor;
using UnityEngine;

public class RunAwayState : PlayerState
{
    private PlayerAwayArea awayArea;
    private int runDirection;
    private float speed = 1.1f;

    private float runAwayDistance = 8f;

    float startTime = 0.7f;
    float startTimer = 0f;
    bool start = false;
    public override void Enter()
    {
        SwitchAnim();
        awayArea = fsm.BlackBoard["PlayerAwayArea"] as PlayerAwayArea;
        runAwayDistance = (float)fsm.BlackBoard["RunAwayDistance"];
        if (awayArea.transform.position.x > fsm.transform.position.x)
            runDirection = -1;
        else
            runDirection = 1;

        
        Debug.Log(runDirection);
        Debug.Log("Player Enter runaway State");
    }
    
    public override void Exit()
    {
        fsm.DeliverHorizontal(0f);
        startTimer = 0f;
        start = false;
    }

    protected override void HandleInput()
    {
        
    }
    public override void Update()
    {
        

        if (!start)
        {
            startTimer += Time.deltaTime;
            if (startTimer > startTime)
            {
                start = true;
                fsm.SetDirection(false);
                fsm.SwitchAnim("Move");
            }
                
            return;
        }
            

        base.Update();

        if (awayArea.transform.position.x < fsm.transform.position.x)
            fsm.SetDirection(true);

        if (Mathf.Abs(awayArea.transform.position.x - fsm.transform.position.x) < runAwayDistance)
        {
            fsm.DeliverHorizontal(speed * runDirection);
        }
        else
        {
            fsm.SwitchState("IdleState");
        }
    }
    protected override void SwitchAnim()
    {
        fsm.SwitchAnim("Shocked");
    }
}
