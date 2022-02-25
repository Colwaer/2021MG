using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaWithEffect : MonoBehaviour , IClickable
{
    public List<GameObject> nextBubble = new List<GameObject>();

    [Header("自己自动消失，不用把自己拖进来")]
    public List<GameObject> delObjs = new List<GameObject>();
    
    public void OnMouseButtonDown()
    {
        //PlaySound();

        Effect();

        foreach(var bubble in nextBubble)
            bubble.SetActive(true);

        foreach(var obj in delObjs)
            obj.SetActive(false);

        this.gameObject.SetActive(false);
    }
    public void OnMouseButtonUp()
    {}

    //若有特殊效果，就继承此脚本并重写该函数
    public virtual void Effect()
    {

    }



}
