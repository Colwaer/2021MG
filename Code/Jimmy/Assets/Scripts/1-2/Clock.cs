using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    private void OnEnable() {
        GameManager1_2.instance.OnClockRing();
    }

    //动画事件，取消激活该游戏对象
    public void DestroyItself()
    {
        this.gameObject.SetActive(false);
    }

}
