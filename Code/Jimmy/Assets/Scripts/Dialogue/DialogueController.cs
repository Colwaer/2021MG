
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour , IClickable
{
    public GameObject tip;
    [Header("把编辑好了的对话数据拖进来")]
    public DialogueData_SO dialogueData;

    [Header("把Canvas拖进来")]
    public GameObject dialogueBubble;
    private Text text;

    [SerializeField]
    private int currentIndex = 0;
    
    [Header("开场显示必选以下选项")]
    public bool showItAtFirst = false;

    Transform parent;
    
    private void Awake() {
        text = dialogueBubble.GetComponentInChildren<Text>();

        parent = transform;
    }

    private void Start() {
        ExitDialogue();

        if(showItAtFirst)
        {
            OpenDialogue();
            Invoke("ShowNextDialogue" , 5f);
        }
    }

    public void OnMouseButtonDown()
    {
        OnClick();
        
        if(tip != null && tip.activeSelf)
        {
            tip.SetActive(false);
        }
    }
    public void OnMouseButtonUp()
    {}

    private void Update()
    {
        if (parent.localScale.x == -1)
            dialogueBubble.transform.localScale = new Vector3(-1, 1, 1);
        else
            dialogueBubble.transform.localScale = Vector3.one;
    }
    //鼠标点击时调用
    public void OnClick()
    {
        if(showItAtFirst)
        {
            return ;
        }

        if( ! dialogueBubble.activeInHierarchy)
        {
            OpenDialogue();
            Invoke("ShowNextDialogue" , 3f);
        }
        else
        {
            ShowNextDialogue();
        }
    }
    public void ResetDialogIndex()
    {
        currentIndex = 0;
    }
    public void OpenDialogue()
    {
        CancelInvoke("ShowNextDialogue");

        currentIndex = 0;

        if(dialogueData != null && dialogueData.dialoguePieces != null && currentIndex < dialogueData.dialoguePieces.Count)
        {
            text.text = dialogueData.dialoguePieces[currentIndex].text;
        }

        dialogueBubble.SetActive(true);
    }
    public void ShowCurrentDialog()
    {
        if (currentIndex < dialogueData.dialoguePieces.Count)
        {
            text.text = dialogueData.dialoguePieces[currentIndex].text;
            Invoke("ShowNextDialogue", 3f);
        }
        else
        {
            ExitDialogue();
            return;
        }
    }
    //注意ShowNextDialogue无法激活Canvas，只有OpenDialogue才能激活Canvas
    public void ShowNextDialogue()
    {
        currentIndex++;

        if(currentIndex < dialogueData.dialoguePieces.Count)
        {
            text.text = dialogueData.dialoguePieces[currentIndex].text;
            Invoke("ShowNextDialogue" , 3f);
        }
        else
        {
            ExitDialogue();
            return ;
        }
    }

    private void ExitDialogue()
    {
        dialogueBubble.SetActive(false);
    }
    
}
