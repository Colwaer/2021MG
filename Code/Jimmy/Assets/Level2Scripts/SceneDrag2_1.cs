using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDrag2_1 : MonoBehaviour, IClickable
{

    public float dragDis = 0.6f;

    bool startDrag = false;
    float originMouseXPos;

    Animator animator;

    int currentPos = -1;    // 0 mid    -1 left     1 right

    public bool enableDrag = true;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!enableDrag)
            return;

        if (startDrag)
        {
            float xPos = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            if (originMouseXPos - xPos > dragDis)
            {
                //Debug.Log("Dr/*agLeft");*/
                DragLeft();
                startDrag = false;

            }
            else if (originMouseXPos - xPos < -dragDis)
            {
                //Debug.LogWarning("tearUp");
                DragRight();
                startDrag = false;
            }
        }
    }
    public void StopAnim()
    {
        animator.SetFloat("Speed", 0f);
    }
    private void DragLeft()
    {
        if (currentPos == 1)
        {
            currentPos--;
            animator.SetFloat("Speed", -1);
            animator.Play("DragRight");
            StartCoroutine(IDownCount());
        }
        else if (currentPos == 0)
        {
            currentPos--;
            animator.SetFloat("Speed", 1);
            animator.Play("DragLeft");
            StartCoroutine(IDownCount());
        }
        
    }
    IEnumerator IDownCount()
    {
        float time = 0.99f;
        float timer = 0f;
        while (timer < time)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        StopAnim();
    }
    private void DragRight()
    {
        if (currentPos == -1)
        {
            currentPos++;
            animator.SetFloat("Speed", -1);
            animator.Play("DragLeft");
            StartCoroutine(IDownCount());
        }
        else if (currentPos == 0)
        {
            currentPos++;
            animator.SetFloat("Speed", 1);
            animator.Play("DragRight");
            StartCoroutine(IDownCount());
        }
    }
    public void OnMouseButtonDown()
    {

        startDrag = true;
        originMouseXPos = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
    }

    public void OnMouseButtonUp()
    {
        startDrag = false;
    }
}
