using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using PixelCrushers.DialogueSystem;
using UnityEngine.SceneManagement;

public class DialogueUtility : MonoBehaviour
{
    private Dialogue_Manager dialogueManager;
    public DialogObjectPath path;

    private void Start()
    {
        dialogueManager = GetComponent<Dialogue_Manager>();

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
        path = path.choicePaths[choiceIndex];
        for (int i = 0; i < path.dialogObjects.Length; i++)
        {
            DialogueObject currentDialog = path.dialogObjects[i];
            dialogueManager.AddDialogue(currentDialog);
        }
        dialogueManager.ShowNextDialogue();
    }
}
