using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : InteractableObj
{
    [Header("子物体即为对应的贴纸,代码中获取,无需拖拽")]
    public List<GameObject> scraps;
    private Bag bag;

    public GameObject scrap;

    protected override void Start()
    {
        base.Start();

        for (var i = 0; i < transform.childCount; i++)
        {
            scraps.Add(transform.GetChild(i).gameObject);
        }

        bag = GameObject.FindObjectOfType<Bag>().GetComponent<Bag>();
    }
    // 由动画调用
    public void GenerateObject()
    {
        if (transform.childCount != 0)
        {
            foreach (var scrapObj in scraps)
            {
                scrapObj.SetActive(true);
                bag.GetScrap(scrapObj);
                bag.ResetIndex();

                GameObject o = Instantiate(scrap);
                o.transform.position = transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.6f, 0.1f));
                o.GetComponent<SpriteRenderer>().sprite = scrapObj.GetComponent<Scrap>().smallSprite;

            }
            if (GameManager1_3.Instance)
                GameManager1_3.Instance.OnVinePicked();

            Debug.Log("已获得对应贴纸");
        }
    }
    protected override void PlayAnim()
    {
        Debug.Log("Player box anim");
    }
    protected override void DoInteract(StateMachine fsm)
    {
        fsm.SwitchState("SeekState");
        GenerateObject();
        PlayAnim();
    }
}
