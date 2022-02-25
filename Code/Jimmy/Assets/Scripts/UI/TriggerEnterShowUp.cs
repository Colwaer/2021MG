using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnterShowUp : MonoBehaviour
{
    public Fade[] showUpList;
    public float duration = 3.0f;



    float timer = 0f;
    bool startCount = false;

    public float delayTime = 0f;
    float delayTimer = 0f;

    bool startDelayCount = false;
    private void Update()
    {
        if (!startDelayCount)
            return;
        else if (!startCount)
        {
            delayTimer += Time.deltaTime;
            if (delayTimer > delayTime)
            {
                foreach (var item in showUpList)
                {
                    item.gameObject.SetActive(true);
                }
                startCount = true;
            }
        }


        if (startCount)
            timer += Time.deltaTime;
        if (timer > duration)
        {
            foreach (var item in showUpList)
            {
                item.StartFade();
            }
            Destroy(this);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            startDelayCount = true;
        }
    }
}
