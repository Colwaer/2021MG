using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Dailogue",menuName ="Dialogue/Dialogue Data")]
public class DialogueData_SO : ScriptableObject
{
    public List<DialoguePiece> dialoguePieces=new List<DialoguePiece>();

    public Dictionary<string, DialoguePiece> dialogueIndex = new Dictionary<string, DialoguePiece>();

    private void OnValidate()
    {
        dialogueIndex.Clear();
        foreach (var piece in dialoguePieces)
        {
            if(!dialogueIndex.ContainsKey(piece.ID))
            {
                dialogueIndex.Add(piece.ID, piece);
            }
        }
    }

    private void Awake()
    {
    
        dialogueIndex.Clear();
        foreach(var piece in dialoguePieces)
        {
            if(!dialogueIndex.ContainsKey(piece.ID))
                dialogueIndex.Add(piece.ID, piece);
        }
    }

}
