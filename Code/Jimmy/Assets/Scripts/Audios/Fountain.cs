using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : MonoBehaviour
{
    [SerializeField]
    public AK.Wwise.Event fountain;


    private void Start()
    {
        fountain.Post(gameObject);

    }
    private void OnDisable()
    {
        fountain.Stop(gameObject);
    }
}
