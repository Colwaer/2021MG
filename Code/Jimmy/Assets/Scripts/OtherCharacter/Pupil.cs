using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pupil : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 2.0f;

    bool startRun = false;
    public float startRunTime = 2.0f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        StartCoroutine(IStartRun());
    }
    IEnumerator IStartRun()
    {
        float timer = 0f;
        startRun = false;
        while (timer < startRunTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        GetComponent<Animator>().Play("BoysPurple");
        startRun = true;
    }
    private void FixedUpdate()
    {
        if (!startRun)
            return;
        Run();
    }
    private void Run()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }
}
