using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaInReality : MonoBehaviour , IClickable
{
    public List<GameObject> nextBubble = new List<GameObject>();

    [Header("自己过0.5秒自动消失，一般不用把自己拖进来")]
    public List<GameObject> delObjs = new List<GameObject>();
    private Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    public void OnMouseButtonDown()
    {
        PlaySound();

        if(nextBubble.Count != 0)
        {
            foreach(var bubble in nextBubble)
                bubble.SetActive(true);

            foreach(var obj in delObjs)
                obj.SetActive(false);

            if(anim != null)
                anim.Play("fade");

            Invoke("Fade", 1.5f);
        }
        else
        {
            
        }
    }
    public void OnMouseButtonUp()
    {}

    //播放音乐的空函数
    public void PlaySound()
    {

    }

    //本来想做成动画事件的，但是有点麻烦，就用Invoke调用了
    public void Fade()
    {
        this.gameObject.SetActive(false);
    }

}
