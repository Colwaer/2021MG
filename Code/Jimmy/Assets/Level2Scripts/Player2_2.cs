using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_2 : MonoBehaviour
{
    Animator animator;
    float time = 1f;
    float totalTime = 7.1f;
    float timer = 0f;
    int index = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }



    public void PlayAnim()
    {
        if (index != 3)
        {
            index++;
            animator.SetFloat("speed", 0f);
            StartCoroutine(ICount(time));

        }
        else
        {
            StartCoroutine(ICount(15f));
        }
    }
    IEnumerator ICount(float countTime)
    {
        float countTimer = 0f;
        animator.SetFloat("speed", 1f);
        while (countTimer < countTime)
        {
            countTimer += Time.deltaTime;




            yield return null;
        }
        animator.SetFloat("speed", 0f);
    }
    public void StopAnim()
    {
        animator.Play("End");
    }



}
