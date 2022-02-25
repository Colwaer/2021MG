using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM1_3 : MonoBehaviour
{

    [SerializeField]
    public AK.Wwise.Event bgm;
    [SerializeField]
    public AK.Wwise.Event fountain;
    

    private void Start()
    {

        bgm.Post(gameObject);
        fountain.Post(gameObject);

    }

    private void OnDisable()
    {
        bgm.Stop(gameObject);
        fountain.Stop(gameObject);
    }
}
