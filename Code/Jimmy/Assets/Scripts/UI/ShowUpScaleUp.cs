using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUpScaleUp : MonoBehaviour
{
    public float time = 0.5f;
    public float speed = 0.3f;


    float timer = 0f;
    private void Update()
    {
        if (timer < time)
        {
            timer += Time.deltaTime;

            transform.localScale += transform.localScale * speed * Time.deltaTime;
        }
    }




}
