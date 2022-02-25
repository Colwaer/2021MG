using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayEnableChildren : MonoBehaviour
{
    public float enableTime = 0.6f;
    float timer = 0.5f;

    int count;
    int index = 0;

    private void Awake()
    {
        count = transform.childCount;
    }
    private void Update()
    {
        if (timer < enableTime)
        {
            timer += Time.deltaTime;

            


        }
        else
        {
            timer = 0f;

            if (index < count)
            {
                transform.GetChild(index++).gameObject.SetActive(true);
            }
            else
            {
                Destroy(this);
            }
        }
    }


}
