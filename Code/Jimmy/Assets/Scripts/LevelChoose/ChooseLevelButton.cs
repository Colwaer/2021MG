using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLevelButton : OSButton , IClickable
{
    public int levelIndex = 0;

    public GameObject curtain;
    protected GameObject inputManager;

    //ChooseLevelButton有选关并跳转的功能
    protected override void Awake() {
        base.Awake();

        inputManager = GameObject.FindObjectOfType<InputManager>().gameObject;
    }

    private void Start() {
        
    }

    public void OnMouseButtonDown()
    {
        curtain.gameObject.SetActive(true);
        curtain.GetComponent<Curtain>().ChooseScene(levelIndex);
        inputManager.SetActive(false);
    }

    public void OnMouseButtonUp()
    {

    }

    
}
