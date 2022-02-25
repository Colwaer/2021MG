using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportFromAToB : MonoBehaviour
{
    public Transform targetPos;

    private float[] yPos = { -3f, -3f, -3f };


    public int index = 0;


    public bool hasUpdate = false;

    private float updateTime = 15f;
    private float updateTimer = 0f;
    private void Update()
    {
        updateTimer += Time.deltaTime;
        if (updateTimer > updateTime)
        {
            index = Random.Range(0, 2);
            updateTimer = 0f;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("OtherCharacter"))
        {
            

            targetPos.position = new Vector2(targetPos.position.x, yPos[index]);

            Vector2 pos = collision.transform.position;
            pos.x = targetPos.position.x;
            pos.y = targetPos.position.y;
            collision.transform.position = pos;
        }
    }
}
