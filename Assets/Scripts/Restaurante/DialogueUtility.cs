using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using PixelCrushers.DialogueSystem;
using UnityEngine.SceneManagement;

public class DialogueUtility : MonoBehaviour
{
    private Queue<DialogueObject> dialogueQueue = new Queue<DialogueObject>();
    private Dialogue_Manager dialogueManager;
    public DialogObjectPath path;
    private dialogs dialogs;

    private void Start()
    {
        dialogueManager = GetComponent<Dialogue_Manager>();
        dialogs = new dialogs();
        path = dialogs.depressionQuestions;
    }

    public void SplitAndEnqueue(int choiceIndex)
    {
        if(path.dialogObjects.Length == 0)
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            // Test for existing dialogue manager
            if (DialogueManager.instance != null)
            {
                DialogueManager.StopAllConversations();
                Destroy(DialogueManager.instance.gameObject);
            }
            SceneManager.LoadScene(sceneIndex + 1);
        }
        if (dialogueQueue.Count == 0)
        {
            path = dialogs.GetNewPath(choiceIndex);
        }
        path = path.choicePaths[choiceIndex];
        for (int i = 0; i < path.dialogObjects.Length; i++)
        {
            DialogueObject currentDialog = path.dialogObjects[i];
            dialogueManager.AddDialogue(currentDialog);
        }
        dialogueManager.ShowNextDialogue();
    }
}
