using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapMinigame : MonoBehaviour
{

    SwapMinigameButton previouslyClickedButton;

    bool swapMinigameRunning;

    [SerializeField] Canvas swappingCanvas;

    [SerializeField] string nextConvo;

    [SerializeField] BackToTherapist2 backToTherapist2;

    [SerializeField] SwapMinigameButton[] allButtons;

    [SerializeField] Image blueHideScreen;

    // Start is called before the first frame update
    void Start()
    {
        swappingCanvas.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClicked(SwapMinigameButton swapMinigameButton)
    {
        if(previouslyClickedButton == null || previouslyClickedButton == swapMinigameButton)
        {
            previouslyClickedButton = swapMinigameButton;
        }
        else
        {
            SwapButtons(swapMinigameButton);

            if (CheckPositions())
            {
                CallNextDialogue();
            }
        }
    }

    void SwapButtons(SwapMinigameButton button)
    {
        Vector3 tmp = button.gameObject.transform.position;
        int tmpInt = button.GetCurrentPosition();

        button.gameObject.transform.position = previouslyClickedButton.gameObject.transform.position;
        button.SetCurrentPosition(previouslyClickedButton.GetCurrentPosition());

        previouslyClickedButton.gameObject.transform.position = tmp;
        previouslyClickedButton.SetCurrentPosition(tmpInt);

        previouslyClickedButton.Deselect();

        previouslyClickedButton = null;

        button.Deselect();
    }

    bool CheckPositions()
    {
        foreach (SwapMinigameButton button in allButtons)
        {
            Debug.LogWarning(button.GetCurrentPosition() + " " + button.rightPosition);
            if (!button.CheckPosition())
            {
                Debug.LogWarning("false");
                return false;
            }
        }
        Debug.LogWarning("true");
        return true;
    }

    public void StartSwapGame()
    {
        if (!swapMinigameRunning)
        {
            DialogueManager.StopAllConversations();

            ShufflePositions();

            blueHideScreen.gameObject.SetActive(false);

            swapMinigameRunning = true;
            swappingCanvas.gameObject.SetActive(true);

            foreach (SwapMinigameButton button in allButtons)
            {
                button.MakeClickable();
            }
        }
        
    }

    void CallNextDialogue()
    {
        if (swapMinigameRunning)
        {
            blueHideScreen.gameObject.SetActive(false);

            foreach (SwapMinigameButton button in allButtons)
            {
                button.MakeUnClickable();
            }

            swapMinigameRunning = false;
            swappingCanvas.gameObject.SetActive(false);

            backToTherapist2.ShowFilledIn();

            DialogueManager.StopAllConversations();
            backToTherapist2.gameObject.GetComponent<DialogueSystemTrigger>().conversation = "New Conversation 1";
            backToTherapist2.gameObject.GetComponent<DialogueSystemTrigger>().OnUse();
            DialogueManager.StopAllConversations();
            backToTherapist2.gameObject.GetComponent<DialogueSystemTrigger>().conversation = nextConvo;
            backToTherapist2.gameObject.GetComponent<DialogueSystemTrigger>().OnUse();
        }
            
    }

    public void NullifyButton(SwapMinigameButton button)
    {
        previouslyClickedButton = null;
    }

    public void ShufflePositions()
    {
        for(int i = 0; i < 20; i++)
        {
            int tmpIndex = Random.Range(0, allButtons.Length);
            SwapMinigameButton tmp = allButtons[tmpIndex];

            int tmpIndex2 = Random.Range(0, allButtons.Length);
            SwapMinigameButton tmp2 = allButtons[tmpIndex2];

            previouslyClickedButton = tmp;

            SwapButtons(tmp2);
        }
    }
}
