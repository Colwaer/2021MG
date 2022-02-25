using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour, IClickable
{
    public void OnClicked()
    {
        Debug.Log("Onclicked");
    }

    public void OnMouseButtonDown()
    {
        Debug.Log("OnMouseButtonDown");
    }

    public void OnMouseButtonUp()
    {
        Debug.Log("OnMouseButtonUp");
    }
}
