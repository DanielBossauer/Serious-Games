using PixelCrushers.DialogueSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsAppearingMinigame : MonoBehaviour
{

    bool running;

    [SerializeField] WordsAppearingObjects wordsAppearingPrefab;

    [SerializeField] List<string> texts;

    [SerializeField] List<string> correctTexts;

    [SerializeField] LerpManager lerpManager;

    [SerializeField] Canvas canvas;

    List<string> textsInternal;

    WordsAppearingObjects[] internalObjects;

    [SerializeField] string nextCoversation;

    [SerializeField] BackToTherapist2 backToTherapist2;

    int correctChoices;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNextConversation(string convo)
    {
        nextCoversation = convo;
    }

    public void StartWordsMinigame()
    {
        //randomly shuffle words appearing array
        textsInternal = new List<string>();
        foreach (string s in texts)
        {
            textsInternal.Add(s);
        }
        
        RandomShuffle.Shuffle<String>(textsInternal);

        running = true;
        StartCoroutine(SpawnWords());
    }

    IEnumerator SpawnWords()
    {
        int index = 0;

        while (running)
        {
            if (correctChoices >= correctTexts.Count)
            {
                AllCorrectChoices();
            }


            WordsAppearingObjects word = Instantiate(wordsAppearingPrefab);
            if (index >= textsInternal.Count)
            {
                index = 0;
            }
            word.SetText(textsInternal[index]);
            if (correctTexts.Contains(textsInternal[index]))
            {
                word.SetCorrect(true);
            }
            else
            {
                word.SetCorrect(false);
            }
            word.SetLerpManager(lerpManager);
            word.SetMinigame(this);
            index++;
            yield return new WaitForSeconds(UnityEngine.Random.Range(0,3));
        }
    }

    public void RemoveTextOutOfInternal(string text)
    {
        textsInternal.Remove(text);
        correctChoices++;
    }


    public void EndWordsMinigame()
    {
        running = false;
        foreach (WordsAppearingObjects wordObject in internalObjects)
        {
            Destroy(wordObject);
        }

        backToTherapist2.GetComponent<DialogueSystemTrigger>().conversation = nextCoversation;
        backToTherapist2.GetComponent<DialogueSystemTrigger>().OnUse();
    }

    void AllCorrectChoices()
    {
        EndWordsMinigame();
    }

    public void WrongChoice()
    {
        EndWordsMinigame();
    }





}
