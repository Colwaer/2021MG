using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM1_1 : MonoBehaviour
{

    [SerializeField]
    public AK.Wwise.Event bgm;

    
    private void Start()
    {
        bgm.Post(gameObject);
        
    }
    private void OnDisable()
    {
        bgm.Stop(gameObject);
    }
    private void OnDestroy()
    {
        
    }
}
