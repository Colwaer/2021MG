using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardWindow : MonoBehaviour
{
    private TearObjStart window;

    private PlayerAwayArea awayArea;

    private bool tearDown = false;

    private void OnEnable()
    {
        awayArea = GetComponentInChildren<PlayerAwayArea>();
        window = GetComponentInChildren<TearObjStart>();
    }


    private void Update()
    {
        if (window.TearDown)
        {
            awayArea.Enable = false;
        }
        else
        {
            awayArea.Enable = true;
        }
    }


}
