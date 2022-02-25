using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class GameManager1_1 : Singleton<GameManager1_1>
{
    public List<ExitFromScene> SetAway;

    public GameObject[] SetActive;

    public DialogueData_SO nextDialog;

    public TearObj tearObj;

    DialogueController dialogueController;
    protected override void Awake()
    {
        base.Awake();

        dialogueController = GameObject.FindGameObjectWithTag("Player").GetComponent<DialogueController>();
    }
    public void OnPlayerEnter()
    {
        dialogueController.dialogueData = nextDialog;
        dialogueController.ResetDialogIndex();

        dialogueController.ShowCurrentDialog();


        foreach (var item in SetAway)
        {
            item.startExit = true;
        }

        foreach (var item in SetActive)
        {
            item.SetActive(true);

        }
    }
        
    public void LevelComplete()
    {
        MySceneManager.Instance.EnterNextScene();
    }
}
