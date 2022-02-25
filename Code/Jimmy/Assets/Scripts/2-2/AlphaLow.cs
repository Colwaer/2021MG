using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaLow : MonoBehaviour
{
    public GameObject dialogue;
    public float decreaseVal = 3.0f;

    float animationTime = 10.0f;
    float timer = 0f;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void Update() {

        timer += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.E))
        {
            timer -= decreaseVal;
            if (timer < 0)
                timer = 0;
            animator.Play("alphaPlus" , 0 , timer / animationTime);
            dialogue.SetActive(false);
        }
    }

    //动画事件
    public void ShowDia()
    {
        dialogue.SetActive(true);
    }
}
