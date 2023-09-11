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

    [SerializeField] BackToTherapist2 backToTherapist2;

    [SerializeField] string[] textsChoice2;
    [SerializeField] List<string> correctTextsChoice2;

    [SerializeField] string[] textsChoice3;
    [SerializeField] List<string> correctTextsChoice3;

    string[] textsChoice;
    List<string> correctTextsChoice;

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
        if(choicesMinigameRunning && correctChoicesMade > correctTextsChoice.Count - 1)
        {
            EndChoicesMinigame();
        }
    }

    void StartChoices()
    {
        correctChoicesMade = 0;

        if (skipMinigameDebug)
        {
            EndChoicesMinigame();
            return;
        }

        DialogueManager.StopAllConversations();

        choicesInCanvas = new List<MinigameChoice>();

        textsInternal = new List<string>();
        foreach (string s in textsChoice)
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
            if (correctTextsChoice.Contains(s))
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

    void AddToScrollingList(MinigameChoice m)
    {
        choicesInCanvas.Add(m);
        m.transform.SetParent(canvas.transform.GetChild(0).transform.GetChild(0));
    }

    void RemoveFromScrollingList(MinigameChoice m)
    {
        choicesInCanvas.Remove(m);
        m.transform.SetParent(null);
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
        if (choicesMinigameRunning)
        {
            choicesMinigameRunning = false;
            canvas.gameObject.SetActive(false);

            List<MinigameChoice> tmpList = new List<MinigameChoice>();
            foreach (MinigameChoice c in choicesInCanvas)
            {
                tmpList.Add(c);
            }

            foreach (MinigameChoice c in tmpList)
            {
                RemoveFromScrollingList(c);
            }

            DialogueManager.StopAllConversations();
            backToTherapist2.gameObject.GetComponent<DialogueSystemTrigger>().conversation = "New Conversation 1";
            backToTherapist2.gameObject.GetComponent<DialogueSystemTrigger>().OnUse();
            DialogueManager.StopAllConversations();
            backToTherapist2.gameObject.GetComponent<DialogueSystemTrigger>().conversation = nextConvo;
            backToTherapist2.gameObject.GetComponent<DialogueSystemTrigger>().OnUse();
            //DialogueManager.StartConversation(nextConvo);
        }

    }
}
