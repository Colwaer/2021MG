using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitFromScene : MonoBehaviour
{
    public float speed = 6.0f;

    public bool startExit = false;

    public Vector2 direction = Vector2.up;

    private float time = 5f;
    private float timer = 0f;

    private void Update()
    {
        if (startExit)
        {
            transform.position = transform.position + (Vector3)direction * Time.deltaTime * speed;
        }


        if (startExit)
            timer += Time.deltaTime;
        if (timer >= time)
            Destroy(gameObject);
    }





}
