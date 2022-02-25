using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScrapTargetOuter : MonoBehaviour
{
    public DraggableObjPlus drag;
    protected bool SetActive = false;

    public AK.Wwise.Event sound;

    bool soundPlayed = false;

    private void Update() 
    {
        if (!SetActive)
        {
            CheckCondition();
        }
        else
        {
            if (!soundPlayed)
            {
                soundPlayed = true;
                sound.Post(gameObject);
            }
        }
    }

    //检测条件
    protected abstract void CheckCondition();

    public abstract bool OuterCheck();

}
