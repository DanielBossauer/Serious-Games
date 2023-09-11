using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    bool topRightToBottomRightBool;
    bool bottomRightToBottomLeftBool;
    bool bottomLeftToTopLeftBool;

    bool breathingExplanation;

    [SerializeField] float minimumTime = 2f;

    int breathingRounds = -1;

    [SerializeField] GameObject breatheTextObject;

    [SerializeField] IntrusiveThoughtManager intrusiveThoughtManager;

    [SerializeField] SpriteRenderer background;

    // Start is called before the first frame update
    void Start()
    {
        rectangle.gameObject.SetActive(false);

        this.GetComponent<DialogueSystemTrigger>().OnUse();
    }

    void SetBreathingText(string txt)
    {
        breatheTextObject.gameObject.GetComponent<TextMeshProUGUI>().text = txt;
    }

    public void ShowRectangle()
    {
        rectangle.SetActive(true);
    }

    public void HideRectangle()
    {
        rectangle.SetActive(false);
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
        topRightArea.gameObject.SetActive(false);
        bottomLeftArea.gameObject.SetActive(false);
        bottomRightArea.gameObject.SetActive(false);
    }

    void BreathingExplanation()
    {
        topRightArea.SetMouserOverObject(false);

        topLeftArea.gameObject.SetActive(false);
        bottomLeftArea.gameObject.SetActive(false);
        bottomRightArea.gameObject.SetActive(false);


        topRightToBottomRightBool = false;
        bottomRightToBottomLeftBool = false;
        bottomLeftToTopLeftBool = false;
        topLeftToTopRightBool = false;

        topLeftArea.gameObject.SetActive(false);
        topRightArea.gameObject.SetActive(false);
        bottomLeftArea.gameObject.SetActive(false);
        bottomRightArea.gameObject.SetActive(false);

        breathingExplanation = true;

        this.GetComponent<DialogueSystemTrigger>().conversation = "New Conversation 9";
        this.GetComponent<DialogueSystemTrigger>().OnUse();
    }

    public void TopLeftStart()
    {
        if(!gameBegan)
        {
            DialogueManager.StopAllConversations();

            topRightArea.SetMouserOverObject(false);

            topLeftArea.gameObject.SetActive(false);
            bottomLeftArea.gameObject.SetActive(false);
            bottomRightArea.gameObject.SetActive(false);

            gameBegan = true;

            
            topRightToBottomRightBool = false;
            bottomRightToBottomLeftBool = false;
            bottomLeftToTopLeftBool = false;

            //rectangleTop.allowedToPass = true;
            //rectangleRight.allowedToPass = true;
            topRightArea.gameObject.SetActive(true);
            //rectangleRight.time = minimumTime;
            topRightArea.SetTime(minimumTime);

            topLeftToTopRightBool = true;

            rectangleTop.SetMouserOverObject(true);
        }
        else if (breathingExplanation && breathingRounds == -1)
        {
            breathingRounds = 0;
            TopLeftToTopRight();
            breatheTextObject.SetActive(true);
        }
        
    }

    public void FinalDialogue()
    {
        DialogueManager.StopAllConversations();
        ResetGame();
        rectangle.SetActive(false);
        this.GetComponent<DialogueSystemTrigger>().conversation = "New Conversation 7";
        this.GetComponent<DialogueSystemTrigger>().OnUse();
    }

    public void FinalFinalDialogue()
    {
        DialogueManager.StopAllConversations();
        this.GetComponent<DialogueSystemTrigger>().conversation = "New Conversation 8";
        this.GetComponent<DialogueSystemTrigger>().OnUse();
    }

    void TopLeftToTopRight()
    {

        DialogueManager.StopAllConversations();

        topRightArea.SetMouserOverObject(false);

        topLeftArea.gameObject.SetActive(false);
        bottomLeftArea.gameObject.SetActive(false);
        bottomRightArea.gameObject.SetActive(false);


        topRightToBottomRightBool = false;
        bottomRightToBottomLeftBool = false;
        bottomLeftToTopLeftBool = false;

        if (breathingRounds >= 2)
        {
            gameBegan = false;
            FinalDialogue();
        }
        else
        {
            breatheTextObject.SetActive(true);
            SetBreathingText("Breathe In");

            //rectangleTop.allowedToPass = true;
            //rectangleRight.allowedToPass = true;

            //rectangleRight.time = minimumTime;
            topRightArea.SetTime(minimumTime);

            topRightArea.gameObject.SetActive(true);

            topLeftToTopRightBool = true;

            rectangleTop.SetMouserOverObject(true);
        }
    }

    void TopRightToBottomRight()
    {

        if (breathingRounds >= 0)
        {
            SetBreathingText("Hold your breath");
        }

        bottomRightArea.SetMouserOverObject(false);

        topLeftArea.gameObject.SetActive(false);
        bottomLeftArea.gameObject.SetActive(false);
        topRightArea.gameObject.SetActive(false);

        topLeftToTopRightBool = false;
        topRightToBottomRightBool = true;
        bottomRightToBottomLeftBool = false;
        bottomLeftToTopLeftBool = false;

        //rectangleTop.allowedToPass = true;
        //rectangleRight.allowedToPass = true;
        //rectangleBottom.allowedToPass = true;
        
        
        bottomRightArea.SetTime(minimumTime);

        bottomRightArea.gameObject.SetActive(true);

        rectangleRight.SetMouserOverObject(true);
    }

    void BottomRightToBottomLeft()
    {
        if (breathingRounds >= 0)
        {
            SetBreathingText("Breathe out");
        }

        bottomLeftArea.SetMouserOverObject(false);

        topLeftArea.gameObject.SetActive(false);
        bottomLeftArea.gameObject.SetActive(true);

        topLeftToTopRightBool = false;
        topRightToBottomRightBool = false;
        
        bottomLeftToTopLeftBool = false;

        //rectangleTop.allowedToPass = true;
        //rectangleRight.allowedToPass = true;
        //rectangleBottom.allowedToPass = true;
        topRightArea.gameObject.SetActive(false);
        bottomRightArea.gameObject.SetActive(false);
        bottomLeftArea.SetTime(minimumTime);

        bottomRightToBottomLeftBool = true;

        rectangleBottom.SetMouserOverObject(true);
    }

    void BottomLeftToTopLeft()
    {
        if (breathingRounds >= 0)
        {
            SetBreathingText("Hold your breath");
        }

        topLeftArea.SetMouserOverObject(false);

        topLeftToTopRightBool = false;
        topRightToBottomRightBool = false;
        bottomRightToBottomLeftBool = false;
        
        bottomLeftArea.gameObject.SetActive(false);
        topLeftArea.gameObject.SetActive(true);

        //rectangleTop.allowedToPass = true;
        //rectangleRight.allowedToPass = true;
        //rectangleBottom.allowedToPass = true;
        topRightArea.gameObject.SetActive(false);
        bottomRightArea.gameObject.SetActive(false);
        topLeftArea.SetTime(minimumTime);

        bottomLeftToTopLeftBool = true;

        rectangleLeft.SetMouserOverObject(true);
    }



    bool MouseOnTopCheck()
    {
        if (topLeftToTopRightBool)
        {
            return !rectangleTop.CheckForMouseOnTop() && !topRightArea.CheckForMouseOnTop();
        }
        else if (topRightToBottomRightBool)
        {
            return !rectangleTop.CheckForMouseOnTop() && !bottomRightArea.CheckForMouseOnTop() && !rectangleRight.CheckForMouseOnTop(); //&& !topRightArea.CheckForMouseOnTop() 
        }
        else if (bottomRightToBottomLeftBool)
        {
            return !rectangleBottom.CheckForMouseOnTop() && !bottomLeftArea.CheckForMouseOnTop();
        }
        else if (bottomLeftToTopLeftBool)
        {
            return !rectangleBottom.CheckForMouseOnTop() && !rectangleLeft.CheckForMouseOnTop() && !topLeftArea.CheckForMouseOnTop();
        }

        Debug.LogError("All Stages false");
        return false;
    }

    bool MouseOnWrongRectangle()
    {
        return false;
    }



    // Update is called once per frame
    void Update()
    {
        if (gameBegan && topLeftToTopRightBool)
        {
            if (MouseOnTopCheck())
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

        if (gameBegan && topRightToBottomRightBool)
        {
            if (MouseOnTopCheck()) //&& !topRightArea.CheckForMouseOnTop() 
            {
                Debug.Log("MouseIsOffTheRectangle");
                MouseIsOffTheRectangle();
            }

            if (bottomRightArea.CheckForMouseOnTop() && bottomRightArea.EnoughTimePassed())
            {
                Debug.Log("BottomRightToBottomLeft");
                BottomRightToBottomLeft();
            }
            else if (bottomRightArea.CheckForMouseOnTop() && !bottomRightArea.EnoughTimePassed())
            {
                Debug.Log("PlayerTooFast");
                PlayerTooFast();
            }

        }

        if (gameBegan && bottomRightToBottomLeftBool)
        {
            if (MouseOnTopCheck()) 
            {
                Debug.Log("MouseIsOffTheRectangle");
                MouseIsOffTheRectangle();
            }

            if (bottomLeftArea.CheckForMouseOnTop() && bottomLeftArea.EnoughTimePassed())
            {
                Debug.Log("BottomRightToBottomLeft");
                BottomLeftToTopLeft();
            }
            else if (bottomLeftArea.CheckForMouseOnTop() && !bottomLeftArea.EnoughTimePassed())
            {
                Debug.Log("PlayerTooFast");
                PlayerTooFast();
            }

        }

        if (gameBegan && bottomLeftToTopLeftBool)
        {
            if (MouseOnTopCheck())
            {
                Debug.Log("MouseIsOffTheRectangle");
                MouseIsOffTheRectangle();
            }

            if (topLeftArea.CheckForMouseOnTop() && topLeftArea.EnoughTimePassed())
            {
                Debug.Log("BottomRightToBottomLeft");
                if (!breathingExplanation) BreathingExplanation();
                else
                {

                    TopLeftToTopRight();
                    breathingRounds++;

                }
                
            }
            else if (topLeftArea.CheckForMouseOnTop() && !topLeftArea.EnoughTimePassed())
            {
                Debug.Log("PlayerTooFast");
                PlayerTooFast();
            }

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

            breatheTextObject.SetActive(false);
        }
        
    }

    void PlayerTooFast()
    {
        if (gameBegan)
        {
            this.GetComponent<DialogueSystemTrigger>().conversation = "New Conversation 5";
            this.GetComponent<DialogueSystemTrigger>().OnUse();
            gameBegan = false;

            topLeftArea.gameObject.SetActive(false);
            topRightArea.gameObject.SetActive(false);
            bottomRightArea.gameObject.SetActive(false);
            bottomLeftArea.gameObject.SetActive(false);

            breatheTextObject.SetActive(false);
        }
            
    }

    public void ResetGame()
    {
        gameBegan = false;

        topLeftToTopRightBool = false;
        topRightToBottomRightBool = false;
        bottomRightToBottomLeftBool = false;
        bottomLeftToTopLeftBool = false;

        topLeftArea.gameObject.SetActive(false);
        topRightArea.gameObject.SetActive(false);
        bottomRightArea.gameObject.SetActive(false);
        bottomLeftArea.gameObject.SetActive(false);
    }

    public void CallConvo10()
    {
        StartCoroutine(Convo10());
        Debug.Log("Convo10");
    }

    public IEnumerator Convo10()
    {
        //DialogueManager.StopAllConversations();

        Debug.Log("Convo10");

        background.color = new Color(0.6f, 0.5f, 0.5f);

        StartCoroutine(intrusiveThoughtManager.SpawnIntrusiveThoughts());
        yield return new WaitForSeconds(15);
        intrusiveThoughtManager.StopSpawning();

        background.color = new Color(1f,1f,1f);

        DialogueManager.StopAllConversations();
        this.GetComponent<DialogueSystemTrigger>().conversation = "New Conversation 1";
        this.GetComponent<DialogueSystemTrigger>().OnUse();
        DialogueManager.StopAllConversations();
        this.GetComponent<DialogueSystemTrigger>().conversation = "New Conversation 10";
        this.GetComponent<DialogueSystemTrigger>().OnUse();
    }

    public void CallNextScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (DialogueManager.instance != null)
        {
            DialogueManager.StopAllConversations();
            Destroy(DialogueManager.instance.gameObject);
        }

        SceneManager.LoadScene(sceneIndex + 1);
        
    }
}
