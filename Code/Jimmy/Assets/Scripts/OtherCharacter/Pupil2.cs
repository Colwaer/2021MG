using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pupil2 : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 2.0f;

    bool startRun = false;
    public float startRunTime = 2.0f;
    public Transform pupil;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        
    }

    private void FixedUpdate()
    {
        if (!startRun)
        {
            if (Mathf.Abs(pupil.position.x - transform.position.x) < 1f)
                startRun = true;
            return;
        }
            
        Run();
    }
    private void Run()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }
}
