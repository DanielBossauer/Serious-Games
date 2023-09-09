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
        if(correctChoicesMade >= correctTextsChoice1.Count - 1)
        {
            EndChoicesMinigame();
        }
    }

    public void StartChoicesMinigame()
    {
        if (skipMinigameDebug)
        {
            EndChoicesMinigame();
            return;
        }

        DialogueManager.StopAllConversations();

        choicesInCanvas = new List<MinigameChoice>();

        textsInternal = new List<string>();
        foreach (string s in textsChoice1)
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
            if (correctTextsChoice1.Contains(s))
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
        canvas.gameObject.SetActive(false);

        DialogueManager.StopAllConversations();
        DialogueManager.StartConversation(nextConvo);
    }
}
