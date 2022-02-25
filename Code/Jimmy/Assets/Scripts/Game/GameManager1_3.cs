using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class GameManager1_3 : Singleton<GameManager1_3>
{
    private Giant giant;
    public GameObject firstPupil;
    public GameObject secondPupil;
    public GameObject thirdPupil;

    public GameObject backWall;
    public GameObject curtain;

    public GameObject scrap;
    public Transform scrapSpawnPos;

    private List<GameObject> scraps = new List<GameObject>();

    private TransportFromAToB transportFromAToB;

    private Bag bag;

    private bool GiantShown = false;

    public GameObject tearableWall;



    protected override void Awake()
    {
        base.Awake();


        bag = GameObject.FindObjectOfType<Bag>().GetComponent<Bag>();
        giant = GameObject.FindObjectOfType<Giant>();
        transportFromAToB = GameObject.FindObjectOfType<TransportFromAToB>();

        for (var i = 0; i < transform.childCount; i++)
        {
            scraps.Add(transform.GetChild(i).gameObject);
        }
    }



    public void OnFistPupilShown()
    {
        giant.SwitchState(GiantState.ChasePupil);
        firstPupil.SetActive(true);

    }

    public void OnThirdPupilShown()
    {
        thirdPupil.SetActive(true);

        if (transform.childCount != 0)
        {
            foreach (var scrapObj in scraps)
            {
                scrapObj.SetActive(true);
                bag.GetScrap(scrapObj);
                bag.ResetIndex();

                GameObject o = Instantiate(scrap);
                o.AddComponent<Rigidbody2D>();
                o.AddComponent<BoxCollider2D>();
                o.transform.position = scrapSpawnPos.position;
                o.GetComponent<SpriteRenderer>().sprite = scrapObj.GetComponent<Scrap>().smallSprite;
            }
        }
    }

    public void OnEnterSecondFloor()
    {
        Vector2 originPos = transportFromAToB.targetPos.position;
        transportFromAToB.index = 1;
        transportFromAToB.hasUpdate = true;

    }

    public void OnSecondPupilShown()
    {
        secondPupil.SetActive(true);
    }

    public void OnVinePicked()
    {
        if (!GiantShown)
        {
            GiantShown = true;
            giant.ShowUpAndShout();
        }
        
    }
    public void OnFallingFromLadder()
    {
        tearableWall.SetActive(true);
        backWall.SetActive(true);
    }

    public void OnBackWallShown()
    {
        Debug.Log("BackwallDown");
        MySceneManager.Instance.EnterScene(5);
        //curtain.SetActive(true);
    }
}
