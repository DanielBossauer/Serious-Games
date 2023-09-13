using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using PixelCrushers.DialogueSystem;
using UnityEngine.SceneManagement;

public class DialogueUtility : MonoBehaviour
{
    private Dialogue_Manager dialogueManager;
    private DialogObjectPath path;
    public dialogs dialog;

    private void Start()
    {
        dialogueManager = GetComponent<Dialogue_Manager>();
        dialog = new dialogs();
        path = dialog.GetStartDialog();
        for (int i = 0; i < path.dialogObjects.Length; i++)
        {
            DialogueObject currentDialog = path.dialogObjects[i];
            dialogueManager.AddDialogue(currentDialog);
        }
        dialogueManager.ShowNextDialogue();
    }

    public void addPath(DialogObjectPath newPath)
    {
        path = newPath;
    }

    public void SplitAndEnqueue(int choiceIndex)
    {
        if (path.choicePaths == null)
        {
            Debug.Log("Visited: " + choiceIndex);
            int len = path.dialogObjects.Length;
            string roseText = path.dialogObjects[0].text[choiceIndex];
            path = dialog.kirasAnswer(roseText);
        } else { path = path.choicePaths[choiceIndex]; }
        Debug.Log("Visited Bug");
        
        if (path.dialogObjects.Length == 0)
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

        for (int i = 0; i < path.dialogObjects.Length; i++)
        {
            DialogueObject currentDialog = path.dialogObjects[i];
            dialogueManager.AddDialogue(currentDialog);
        }
        dialogueManager.ShowNextDialogue();
    }
}
