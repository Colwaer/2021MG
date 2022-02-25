using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//获得贴纸时，寻找第一个由空物体占据的栏位，替换之
//把贴纸拖出背包栏时：若为复用型贴纸，则新生成一个贴纸图标占据该栏位；若不是，则生成一个空物体占据之。
//把贴纸放回背包栏时：鼠标射线判定该栏位是否被空物体占据。是，则替换之；否，则寻找第一个由空物体占据的栏位，替换之。

public class Bag : MonoBehaviour
{
    public GameObject emptyObj;
    Image image;
    Color blinkColor = new Color(0.9f, 0.9f, 0.9f);
    Color originColor;
    float blinkInterval = 0.23f;
    int blinkTime = 8;
    IEnumerator _IBlink;
    private void Awake()
    {
        image = GetComponent<Image>();
        originColor = image.color;
    }

    //检查该贴纸是否在背包中
    public bool CheckScrap(Scrap scrap)
    {
        for(var i = 0; i < this.transform.childCount ; i++)
            if(this.transform.GetChild(i).gameObject == scrap.gameObject)
                return true;

        return false;
    }


    //检查该复用型贴纸是否在场景中
    public bool CheckReusableScrapInScene(string name)
    {
        Scrap temp;

        for(var i = 0; i < this.transform.parent.childCount ; i++)
        {
            this.transform.parent.GetChild(i).TryGetComponent<Scrap>(out temp);
            if(temp != null && temp.reusable && temp.resuableName == name)
                return true;
        }

        return false;
    }

    public bool CheckItselfInScene(Scrap itself)
    {
        Scrap temp;

        for(var i = 0; i < this.transform.parent.childCount ; i++)
        {
            this.transform.parent.GetChild(i).TryGetComponent<Scrap>(out temp);

            if(temp == itself)
                return true;
        }
        return false;
    }


    //返回Scrap在Bag中的栏位序号
    public int FindScrapIndex(Scrap scrap)
    {
        for(var i = 0; i < this.transform.childCount ; i++)
            if(this.transform.GetChild(i).gameObject == scrap.gameObject)
                return i;
        
        return 0;
    }

    public int FindEmptyIndex()
    {
        for(var i = 0; i < this.transform.childCount ; i++)
            if(this.transform.GetChild(i).gameObject.CompareTag("EmptyObj"))
                return i;

        return -1;
    }

    public void ClearEmpty()
    {
        for(var i = 0; i < this.transform.childCount ; i++)
        {
            int index = FindEmptyIndex();

            if(index != -1)
                Destroy(this.transform.GetChild(index).gameObject);
        }
    }

    //得到贴纸时、将贴纸放回背包时调用
    public void GetScrap(Scrap scrap , int index)
    {
        scrap.transform.SetParent(this.transform);
        scrap.transform.SetSiblingIndex(index);
    }

    public void GetScrap(GameObject scrapObj)
    {
        if (_IBlink == null)
        {
            _IBlink = IBlink();
            StartCoroutine(_IBlink);
        }


        scrapObj.transform.SetParent(this.transform);
        scrapObj.transform.SetAsLastSibling();
    }
    
    IEnumerator IBlink()
    {
        int i = 0;
        float timer = 0f;

        while (i < blinkTime)
        {
            timer += Time.deltaTime;
            if (timer > blinkInterval)
            {
                timer = 0f;
                i++;
                if (i % 2 == 0)
                {
                    image.color = originColor;
                }
                else
                {
                    image.color = blinkColor;
                }
            }
            yield return null;
        }
        _IBlink = null;
    }

    //将贴纸从背包内拖出时调用
    public void UseScrap(Scrap scrap)
    {
        scrap.transform.SetParent(this.transform.parent);
    }

    //在贴纸被拖入场景中时调用，在Bag下创建一个空物体，并调整它的栏位
    public GameObject CreateEmptyObj(int index)
    {
        var epyobj =  Instantiate(emptyObj , Vector3.zero , Quaternion.identity , this.transform);

        epyobj.transform.SetSiblingIndex(index);

        return emptyObj;
    }


    //创建一个新的复用型贴纸
    public GameObject CreateTheScrap(Scrap scrap , int index)
    {
        var newScrap = Instantiate(scrap.gameObject , Vector3.zero , Quaternion.identity , this.transform);

        newScrap.transform.SetSiblingIndex(index);

        return newScrap;
    }


    public void BackToBag(Scrap scrap)
    {
        int index = FindEmptyIndex();
        GetScrap(scrap , index);
    }

    public void SwapPos(Scrap scrap1 , Scrap scrap2)
    {
        int index1 = scrap1.index , index2 = scrap2.index;
        GetScrap(scrap1 , index2);
        scrap2.transform.SetSiblingIndex(index1);
    }

    public void ResetIndex()
    {
        Scrap temp;

        for(var i = 0; i < this.transform.childCount ; i++)
        {
            this.transform.GetChild(i).TryGetComponent<Scrap>(out temp);

            if(temp != null)
                temp.index = i;
        }
    }




}
