using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceStart : MonoBehaviour
{
    public Fade fade1;
    public Fade fade2;

    public GameObject flyUpArea1;
    public GameObject flyUpArea2;
    private void OnEnable()
    {
        fade1.StartFade();
        fade2.StartFade();
        flyUpArea1.SetActive(false);
        flyUpArea2.SetActive(false);
    }





}
