using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCurtain : MonoBehaviour
{
    public GameObject curtain;

    public void Curtain()
    {
        curtain.SetActive(true);
    }
}
