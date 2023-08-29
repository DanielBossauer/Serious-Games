using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToTherapist2 : MonoBehaviour
{

    //[SerializeField] GameObject rectangle;
    //[SerializeField] GameObject arrow1;
    //[SerializeField] GameObject arrow2;

    //[SerializeField] RectanglePart rectangleTop;
    //[SerializeField] RectanglePart rectangleRight;
    //[SerializeField] RectanglePart rectangleBottom;
    //[SerializeField] RectanglePart rectangleLeft;

    //[SerializeField] GameObject topLeftArea;

    Dictionary<string,string> finalNotebooks;

    [SerializeField] GameObject blueBackground;
    [SerializeField] GameObject[] backgroundToHide;

    [SerializeField] bool debugBool = false;


    List<GameObject> notebookInstancesList = new List<GameObject>();


    [SerializeField] GameObject finalNotebookPrefab;

    [SerializeField] LerpManager[] lerpManagers;

    [SerializeField] FinalNotebookArrow notebookArrowLeft;

    [SerializeField] FinalNotebookArrow notebookArrowRight;

    [SerializeField] FinalNotebookHideButton notebookHideButton;

    FinalNotebookArrow arrowLeftInstance;
    FinalNotebookArrow arrowRightInstance;
    FinalNotebookHideButton hideButtonInstance;

    [SerializeField] GameObject notebookCanvas;


    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<DialogueSystemTrigger>().OnUse();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    public void ShowRectangle()
    {
        rectangle.SetActive(true);
    }
    */

    public void BackToTheMemories()
    {
        DialogueManager.StopAllConversations();
        Destroy(DialogueManager.instance.gameObject);
        SceneManager.LoadScene("FirstRealFriend");
    }

    /*
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
    */

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


    public void MakeNotebooksAppear()
    {
        
        if(debugBool) DebugSetNotebookEntries();
        

        finalNotebooks = StaticVariables.notebookDict;


        //////
        ///

        //DATING NOTES
        if (finalNotebooks.ContainsKey("Dating"))
        {
            GameObject notebookInstance = Instantiate(finalNotebookPrefab);
            notebookInstance.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Dating";
            notebookInstance.gameObject.transform.GetChild(1).GetComponent<TMP_InputField>().text = finalNotebooks.GetValueOrDefault("Dating");
            notebookInstancesList.Add(notebookInstance);
            notebookInstance.SetActive(false);
            notebookInstance.transform.parent = notebookCanvas.transform;
        }
        else
        {
            GameObject notebookInstance = Instantiate(finalNotebookPrefab);
            string defaultText = "Hi";
            notebookInstance.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Dating";
            notebookInstance.gameObject.transform.GetChild(1).GetComponent<TMP_InputField>().text = defaultText;
            notebookInstancesList.Add(notebookInstance);
            notebookInstance.SetActive(false);
            notebookInstance.transform.parent = notebookCanvas.transform;
        }

        //CHILDHOOD NOTES
        if (finalNotebooks.ContainsKey("Childhood"))
        {
            GameObject notebookInstance = Instantiate(finalNotebookPrefab);
            notebookInstance.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "School";
            notebookInstance.gameObject.transform.GetChild(1).GetComponent<TMP_InputField>().text = finalNotebooks.GetValueOrDefault("Childhood");
            notebookInstancesList.Add(notebookInstance);
            notebookInstance.SetActive(false);
            notebookInstance.transform.parent = notebookCanvas.transform;
        }
        else
        {
            GameObject notebookInstance = Instantiate(finalNotebookPrefab);
            string defaultText = "Hi";
            notebookInstance.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "School";
            notebookInstance.gameObject.transform.GetChild(1).GetComponent<TMP_InputField>().text = defaultText;
            notebookInstancesList.Add(notebookInstance);
            notebookInstance.SetActive(false);
            notebookInstance.transform.parent = notebookCanvas.transform;
        }

        //CAFETERIA NOTES
        if (finalNotebooks.ContainsKey("Cafeteria"))
        {
            GameObject notebookInstance = Instantiate(finalNotebookPrefab);
            notebookInstance.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Cafeteria";
            notebookInstance.gameObject.transform.GetChild(1).GetComponent<TMP_InputField>().text = finalNotebooks.GetValueOrDefault("Cafeteria");
            notebookInstancesList.Add(notebookInstance);
            notebookInstance.SetActive(false);
            notebookInstance.transform.parent = notebookCanvas.transform;
        }
        else
        {
            GameObject notebookInstance = Instantiate(finalNotebookPrefab);
            string defaultText = "Hi";
            notebookInstance.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Cafeteria";
            notebookInstance.gameObject.transform.GetChild(1).GetComponent<TMP_InputField>().text = defaultText;
            notebookInstancesList.Add(notebookInstance);
            notebookInstance.SetActive(false);
            notebookInstance.transform.parent = notebookCanvas.transform;
        }

        //CHURCH_FRIEND_BEFORE
        if (finalNotebooks.ContainsKey("Church_Friend_Before"))
        {
            GameObject notebookInstance = Instantiate(finalNotebookPrefab);
            notebookInstance.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Church Dance Group";
            notebookInstance.gameObject.transform.GetChild(1).GetComponent<TMP_InputField>().text = finalNotebooks.GetValueOrDefault("Church_Friend_Before");
            notebookInstancesList.Add(notebookInstance);
            notebookInstance.SetActive(false);
            notebookInstance.transform.parent = notebookCanvas.transform;
        }
        else
        {
            GameObject notebookInstance = Instantiate(finalNotebookPrefab);
            string defaultText = "Hi";
            notebookInstance.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Church Dance Group";
            notebookInstance.gameObject.transform.GetChild(1).GetComponent<TMP_InputField>().text = defaultText;
            notebookInstancesList.Add(notebookInstance);
            notebookInstance.SetActive(false);
            notebookInstance.transform.parent = notebookCanvas.transform;
        }

        //CHURCH_FRIEND
        if (finalNotebooks.ContainsKey("Church_Friend"))
        {
            GameObject notebookInstance = Instantiate(finalNotebookPrefab);
            notebookInstance.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Church Bible Group";
            notebookInstance.gameObject.transform.GetChild(1).GetComponent<TMP_InputField>().text = finalNotebooks.GetValueOrDefault("Church_Friend");
            notebookInstancesList.Add(notebookInstance);
            notebookInstance.SetActive(false);
            notebookInstance.transform.parent = notebookCanvas.transform;
        }
        else
        {
            GameObject notebookInstance = Instantiate(finalNotebookPrefab);
            string defaultText = "Hi";
            notebookInstance.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Church Bible Group";
            notebookInstance.gameObject.transform.GetChild(1).GetComponent<TMP_InputField>().text = defaultText;
            notebookInstancesList.Add(notebookInstance);
            notebookInstance.SetActive(false);
            notebookInstance.transform.parent = notebookCanvas.transform;
        }

        //FirstRealFriend
        if (finalNotebooks.ContainsKey("FirstRealFriend"))
        {
            GameObject notebookInstance = Instantiate(finalNotebookPrefab);
            notebookInstance.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Sandbox";
            notebookInstance.gameObject.transform.GetChild(1).GetComponent<TMP_InputField>().text = finalNotebooks.GetValueOrDefault("FirstRealFriend");
            notebookInstancesList.Add(notebookInstance);
            notebookInstance.SetActive(false);
            notebookInstance.transform.parent = notebookCanvas.transform;
        }
        else
        {
            GameObject notebookInstance = Instantiate(finalNotebookPrefab);
            string defaultText = "Hi";
            notebookInstance.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Sandbox";
            notebookInstance.gameObject.transform.GetChild(1).GetComponent<TMP_InputField>().text = defaultText;
            notebookInstancesList.Add(notebookInstance);
            notebookInstance.SetActive(false);
            notebookInstance.transform.parent = notebookCanvas.transform;
        }

        //Home
        if (finalNotebooks.ContainsKey("Home"))
        {
            GameObject notebookInstance = Instantiate(finalNotebookPrefab);
            notebookInstance.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "At Home";
            notebookInstance.gameObject.transform.GetChild(1).GetComponent<TMP_InputField>().text = finalNotebooks.GetValueOrDefault("Home");
            notebookInstancesList.Add(notebookInstance);
            notebookInstance.SetActive(false);
            notebookInstance.transform.parent = notebookCanvas.transform;
        }
        else
        {
            GameObject notebookInstance = Instantiate(finalNotebookPrefab);
            string defaultText = "Hi";
            notebookInstance.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "At Home";
            notebookInstance.gameObject.transform.GetChild(1).GetComponent<TMP_InputField>().text = defaultText;
            notebookInstancesList.Add(notebookInstance);
            notebookInstance.SetActive(false);
            notebookInstance.transform.parent = notebookCanvas.transform;
        }

        lerpManagers[0].SetSpeeds(1, 2);

        lerpManagers[0].Rect = notebookInstancesList[0];

        Vector3 endPoint = new Vector3(Screen.width * 0.5f, Screen.height * 0.25f, 0);
        GameObject tmp = new GameObject();
        tmp.transform.position = endPoint;
        lerpManagers[0].EndPoint = tmp.transform;

        Vector3 startPoint = new Vector3(Screen.width * 0.5f, 0f, 0);
        tmp = new GameObject();
        tmp.transform.position = startPoint;
        lerpManagers[0].StartPoint = tmp.transform;

        StartCoroutine(MakeNotebooksAppear2());
    }


    IEnumerator MakeNotebooksAppear2()
    {
        notebookInstancesList[0].SetActive(true);
        yield return StartCoroutine(lerpManagers[0].LerpRectFixedTimeOneWay());

        lerpManagers[0].SetSpeeds(1, 2);

        arrowLeftInstance = Instantiate(notebookArrowLeft);
        arrowLeftInstance.transform.parent = notebookCanvas.transform;
        arrowLeftInstance.transform.position = new Vector3(Screen.width*0.1f, Screen.height * 0.5f, 1f);
        lerpManagers[0].Rect = arrowLeftInstance.gameObject;

        StartCoroutine(lerpManagers[0].FadeInOneWayCanvas());

        lerpManagers[1].SetSpeeds(1, 2);

        arrowRightInstance = Instantiate(notebookArrowRight);
        arrowRightInstance.transform.parent = notebookCanvas.transform;
        arrowRightInstance.transform.position = new Vector3(Screen.width * 0.9f, Screen.height * 0.5f, 1f);
        lerpManagers[1].Rect = arrowRightInstance.gameObject;

        StartCoroutine(lerpManagers[1].FadeInOneWayCanvas());

        lerpManagers[2].SetSpeeds(1, 2);

        hideButtonInstance = Instantiate(notebookHideButton);
        hideButtonInstance.transform.parent = notebookCanvas.transform;
        hideButtonInstance.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.8f, 1f);
        lerpManagers[2].Rect = hideButtonInstance.gameObject;

        yield return StartCoroutine(lerpManagers[2].FadeInOneWayCanvas());

        notebookArrowLeft.SetClickable(true);
        notebookArrowRight.SetClickable(true);
        notebookHideButton.SetClickable(true);
    }


     


    public void DebugSetNotebookEntries()
    {
        Dictionary<string, string> tmp = new Dictionary<string,string>();

        tmp.Add("Childhood", "x");
        tmp.Add("Dating", "y");

        tmp.Add("Cafeteria", "a");
        tmp.Add("Church_Friend_Before", "b");
        tmp.Add("Church_Friend", "c");
        tmp.Add("FirstRealFriend","d");
        tmp.Add("Home", "e");
        StaticVariables.notebookDict = tmp;
    }

    public void BlueBackground()
    {
        if(blueBackground == null)
        {

        }
        else
        {
            blueBackground.SetActive(true);
        }
        
    }

    public void HideBackground()
    {
        foreach (GameObject gameObject in backgroundToHide)
        {
            gameObject.SetActive(false);
        }
    }

    public void ShowBackground()
    {
        foreach (GameObject gameObject in backgroundToHide)
        {
            gameObject.SetActive(true);
        }
        
    }
}
