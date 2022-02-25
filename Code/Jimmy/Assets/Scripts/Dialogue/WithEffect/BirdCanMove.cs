using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCanMove : DiaWithEffect
{
    public override void Effect()
    {
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<CPlayer>();
        player.enabled = true;
    }
}
