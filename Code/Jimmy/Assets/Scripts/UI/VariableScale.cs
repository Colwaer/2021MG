using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableScale : MonoBehaviour
{
    public float time = 0.6f;
    public float speed = 0.42f;

    float direction = 1f;
    float timer = 0;
    Vector2 originScale;
    
    private void Awake()
    {
        originScale = transform.localScale;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > time)
        {
            direction *= -1;
            timer = 0f;
        }
        transform.localScale += direction * speed * Vector3.one * Time.deltaTime;
    }



}
