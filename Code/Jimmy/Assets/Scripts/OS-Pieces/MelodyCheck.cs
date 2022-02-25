using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelodyCheck : MonoBehaviour
{
    public List<DraggableObjPlus> drags = new List<DraggableObjPlus>();
    public AK.Wwise.Event sound;
    public AK.Wwise.Event totalSound;
    public float delay = 2.1f;

    public Player2_2 player;

    private Animator anim;
    [TextArea]
    public string animName;

    bool soundPlayed = false;

    static int index = 0;

    private void Awake() {
        anim = this.transform.parent.GetComponent<Animator>();
    }

    private void Update() 
    {
        

        if(CheckCondition())
        {
            foreach(var drag in drags)
            {
                drag.limitDragArea = false;
                drag.enabled = false;
            }
            index++;
            anim.Play(animName);
            sound.Post(gameObject);
            if (index == 4)
            {
                StartCoroutine(ICount());
            }
            player.PlayAnim();
            Debug.Log("Sound Played: " + sound);
            this.enabled = false;
        }
    }
    IEnumerator ICount()
    {
        float timer = 0f;
        while  (timer < delay)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        totalSound.Post(gameObject);
       
    }
    //检测条件-所有东西都被正确吸附了
    private bool CheckCondition()
    {
        foreach(var drag in drags)
            if( ! drag.CorrectlyPlaced)
                return false;

        return true;
    }
}
