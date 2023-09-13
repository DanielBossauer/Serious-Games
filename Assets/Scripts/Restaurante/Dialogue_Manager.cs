using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using PixelCrushers.DialogueSystem.UnityGUI;
using PixelCrushers.DialogueSystem;
using System.IO;
using System.Linq;


public class Dialogue_Manager : MonoBehaviour
{
    public Queue<DialogueObject> dialogueQueue = new Queue<DialogueObject>();
    public GameObject rightNameTag;
    public GameObject leftNameTag;
    public GameObject dialogPanel;
    public GameObject questionOptions;
    public GameObject defaultButton;
    public GameObject content;
    bool itsTheNext = false;

    string[] toCheck = new string[] {
                "I'm sorry I'm not as pretty as other girls.",
                "I know I'm not your first choice. You'd probably rather be with someone better.",
                "I hope we can still have a good time together, even if you might find someone better.",
                "I apologize for not having any hobbies to talk about.",
                "I'm sorry if there's someone else you'd rather be here with.",
                "Do you think being more confident would make a difference?",
                "I'm sorry I was late.",
                "I'm sorry if I somehow acted inappropriately. I don't always realize it.",
                "Why can't the world be like a dating sim, where the answers are always obvious?",
                "Oh, you probably wouldn't like me if you saw me at home.",
                "I'm sorry for talking too much."};

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
        // Hole das nächste DialogueObject aus der Queue
        DialogueObject dialogue = dialogueQueue.Dequeue();
        if (dialogue != null && dialogue.text[0] == "Oh, no he calls.")
        {
            itsTheNext = true;
        }
        if (dialogue != null && toCheck.Contains(dialogue.text[0]))
        {
            Debug.Log("Visited");
            DialogueUtility util = GetComponent<DialogueUtility>();
            DialogObjectPath path = util.dialog.kirasAnswer(dialogue.text[0]);
            util.addPath(path);
            for (int i = 0; i < path.dialogObjects.Length; i++)
            {
                DialogueObject currentDialog = path.dialogObjects[i];
                AddDialogue(currentDialog);
            }
            itsTheNext = false;
        }
        if (dialogue == null)
        {
            // Queue ist leer, beende den Dialog
            Debug.Log("End of dialogue.");
            return;
        }

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

