using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveConstantFromAToB : MonoBehaviour
{
    public float speed = 1.5f;
    public float time = 1.6f;
    public Vector2 direction = Vector2.down;

    float timer = 0f;

    Vector2 originPos;

    private void Awake()
    {
        originPos = transform.position;
    }

    private void Update()
    {
        if (timer < time)
        {
            timer += Time.deltaTime;

            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }
        else
        {
            timer = 0f;

            transform.position = originPos;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, -6f);
    }

}
