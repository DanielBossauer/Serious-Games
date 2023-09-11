using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinigameChoice : MonoBehaviour
{

    bool isCorrectChoice;

    string text;

    bool hasBeenPressed;

    RightChoicesMinigame rightChoicesMinigame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this.gameObject.
    }

    public void SetText(string s)
    {
        this.text = s;
        this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = s;
    }

    public void SetCorrect(bool b)
    {
        isCorrectChoice = b;
    }

    public void SetChoicesMinigame(RightChoicesMinigame rightChoicesMinigame)
    {
        this.rightChoicesMinigame = rightChoicesMinigame;
    }

    public void SetHasBeenPressed(bool b)
    {
        hasBeenPressed = b;
        if(!b) this.gameObject.GetComponent<Image>().color = Color.white;
    }

    public void ButtonPressed()
    {
        if (!hasBeenPressed)
        {
            if (isCorrectChoice)
            {
                this.gameObject.GetComponent<Image>().color = Color.green;
                rightChoicesMinigame.RightChoice();
            }
            else
            {
                this.gameObject.GetComponent<Image>().color = Color.red;
                rightChoicesMinigame.WrongChoice(this);
            }

            SetHasBeenPressed(true);
        }
        
    }
}
