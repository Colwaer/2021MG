using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUIPlus : MonoBehaviour , IClickable
{
    public GameObject UI;
    public void OnMouseButtonDown()
    {
        UI.SetActive(true);
        this.transform.parent.gameObject.SetActive(false);
    }
    public void OnMouseButtonUp()
    {

    }
}
