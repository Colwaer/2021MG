using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapGoToBag : MonoBehaviour
{
    public float waitTime = 0.7f;
    float timer = 0f;


    bool start = false;

    Vector2 bagPos = new Vector2(-5.5f, 8f);
    Vector2 originPos;
    public float moveTime = 1.5f;

    float moveTimer = 0f;

    Fade fade;

    private void Awake()
    {
        //bagPos = GameObject.Find("BagOuter").transform.position;
        fade = GetComponent<Fade>();
        
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime && !start)
        {
            start = true;
            originPos = transform.position;
        }
            

        if (start)
        {
            moveTimer += Time.deltaTime;

            transform.position = Vector2.Lerp(originPos, bagPos, moveTimer * 2 / (moveTime + moveTimer));
        }
        if (moveTimer >= moveTime - 0.5f)
            fade.StartFade();



    }
}
