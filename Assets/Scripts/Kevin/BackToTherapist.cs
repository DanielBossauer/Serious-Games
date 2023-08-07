using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BackToTherapist : MonoBehaviour
{

    [SerializeField] GameObject rectangle;
    [SerializeField] GameObject arrow1;
    [SerializeField] GameObject arrow2;

    [SerializeField] RectanglePart rectangleTop;
    [SerializeField] RectanglePart rectangleRight;
    [SerializeField] RectanglePart rectangleBottom;
    [SerializeField] RectanglePart rectangleLeft;

    [SerializeField] RectangleEdge topLeftArea;
    [SerializeField] RectangleEdge topRightArea;
    [SerializeField] RectangleEdge bottomRightArea;
    [SerializeField] RectangleEdge bottomLeftArea;

    bool gameBegan;
    bool topLeftToTopRightBool;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<DialogueSystemTrigger>().OnUse();
    }

    

    public void ShowRectangle()
    {
        rectangle.SetActive(true);
    }

    public void BackToTheMemories()
    {
        DialogueManager.StopAllConversations();
        Destroy(DialogueManager.instance.gameObject);
        SceneManager.LoadScene("FirstRealFriend");
    }

    public void ShowArrow1()
    {
        arrow1.SetActive(true);
    }

    public void HideArrow1()
    {
        arrow1.SetActive(false);
    }

    public void ShowArrow2()
    {
        arrow2.SetActive(true);
    }

    public void HideArrow2()
    {
        arrow2.SetActive(false);
    }

    public void PrepareBreathingMinigame()
    {
        //DialogueManager.StopAllConversations();
        topLeftArea.gameObject.SetActive(true);
    }

    public void TopLeftToTopRight()
    {
        //DialogueManager.StopAllConversations();

        topLeftArea.gameObject.SetActive(false);
        gameBegan = true;
        topLeftToTopRightBool = true;
        rectangleTop.allowedToPass = true;
        //rectangleRight.allowedToPass = true;
        topRightArea.gameObject.SetActive(true);
        //rectangleRight.time = 3f;
        topRightArea.SetTime(3f);

        rectangleTop.SetMouserOverObject(true);
    }

    void TopRightToBottomRight()
    {
        topLeftToTopRightBool = false;
        rectangleTop.allowedToPass = true;
        rectangleRight.allowedToPass = true;
        //rectangleBottom.allowedToPass = true;
        topRightArea.gameObject.SetActive(false);
        bottomRightArea.gameObject.SetActive(true);
        bottomRightArea.SetTime(3f);
    }


    // Update is called once per frame
    void Update()
    {
        if (gameBegan && topLeftToTopRightBool)
        {
            if (!rectangleTop.CheckForMouseOnTop())
            {
                Debug.Log("MouseIsOffTheRectangle");
                MouseIsOffTheRectangle();
            }

            if (topRightArea.CheckForMouseOnTop() && topRightArea.EnoughTimePassed())
            {
                Debug.Log("TopRightToBottomRight");
                TopRightToBottomRight();
            }
            else if (topRightArea.CheckForMouseOnTop() && !topRightArea.EnoughTimePassed())
            {
                Debug.Log("PlayerTooFast");
                PlayerTooFast();
            }

            /*
            if (rectangleRight.CheckForMouseOnTop() || rectangleBottom.CheckForMouseOnTop() || rectangleLeft.CheckForMouseOnTop())
            {
                PlayerWrongDirection();
            }
            */
        }
    }

    void MouseIsOffTheRectangle()
    {
        if (gameBegan)
        {
            //DialogueManager.StartConversation()
            this.GetComponent<DialogueSystemTrigger>().conversation = "New Conversation 4";
            this.GetComponent<DialogueSystemTrigger>().OnUse();
            gameBegan = false;
        }
        
    }

    void PlayerTooFast()
    {
        if (gameBegan)
        {
            this.GetComponent<DialogueSystemTrigger>().conversation = "New Conversation 5";
            this.GetComponent<DialogueSystemTrigger>().OnUse();
            gameBegan = false;
        }
            
    }

    public void ResetGame()
    {
        gameBegan = false;
        topLeftToTopRightBool = false;
        topLeftArea.gameObject.SetActive(false);
        topRightArea.gameObject.SetActive(false);
        bottomRightArea.gameObject.SetActive(false);
        bottomLeftArea.gameObject.SetActive(false);
    }
}
