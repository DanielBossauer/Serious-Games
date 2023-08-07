using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class DialogueUtility : MonoBehaviour
{
    private Queue<DialogueObject> dialogueQueue = new Queue<DialogueObject>();
    private DialogueManager dialogueManager;
    public DialogObjectPath path;
    private dialogs dialogs;

    private void Start()
    {
        dialogueManager = GetComponent<DialogueManager>();
        dialogs = new dialogs();
        path = dialogs.depressionQuestions;
    }

    public void SplitAndEnqueue(int choiceIndex)
    {
        if (dialogueQueue.Count == 0)
        {
            path = dialogs.GetNewPath(choiceIndex);
        }
        path = path.choicePaths[choiceIndex];
        Debug.Log("Your Choice: " + path.dialogObjects[0].text[0]);
        for (int i = 0; i < path.dialogObjects.Length; i++)
        {
            DialogueObject currentDialog = path.dialogObjects[i];
            dialogueManager.AddDialogue(currentDialog);
        }
        dialogueManager.ShowNextDialogue();
    }
}
