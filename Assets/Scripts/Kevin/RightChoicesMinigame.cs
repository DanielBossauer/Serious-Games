using PixelCrushers.DialogueSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightChoicesMinigame : MonoBehaviour
{

    [SerializeField] string[] textsChoice1;
    [SerializeField] List<string> correctTextsChoice1;
    [SerializeField] MinigameChoice minigameChoicePrefab;

    [SerializeField] Canvas canvas;

    bool choicesMinigameRunning;

    int correctChoicesMade;

    List<MinigameChoice> choicesInCanvas;

    List<string> textsInternal;

    [SerializeField] string nextConvo = "New Conversation 3";

    [SerializeField] bool skipMinigameDebug;

<<<<<<< Updated upstream
=======
    [SerializeField] BackToTherapist2 backToTherapist2;

    [SerializeField] string[] textsChoice2;
    [SerializeField] List<string> correctTextsChoice2;

    [SerializeField] string[] textsChoice3;
    [SerializeField] List<string> correctTextsChoice3;

    string[] textsChoice;
    List<string> correctTextsChoice;

>>>>>>> Stashed changes
    private void Awake()
    {
        canvas.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        if(correctChoicesMade >= correctTextsChoice1.Count - 1)
=======
        if(choicesMinigameRunning && correctChoicesMade > correctTextsChoice.Count - 1)
>>>>>>> Stashed changes
        {
            EndChoicesMinigame();
        }
    }

<<<<<<< Updated upstream
    public void StartChoicesMinigame()
    {
=======
    void StartChoices()
    {
        correctChoicesMade = 0;

>>>>>>> Stashed changes
        if (skipMinigameDebug)
        {
            EndChoicesMinigame();
            return;
        }

        DialogueManager.StopAllConversations();

        choicesInCanvas = new List<MinigameChoice>();

        textsInternal = new List<string>();
<<<<<<< Updated upstream
        foreach (string s in textsChoice1)
=======
        foreach (string s in textsChoice)
>>>>>>> Stashed changes
        {
            if (s != null && s != "") textsInternal.Add(s);
        }
        RandomShuffle.Shuffle<String>(textsInternal);

        correctChoicesMade = 0;

        canvas.gameObject.SetActive(true);

        foreach (string s in textsInternal)
        {
            MinigameChoice tmp = Instantiate(minigameChoicePrefab);
            tmp.SetText(s);
            tmp.SetChoicesMinigame(this);
<<<<<<< Updated upstream
            if (correctTextsChoice1.Contains(s))
=======
            if (correctTextsChoice.Contains(s))
>>>>>>> Stashed changes
            {
                tmp.SetCorrect(true);
            }
            else
            {
                tmp.SetCorrect(false);
            }

            AddToScrollingList(tmp);
        }

        choicesMinigameRunning = true;
    }

<<<<<<< Updated upstream
=======
    public void StartChoicesMinigame()
    {
        nextConvo = "New Conversation 3";
        correctTextsChoice = correctTextsChoice1;
        textsChoice = textsChoice1;

        StartChoices();


    }

    public void StartChoicesMinigame2()
    {
        nextConvo = "New Conversation 6";
        correctTextsChoice = correctTextsChoice2;
        textsChoice = textsChoice2;

        StartChoices();


    }

    public void StartChoicesMinigame3()
    {
        nextConvo = "New Conversation 7";
        correctTextsChoice = correctTextsChoice3;
        textsChoice = textsChoice3;

        StartChoices();


    }

>>>>>>> Stashed changes
    void AddToScrollingList(MinigameChoice m)
    {
        choicesInCanvas.Add(m);
        m.transform.SetParent(canvas.transform.GetChild(0).transform.GetChild(0));
    }

    void RemoveFromScrollingList(MinigameChoice m)
    {

    }

    public void SetNextConvo()
    {

    }

    public void WrongChoice(MinigameChoice m)
    {
        foreach (MinigameChoice c in choicesInCanvas)
        {
            if(c != m)
            {
                c.SetHasBeenPressed(false);
            }
        }

        correctChoicesMade = 0;
    }

    public void RightChoice()
    {
        correctChoicesMade++;
    }

    void EndChoicesMinigame()
    {
<<<<<<< Updated upstream
        canvas.gameObject.SetActive(false);

        DialogueManager.StopAllConversations();
        DialogueManager.StartConversation(nextConvo);
=======
        if (choicesMinigameRunning)
        {
            choicesMinigameRunning = false;
            canvas.gameObject.SetActive(false);

            DialogueManager.StopAllConversations();
            backToTherapist2.gameObject.GetComponent<DialogueSystemTrigger>().conversation = "New Conversation 1";
            backToTherapist2.gameObject.GetComponent<DialogueSystemTrigger>().OnUse();
            DialogueManager.StopAllConversations();
            backToTherapist2.gameObject.GetComponent<DialogueSystemTrigger>().conversation = nextConvo;
            backToTherapist2.gameObject.GetComponent<DialogueSystemTrigger>().OnUse();
            //DialogueManager.StartConversation(nextConvo);
        }

>>>>>>> Stashed changes
    }
}
