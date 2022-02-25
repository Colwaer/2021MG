using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearableWall : MonoBehaviour
{
    public List<Sprite> sprites;
    private int index = 1;

    public GameObject wallBack;

    private SpriteRenderer sp;
    private TearObjStart tearObjStart;


    bool showNext = true;
    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();

        tearObjStart = GetComponent<TearObjStart>();
    }


    private void OnEnable()
    {
        
    }
    private void Update()
    {
        if (tearObjStart.TearDown)
        {
            GameManager1_3.Instance.OnBackWallShown();
            Destroy(this);
        }
    }








   
}
