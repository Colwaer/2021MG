using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantDialog1_3 : MonoBehaviour
{
    private DialogueData_SO originDialog;
    public DialogueData_SO replaceDialog;
    private DialogueController dialogueController;
    private void Awake()
    {
        dialogueController = GetComponent<DialogueController>();
        originDialog = dialogueController.dialogueData;
    }
    public void ShowReplaceDialog()
    {
        dialogueController.dialogueData = replaceDialog;
        dialogueController.ResetDialogIndex();
        dialogueController.OnClick();

        StartCoroutine(IChangeToOrigin());

    }
    IEnumerator IChangeToOrigin()
    {
        float timer = 0f;

        while (timer < 1.3f)
        {
            timer += Time.deltaTime;

            yield return null;
        }
        dialogueController.dialogueData = originDialog;
    }
}
