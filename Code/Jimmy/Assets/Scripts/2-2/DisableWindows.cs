using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWindows : MonoBehaviour
{
    public GameObject window , alpha;

    //动画事件
    public void DisableIt()
    {
        window.SetActive(false);
        alpha.SetActive(true);
    }
    
}
