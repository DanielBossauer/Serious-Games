using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToTherapist2 : MonoBehaviour
{

    [SerializeField] GameObject rectangle;
    [SerializeField] GameObject arrow1;
    [SerializeField] GameObject arrow2;

    [SerializeField] RectanglePart rectangleTop;
    [SerializeField] RectanglePart rectangleRight;
    [SerializeField] RectanglePart rectangleBottom;
    [SerializeField] RectanglePart rectangleLeft;

    [SerializeField] GameObject topLeftArea;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<DialogueSystemTrigger>().OnUse();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        DialogueManager.StopAllConversations();
    }

    public void StartConvo(string text)
    {
        DialogueManager.StopAllConversations();
        this.GetComponent<DialogueSystemTrigger>().conversation = text;
        this.GetComponent<DialogueSystemTrigger>().OnUse();
    }

    public void StartConvo1()
    {
        StartConvo("New Conversation 1");
    }

    public void StartConvo2()
    {
        StartConvo("New Conversation 2");
    }

    public void StartConvo3()
    {
        StartConvo("New Conversation 3");
    }

    public void StartConvo4()
    {
        StartConvo("New Conversation 4");
    }

    public void StartConvo5()
    {
        StartConvo("New Conversation 5");
    }

    public void StartConvo6()
    {
        StartConvo("New Conversation 6");
    }

    public void StartConvo7()
    {
        StartConvo("New Conversation 7");
    }

    public void StartConvo8()
    {
        StartConvo("New Conversation 8");
    }

    public void StartConvo9()
    {
        StartConvo("New Conversation 9");
    }

    public void StartConvo10()
    {
        StartConvo("New Conversation 10");
    }

    public void StartConvo11()
    {
        StartConvo("New Conversation 11");
    }

    public void StartConvo12()
    {
        StartConvo("New Conversation 12");
    }

    public void StartConvo13()
    {
        StartConvo("New Conversation 13");
    }

    public void StartConvo14()
    {
        StartConvo("New Conversation 14");
    }
}
