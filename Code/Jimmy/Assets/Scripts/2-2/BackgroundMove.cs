using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public Transform background;
    public Animator animator;
    public float speed;
    bool Moving = false;
    private void Update() {
        if(Input.GetKey(KeyCode.D))
        {
            background.position += new Vector3(Time.deltaTime * speed , 0 , 0 );
            Moving = true;
        }
        else
        {
            Moving = false;
        }
        animator.SetBool("Moving", Moving);
    }
    private void OnDisable()
    {
        animator.SetBool("Moving", false);
    }
}
