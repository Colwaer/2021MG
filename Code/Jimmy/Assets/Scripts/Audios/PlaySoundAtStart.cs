using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundAtStart : MonoBehaviour
{
    public AK.Wwise.Event[] sounds;


    private void Start()
    {
        foreach (var item in sounds)
        {
            item.Post(gameObject);
        }
    }

    private void OnDisable()
    {
        foreach (var item in sounds)
        {
            item.Stop(gameObject);
        }
    }
}
