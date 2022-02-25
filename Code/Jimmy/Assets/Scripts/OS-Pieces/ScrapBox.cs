using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapBox : MonoBehaviour 
{
    [Header("子物体即为对应的贴纸,代码中获取,无需拖拽")]
    public List<GameObject> scraps;
    private Bag bag;

    private void Awake() {

        for (var i = 0; i < transform.childCount; i++)
        {
            scraps.Add(transform.GetChild(i).gameObject);
        }

        bag = GameObject.FindObjectOfType<Bag>().GetComponent<Bag>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && transform.childCount != 0)
        {
            foreach(var scrapObj in scraps)
            {
                scrapObj.SetActive(true);
                bag.GetScrap(scrapObj);
                bag.ResetIndex();
            }

            Debug.Log("已获得对应贴纸");
        }
    }


}
