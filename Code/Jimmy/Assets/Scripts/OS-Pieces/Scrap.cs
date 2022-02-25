using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrap : MonoBehaviour , IClickable
{
    private Vector3 scaleInBag = new Vector3(20f ,20f ,20f) , scaleInScene = new Vector3(70f , 70f , 70f);

    [Header("贴纸缩略图")]
    public Sprite smallSprite;

    [Header("贴纸放大图")]
    public Sprite bigSprite;

    private SpriteRenderer spriteRenderer;

    private DraggableObj draggableObj;
    public Bag bag;
    public int index;
    private Camera mainCamera;
    private LayerMask bagScrapLayer;
    private bool inBagLastTime = true;

    [SerializeField]
    private GameObject itemPicture;

    [Header("item为target的子物体，吸附即显示")]
    public Transform target;

    [Header("勾选复用型贴纸必填")]
    public bool reusable;//可复用的
    [TextArea]
    public string resuableName;

    public ScrapTargetOuter targetOuter;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        draggableObj = GetComponent<DraggableObj>();
        bag = GameObject.Find("Bag").GetComponent<Bag>();
        index = bag.FindScrapIndex(this);
        mainCamera = Camera.main;
        bagScrapLayer += LayerMask.GetMask("Scrap");
        bagScrapLayer += LayerMask.GetMask("Bag");
        itemPicture = transform.GetChild(0).gameObject;

        draggableObj.checkAttachPoint = transform.GetChild(0);

        draggableObj.attachPoints.Clear();
        draggableObj.attachPoints.Add(target);
        draggableObj.correctAttachPoint = target;
    }

    private void FixedUpdate() {
        AdjustScale();
        bag.ResetIndex();
    }

    //点按贴纸，使贴纸脱离与bag 的父子关系
    public void OnMouseButtonDown()
    {
        if(reusable)     
            ReuseableMouseDown();
        else
            CommonMouseDown();
    }

    private void CommonMouseDown()
    {
        if(bag.CheckScrap(this))//对于在背包栏中的贴纸
        {
            inBagLastTime = true;
            bag.UseScrap(this);
            bag.CreateEmptyObj(index);
            Debug.Log("普通贴纸拖出背包");
        }
        else
        {
            inBagLastTime = false;
        }
    }

    private void ReuseableMouseDown()
    {
        if(bag.CheckScrap(this) && ! bag.CheckReusableScrapInScene(resuableName))//该复用型贴纸在背包中 且 场景中没有该复用型贴纸
        {
            inBagLastTime = true;
            draggableObj.dragSpeed = new Vector2(1 , 1);
            bag.UseScrap(this);
            bag.CreateTheScrap(this , index);
            Debug.Log("复用型贴纸拖出背包");
            return;
        }
        else if(bag.CheckScrap(this) && bag.CheckReusableScrapInScene(resuableName))
        {
            inBagLastTime = true;
            draggableObj.dragSpeed = Vector2.zero;
            return;
        }
        else
        {
            inBagLastTime = false;
            draggableObj.dragSpeed = new Vector2(1 , 1);
            return;
        }
    }

    public void OnMouseButtonUp()
    {
        bool dragInBag = false , dragOnScrap = false;
        GameObject otherScrap = null;

        RaycastHit2D[] hitRes = Physics2D.CircleCastAll(mainCamera.ScreenToWorldPoint(Input.mousePosition), 
            0.2f, Vector2.zero, 200 , bagScrapLayer);

        foreach(var obj in hitRes)
        {
            if(obj.collider.gameObject.layer == 10)//bag的layer
                dragInBag = true;
            
            if(obj.collider.gameObject.layer == 9 && obj.collider.gameObject != this.gameObject)//scrap的layer
            {
                dragOnScrap = true;
                otherScrap = obj.collider.gameObject;
            }
        }
        //以上为检测//以下为判断

        if(reusable)
        {
            if(!inBagLastTime && dragInBag)
            {
                Destroy(this.gameObject);
            }
            else if(!bag.CheckScrap(this)  && draggableObj.CorrectlyPlaced)//正确吸附
            {
                SetActiveItems(true);
                if (!targetOuter || targetOuter.OuterCheck())
                    Destroy(this.gameObject);
                else
                    SetActiveItems(false);
            }
        }
        else
        {
            if(inBagLastTime && dragInBag && dragOnScrap)
            {
                bag.SwapPos(this , otherScrap.GetComponent<Scrap>());
                Debug.Log("交换俩贴纸栏位");
            }
            else if(dragInBag)
            {
                bag.BackToBag(this);
                Debug.Log("放回空栏位");
            }
            else if(draggableObj.CorrectlyPlaced)//正确吸附
            {
                SetActiveItems(true);
                if (!targetOuter || targetOuter.OuterCheck())
                    Destroy(this.gameObject);
                else
                    SetActiveItems(false);
            }
        }

        bag.ClearEmpty();
        bag.ResetIndex();
    }


    //吸附成功后生成物体
    public void SetActiveItems(bool val)
    {
        for (var i = 0; i < target.childCount; i++)
        {
            target.GetChild(i).gameObject.SetActive(val);//激活target下的所有子物体
        }
    }
    

    private void AdjustScale()
    {
        RaycastHit2D[] hitRes = Physics2D.CircleCastAll(transform.position, 0.2f, Vector2.zero, 200 , bagScrapLayer);

        foreach(var obj in hitRes)
        {
            if(obj.collider.gameObject.layer == 10)//bag的layer
            {
                transform.localScale = scaleInBag;
                spriteRenderer.sprite = smallSprite;
                return ;
            }
        }

        transform.localScale = scaleInScene;
        spriteRenderer.sprite = bigSprite;
    }

}
