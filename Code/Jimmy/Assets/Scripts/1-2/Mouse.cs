using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    // [Range(1f , 30f)]
    // public float speed = 10f;

    // //老鼠一直向左跑
    // private void Update() {
    //     transform.Translate(Vector3.left * speed * Time.deltaTime);
    // }


    //动画事件，取消激活该游戏对象
    public void DestroyItself()
    {
        this.gameObject.SetActive(false);
    }

    //动画事件
    public void MouseAppear()
    {
        GameManager1_2.instance.OnMouseAppear();
    }

}
