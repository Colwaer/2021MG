using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1_2 : MonoBehaviour
{
    public static GameManager1_2 instance;


    public Animator catAnim , guardOuterAnim , giantAnim;

    private void Awake()
    {
        if(instance == null)
			instance = this;
		else
			Destroy(this.gameObject);

        sunPaint = GameObject.Find("SunPaint");
        ChaJi = GameObject.Find("ChaJi");
    }

    private void FixedUpdate() {
        if(! sunLighted && sunPaint.GetComponent<DraggableObjPlus>().Placed)
            LightSun();

    }

    private bool CheckGuardAnim(string animName)
    {
        return guardOuterAnim.GetCurrentAnimatorStateInfo(0).IsName(animName);
    }

    private bool CheckGuardRight()
    {
        if(guardObj.transform.position.x > 0)
            return true;
        return false;
    }
    private bool CheckGuardUp()
    {
        if(guardObj.transform.position.y > 0)
            return true;
        return false;
    }


    [Header("守卫")]
    public GameObject guardObj;

    [Header("一楼楼梯口")]
    public Transform stairTrans;
    public Transform rightPoint , leftPoint;//这样写,偷点懒

    private bool CheckStairRight()
    {
        if(Vector2.Distance(stairTrans.position , rightPoint.position) < 2f)
            return true;
        return false;
    }

    private bool CheckStairLeft()
    {
        if(Vector2.Distance(stairTrans.position , leftPoint.position) < 2f)
            return true;
        return false;
    }

    //老鼠出现后，猫抓老鼠，守卫上楼(老鼠、猫和守卫只会有固定的动作和位移，录制几个动画会很省事)
    public void OnMouseAppear()
    {
        catAnim.Play("CatchMouse");

        //判断加上二楼贴纸没有被撕

        if(! CheckGuardUp())//如果守卫在楼下
        {
            if(CheckGuardRight() && CheckStairRight())//守卫在右侧且楼梯口在右侧
            {
                guardOuterAnim.Play("RightGoUpstair");
            }
            else if(! CheckGuardRight() && CheckStairLeft())//守卫在左侧且楼梯口在左侧
            {
                guardOuterAnim.Play("LeftGoUpstair");
            }
        }
    }

    //闹钟响铃后，守卫下楼
    public void OnClockRing()
    {
        Debug.Log("OnClockRing");

        if(CheckGuardUp())//如果守卫在楼上
        {
            if(CheckStairRight())//楼梯口在右侧
            {
                guardOuterAnim.Play("GoDownstairRight");
            }
            else if(CheckStairLeft())//楼梯口在左侧
            {
                guardOuterAnim.Play("GoDownstairLeft");
            }
        }
    }

    //进入小房间的门后，转场（）
    public void OnEnterSmallRoom()
    {

    }

    //壁炉生火后，巨人入睡，玩家能靠近巨人(巨人只会有固定的动作和位移，录制几个动画会很省事)
    public void OnFireplaceBurned()
    {
        giantAnim.Play("sleep");

        giantAnim.transform.GetChild(0).gameObject.SetActive(false);//关掉PlayerAwayArea
    }

    [Header("二楼画中太阳")]
    public bool sunLighted;
    private GameObject sunPaint;
    public Sprite sun;
    public void LightSun()
    {
        sunLighted = true;
        sunPaint.GetComponent<SpriteRenderer>().sprite = sun;
    }

    public bool SunCorrectlyPlaced()
    {
        return sunPaint.GetComponent<DraggableObjPlus>().CorrectlyPlaced;
    }

    [Header("二楼茶几")]
    private GameObject ChaJi;
    public bool ChaJiCorrectlyPlaced()
    {
        return ChaJi.GetComponent<DraggableObjPlus>().CorrectlyPlaced;
    }


    [Header("一楼吊灯")]
    public GameObject dropLight;
    public bool DropLightCorrectlyPlaced()
    {
        return dropLight.GetComponent<DraggableObjPlus>().Placed;
    }

    [Header("一楼钥匙")]
    public bool getKey = false;
    public Animator gardenGateAnim;
    public void OpenGardenGate()
    {
        gardenGateAnim.Play("open");
    }

    [Header("一楼火焰")]
    public GameObject fire;


}
