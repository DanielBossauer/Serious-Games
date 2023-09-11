using PixelCrushers.DialogueSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsAppearingMinigame : MonoBehaviour
{

    bool running;

    [SerializeField] WordsAppearingObjects wordsAppearingPrefab;

    [SerializeField] List<string> textsPhase1;

    [SerializeField] List<string> correctTextsPhase1;

    [SerializeField] LerpManager lerpManager;

    [SerializeField] Canvas canvas;

    List<string> textsInternal;

    List<WordsAppearingObjects> internalObjects;

    [SerializeField] string nextCoversation;

    [SerializeField] BackToTherapist2 backToTherapist2;

    int correctChoices;

    [SerializeField] string failConvo1 = "Fail1";

    [SerializeField] delegate void MinigamePhase();
    MinigamePhase minigamePhase;

    [SerializeField] List<string> textsPhase2;
    [SerializeField] List<string> correctTextsPhase2;

    [SerializeField] List<string> textsPhase3;
    [SerializeField] List<string> correctTextsPhase3;

    [SerializeField] List<string> textsPhase4;
    [SerializeField] List<string> correctTextsPhase4;

    List<string> correctTextsPhase;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (correctTextsPhase != null && correctChoices >= correctTextsPhase.Count - 1)
        {
            AllCorrectChoices();
        }
    }

    public void SetNextConversation(string convo)
    {
        DialogueManager.StopAllConversations();
        nextCoversation = convo;
    }

    public void StartWordsMinigamePhase1()
    {
        correctTextsPhase = correctTextsPhase1;
        StartWordsMinigame(1, StartWordsMinigamePhase1);
    }

    void StartWordsMinigame(int phase, MinigamePhase minigamePhase)
    {
        DialogueManager.StopAllConversations();

        correctChoices = 0;

        //randomly shuffle words appearing array
        textsInternal = new List<string>();
        if (phase == 1)
        {
            foreach (string s in textsPhase1)
            {
                if (s != null && s != "") textsInternal.Add(s);
            }
        }
        else if (phase == 2)
        {
            foreach (string s in textsPhase2)
            {
                if (s != null && s != "") textsInternal.Add(s);
            }
        }
        else if (phase == 3)
        {
            foreach (string s in textsPhase3)
            {
                if (s != null && s != "") textsInternal.Add(s);
            }
        }
        else if (phase == 4)
        {
            foreach (string s in textsPhase4)
            {
                if (s != null && s != "") textsInternal.Add(s);
            }
        }


        RandomShuffle.Shuffle<String>(textsInternal);

        running = true;
        internalObjects = new List<WordsAppearingObjects>();

        this.minigamePhase = minigamePhase;

        StartCoroutine(SpawnWords());
    }

    public void StartWordsMinigamePhase2()
    {
        correctTextsPhase = correctTextsPhase2;
        nextCoversation = "New Conversation 4";
        StartWordsMinigame(2, StartWordsMinigamePhase2);
    }

    public void StartWordsMinigamePhase3()
    {
        correctTextsPhase = correctTextsPhase3;
        nextCoversation = "New Conversation 8";
        StartWordsMinigame(3, StartWordsMinigamePhase3);
    }

    public void StartWordsMinigamePhase4()
    {
        correctTextsPhase = correctTextsPhase4;
        nextCoversation = "New Conversation 9";
        StartWordsMinigame(4, StartWordsMinigamePhase4);
    }



    IEnumerator SpawnWords()
    {
        int index = 0;

        while (running)
        {
            if (index >= textsInternal.Count)
            {
                index = 0;
                //reshuffle list
                RandomShuffle.Shuffle<String>(textsInternal);
            }
            if (textsInternal[index] != null || textsInternal[index] != "")
            {

                WordsAppearingObjects word = Instantiate(wordsAppearingPrefab);
                internalObjects.Add(word);
                word.transform.SetParent(canvas.transform);
                word.transform.position = new Vector3(UnityEngine.Random.Range(Screen.width * 0.2f, Screen.width * 0.8f), UnityEngine.Random.Range(Screen.height * 0.2f, Screen.height * 0.8f), 1f);

                word.SetText(textsInternal[index]);
                if (correctTextsPhase.Contains(textsInternal[index]))
                {
                    word.SetCorrect(true);
                }
                else
                {
                    word.SetCorrect(false);
                }
                //word.SetLerpManager(lerpManager);
                word.StartFading();
                word.SetMinigame(this);

                yield return new WaitForSeconds(UnityEngine.Random.Range(1, 5));
            }
            
            index++;
            yield return new WaitForEndOfFrame();
        }
    }

    public void RemoveTextOutOfInternal(string text)
    {
        textsInternal.Remove(text);

        //index = 0;
        //reshuffle list
        //RandomShuffle.Shuffle<String>(textsInternal);

        correctChoices++;
    }

    public void RemoveObjectOutOfInternal(WordsAppearingObjects o)
    {
        if(o != null)
        {
            internalObjects.Remove(o);
        }
    }


    public void EndWordsMinigame()
    {
        if (running)
        {
            running = false;
            foreach (WordsAppearingObjects wordObject in internalObjects)
            {
                if (wordObject != null) Destroy(wordObject.gameObject);
            }

            DialogueManager.StopAllConversations();
            DialogueManager.StartConversation("New Conversation 1");
            DialogueManager.StopAllConversations();
            backToTherapist2.GetComponent<DialogueSystemTrigger>().conversation = nextCoversation;
            backToTherapist2.GetComponent<DialogueSystemTrigger>().OnUse();
        }
    }

    void AllCorrectChoices()
    {
        EndWordsMinigame();
    }

    public void WrongChoice()
    {
        if (running)
        {
            running = false;
            foreach (WordsAppearingObjects wordObject in internalObjects)
            {
                if (wordObject != null) Destroy(wordObject.gameObject);
            }

            DialogueManager.StopAllConversations();
            DialogueManager.StartConversation("New Conversation 1");
            DialogueManager.StopAllConversations();
            DialogueManager.StartConversation(failConvo1);
            //backToTherapist2.GetComponent<DialogueSystemTrigger>().conversation = failConvo1;
            //backToTherapist2.GetComponent<DialogueSystemTrigger>().OnUse();
        }
    }

    public void RestartMinigameAfterFail()
    {
        minigamePhase();
    }





}
