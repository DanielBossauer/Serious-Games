using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordsAppearingObjects : MonoBehaviour
{
    LerpManager lerpManager;
    WordsAppearingMinigame wordsAppearingMinigame;

    bool isCorrect = false;

    string text;

    private void Awake()
    {
        lerpManager.Rect = this.gameObject;
        lerpManager.CALLLerpColorAlphaSimpleTwoWay();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCorrect(bool b)
    {
        isCorrect = b;
    }

    public void SetLerpManager(LerpManager l)
    {
        lerpManager = l;
    }

    public void SetMinigame(WordsAppearingMinigame w)
    {
        wordsAppearingMinigame = w;
    }

    public void SetText(string text)
    {
        this.GetComponent<TextMeshProUGUI>().text = text;
        this.text = text;
    }

    public void Clicked()
    {
        if (!isCorrect)
        {
            wordsAppearingMinigame.WrongChoice();
        }
        else
        {
            wordsAppearingMinigame.RemoveTextOutOfInternal(this.text);
        }
    }
}
