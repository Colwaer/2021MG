using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUI : OSButton , IClickable
{
    public GameObject UI;


    public void OnMouseButtonDown()
    {
        UI.SetActive(false);
    }
    
    public void OnMouseButtonUp()
    {

    }
}
