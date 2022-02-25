using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableShowUp : MonoBehaviour
{
    [SerializeField]
    public Fade[] showUpList;
    [SerializeField]
    public float duration = 3.0f;



    float timer = 0f;
    bool startCount = false;

    private void OnEnable()
    {
        if (startCount)
            return;

        foreach (var item in showUpList)
        {
            item.gameObject.SetActive(true);
        }
        startCount = true;
    }
    private void Update()
    {
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
    private void OnDisable()
    {
        if (timer < duration)
        {
            foreach (var item in showUpList)
            {
                item.StartFade();
            }
            Destroy(this);
        }
    }

}
