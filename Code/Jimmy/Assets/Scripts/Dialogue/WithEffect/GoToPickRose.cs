using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPickRose : DiaWithEffect
{
    public Animator JimmyAnim;
    public override void Effect()
    {
        JimmyAnim.Play("fade");
    }

}
