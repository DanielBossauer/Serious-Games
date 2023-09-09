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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (correctChoices >= correctTextsPhase1.Count - 1)
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
        DialogueManager.StopAllConversations();

        correctChoices = 0;

        //randomly shuffle words appearing array
        textsInternal = new List<string>();
        foreach (string s in textsPhase1)
        {
            if(s != null && s != "") textsInternal.Add(s);
        }
        
        RandomShuffle.Shuffle<String>(textsInternal);

        running = true;
        internalObjects = new List<WordsAppearingObjects>();

        minigamePhase = StartWordsMinigamePhase1;

        StartCoroutine(SpawnWords());

        
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
                if (correctTextsPhase1.Contains(textsInternal[index]))
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
