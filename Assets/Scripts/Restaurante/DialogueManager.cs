using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using PixelCrushers.DialogueSystem.UnityGUI;

public class DialogueManager : MonoBehaviour
{
    public Queue<DialogueObject> dialogueQueue = new Queue<DialogueObject>();
    public GameObject rightNameTag;
    public GameObject leftNameTag;
    public GameObject dialogPanel;
    public GameObject questionOptions;
    public GameObject defaultButton;
    public GameObject content;

    private void Start()
    {
        DialogueObject diaObj = new DialogueObject(false, new string[] { "Sorry I was Late."}, false);
        dialogueQueue.Enqueue(diaObj);
        dialogueQueue.Enqueue(new dialogs().depressionQuestionDialog);
        ShowNextDialogue();
    }

    public void AddDialogue(DialogueObject dialogue)
    {
        dialogueQueue.Enqueue(dialogue);
    }

    public void EnqueueDialogueQueue(Queue<DialogueObject> newQueue)
    {
        dialogueQueue.Clear();

        foreach (DialogueObject dialog in newQueue)
        {
            dialogueQueue.Enqueue(dialog);
        }
    }

    public void ShowNextDialogue()
    {
        if (dialogueQueue.Count == 0)
        {
            // Queue ist leer, beende den Dialog
            Debug.Log("End of dialogue.");
            return;
        }

        // Hole das nächste DialogueObject aus der Queue
        DialogueObject dialogue = dialogueQueue.Dequeue();

        // Aktiviere/deaktiviere die Namens-Tags basierend auf speakerRight
        rightNameTag.SetActive(dialogue.speakerRight);
        leftNameTag.SetActive(!dialogue.speakerRight);

        // Aktiviere/deaktiviere DialogPanel und QuestionOptions basierend auf multipleAnswers
        dialogPanel.SetActive(!dialogue.multipleAnswers);
        questionOptions.SetActive(dialogue.multipleAnswers);

        if (!dialogue.multipleAnswers)
        {
            // Wenn es kein multipleAnswers gibt, zeige den Dialogtext an
            TMPro.TextMeshProUGUI dialogText = dialogPanel.GetComponentInChildren<TMPro.TextMeshProUGUI>();
            dialogText.text = string.Join("\n", dialogue.text);
        }
        else
        {
            if (content != null)
            {
                foreach (Transform child in content.transform)
                {
                    Destroy(child.gameObject);
                }
                int i = 0;
                foreach (string answerText in dialogue.text)
                {
                    GameObject newButton = Instantiate(defaultButton, content.transform);
                    newPath path = newButton.GetComponent<newPath>();
                    path.index = i;
                    path.obj = GetComponent<DialogueUtility>();
                    newButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = answerText;
                    i++;
                }
            }
        }
    }
}

