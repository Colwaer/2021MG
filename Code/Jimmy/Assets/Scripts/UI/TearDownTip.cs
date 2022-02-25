using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearDownTip : MonoBehaviour
{
    public TearObj tear;
    public Fade[] showUpList;
    public float duration = 3.0f;

    float timer = 0f;
    bool startCount = false;


    private void Update()
    {
        if (tear.TearDown && !startCount)
        {
            foreach (var item in showUpList)
            {
                item.gameObject.SetActive(true);
            }
            startCount = true;
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




}
