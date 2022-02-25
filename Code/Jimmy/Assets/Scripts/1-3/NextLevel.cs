using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public GameObject curtain;
    private void OnEnable() {
        Invoke("ShowCurtain" , 2f);
    }

    private void ShowCurtain()
    {
        curtain.SetActive(true);
    }
}
