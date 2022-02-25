using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeUI : OSButton , IClickable
{
    public GameObject preUI , thisUI , nextUI;

    public void OnMouseButtonDown()
    {
        if(preUI != null)
        {
            thisUI.SetActive(false);
            preUI.SetActive(true);
        }
        else if(nextUI != null)
        {
            thisUI.SetActive(false);
            nextUI.SetActive(true);
        }
    }

    public void OnMouseButtonUp()
    {

    }
}
