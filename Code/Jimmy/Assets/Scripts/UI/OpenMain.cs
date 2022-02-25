using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMain : OSButton, IClickable
{
    public GameObject UI;


    public void OnMouseButtonDown()
    {
        UI.SetActive(true);
    }

    public void OnMouseButtonUp()
    {
        
    }
}
