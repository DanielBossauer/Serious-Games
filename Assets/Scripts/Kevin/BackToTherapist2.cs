using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    //[SerializeField] FinalNotebookArrow arrowLeftInstance;
    //[SerializeField] FinalNotebookArrow arrowRightInstance;
    //[SerializeField] FinalNotebookHideButton hideButtonInstance;

    [SerializeField] GameObject notebookCanvas;

    int notebookCounter;

    bool notebooksDisplayed;

    [SerializeField] GameObject[] PIOSEEStages;

    [SerializeField] string startingConvo;

    [SerializeField] Canvas finalMindMap;

    [SerializeField] Canvas swapMindMap;

    [SerializeField] SwapMinigame swapMinigame;

    [SerializeField] Image swapMinigameHider;

    [SerializeField] SoundEffectsPlayer soundEffectsPlayer;

    private void Awake()
    {
        notebookArrowLeft.gameObject.SetActive(false);
        notebookArrowRight.gameObject.SetActive(false);
        notebookHideButton.gameObject.SetActive(false);

        swapMindMap.gameObject.SetActive(false);
        finalMindMap.gameObject.SetActive(false);

        swapMinigameHider.gameObject.SetActive(false);

        foreach (GameObject g in PIOSEEStages)
        {
            g.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<DialogueSystemTrigger>().conversation = startingConvo;
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
        DialogueManager.StopAllConversations();
        StartConvo("New Conversation 1");
    }

    public void StartConvo2()
    {
        DialogueManager.StopAllConversations();
        StartConvo("New Conversation 2");
    }

    public void StartConvo3()
    {
        DialogueManager.StopAllConversations();
        StartConvo("New Conversation 3");
    }

    public void StartConvo4()
    {
        DialogueManager.StopAllConversations();
        StartConvo("New Conversation 4");
    }

    public void StartConvo5()
    {
        DialogueManager.StopAllConversations();
        StartConvo("New Conversation 5");
    }

    public void StartConvo6()
    {
        DialogueManager.StopAllConversations();
        StartConvo("New Conversation 6");
    }

    public void StartConvo7()
    {
        DialogueManager.StopAllConversations();
        StartConvo("New Conversation 7");
    }

    public void StartConvo8()
    {
        DialogueManager.StopAllConversations();
        StartConvo("New Conversation 8");
    }

    public void StartConvo9()
    {
        DialogueManager.StopAllConversations();
        StartConvo("New Conversation 9");
    }

    public void StartConvo10()
    {
        DialogueManager.StopAllConversations();
        StartConvo("New Conversation 10");
    }

    public void StartConvo11()
    {
        DialogueManager.StopAllConversations();
        ShowBackground();
        StartConvo("New Conversation 11");
    }

    public void StartConvo12()
    {
        DialogueManager.StopAllConversations();
        HideBackground();
        ShowOverviewOfProblems();
        StartConvo("New Conversation 12");
    }

    public void StartConvo13()
    {
        ShowFilledIn();
        DialogueManager.StopAllConversations();
        StartConvo("New Conversation 13");
    }

    public void StartConvo14()
    {
        HideOverviewOfProblems();
        ShowBackground();
        DialogueManager.StopAllConversations();
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
        //StartCoroutine(lerpManagers[0].LerpRectFixedTimeOneWay());

        lerpManagers[1].SetSpeeds(1, 2);

        //arrowLeftInstance = Instantiate(notebookArrowLeft);
        notebookArrowLeft.gameObject.transform.SetParent(notebookCanvas.transform);
        notebookArrowLeft.transform.position = new Vector3(Screen.width*0.1f, Screen.height * 0.5f, 1f);
        lerpManagers[1].Rect = notebookArrowLeft.gameObject;

        //StartCoroutine(lerpManagers[1].FadeInOneWayCanvas(true,1f));

        //lerpManagers[1].FadeInOneWayCanvas(true, 1f);
        lerpManagers[1].SetActiveTrue();

        lerpManagers[2].SetSpeeds(1, 2);

        //arrowRightInstance = Instantiate(notebookArrowRight);
        notebookArrowRight.gameObject.transform.SetParent(notebookCanvas.transform);
        notebookArrowRight.transform.position = new Vector3(Screen.width * 0.9f, Screen.height * 0.5f, 1f);
        lerpManagers[2].Rect = notebookArrowRight.gameObject;

        //StartCoroutine(lerpManagers[2].FadeInOneWayCanvas());

        //lerpManagers[2].FadeInOneWayCanvas(true, 1f);
        lerpManagers[2].SetActiveTrue();

        lerpManagers[3].SetSpeeds(1, 2);

        //hideButtonInstance = Instantiate(notebookHideButton);
        notebookHideButton.gameObject.transform.SetParent(notebookCanvas.transform);
        notebookHideButton.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.8f, 1f);
        lerpManagers[3].Rect = notebookHideButton.gameObject;

        //StartCoroutine(lerpManagers[3].FadeInOneWayCanvas());
        //lerpManagers[3].FadeInOneWayCanvas(true, 1f);
        lerpManagers[3].SetActiveTrue();
        yield return StartCoroutine(lerpManagers[0].LerpRectFixedTimeOneWay());

        notebooksDisplayed = true;
        notebookArrowLeft.SetClickable(true);
        notebookArrowRight.SetClickable(true);
        notebookHideButton.SetClickable(true);
        notebookHideButton.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Hide Notes";
    }

    public void ClickMakeNotebooksAppear()
    {
        lerpManagers[0].SetSpeeds(1, 2);

        lerpManagers[0].Rect = notebookInstancesList[notebookCounter];

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
     


    public void DebugSetNotebookEntries()
    {
        Dictionary<string, string> tmp = new Dictionary<string,string>();

        tmp.Add("Dating", "y");
        tmp.Add("Childhood", "x");
        

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
            if (gameObject != null) gameObject.SetActive(false);
        }
    }

    public void ShowBackground()
    {
        foreach (GameObject gameObject in backgroundToHide)
        {
            if(gameObject != null) gameObject.SetActive(true);
        }
        
    }

    public void ClickLeftScrollButton()
    {
        if (notebookArrowLeft.GetIsClickable() && notebookCounter != 0)
        {
            StartCoroutine(LeftScrollButtonClicked());
        }
    }

    public void ClickRightScrollButton()
    {
        if (notebookArrowRight.GetIsClickable() && notebookCounter < notebookInstancesList.Count - 1)
        {
            StartCoroutine(RightScrollButtonClicked());
        }
    }

    public IEnumerator LeftScrollButtonClicked()
    {
        if (notebookArrowLeft.GetIsClickable() && notebookCounter != 0)
        {

            notebookArrowLeft.SetClickable(false);
            notebookArrowRight.SetClickable(false);
            notebookHideButton.SetClickable(false);

            //sweep existing notebook out to the right

            lerpManagers[0].SetSpeeds(1, 2);

            lerpManagers[0].Rect = notebookInstancesList[notebookCounter];

            Vector3 endPoint = new Vector3(Screen.width, Screen.height * 0.25f, 0);
            GameObject tmp = new GameObject();
            tmp.transform.position = endPoint;
            lerpManagers[0].EndPoint = tmp.transform;

            Vector3 startPoint = new Vector3(Screen.width * 0.5f, Screen.height * 0.25f, 0);
            tmp = new GameObject();
            tmp.transform.position = startPoint;
            lerpManagers[0].StartPoint = tmp.transform;

            //sweep notebook in from the left

            lerpManagers[1].SetSpeeds(1, 2);

            lerpManagers[1].Rect = notebookInstancesList[notebookCounter-1];

            endPoint = new Vector3(Screen.width * 0.5f, Screen.height * 0.25f, 0);
            tmp = new GameObject();
            tmp.transform.position = endPoint;
            lerpManagers[1].EndPoint = tmp.transform;

            startPoint = new Vector3(0, Screen.height * 0.25f, 0);
            tmp = new GameObject();
            tmp.transform.position = startPoint;
            lerpManagers[1].StartPoint = tmp.transform;

            //do the lerping and wait until they are finished

            notebookInstancesList[notebookCounter - 1].SetActive(true);

            StartCoroutine(lerpManagers[0].LerpRectFixedTimeOneWay());
            yield return StartCoroutine(lerpManagers[1].LerpRectFixedTimeOneWay());

            notebookInstancesList[notebookCounter].transform.position = new Vector3(Screen.width * 0.5f, 0f, 0);
            notebookInstancesList[notebookCounter].SetActive(false);

            notebookCounter--;

            notebookArrowLeft.SetClickable(true);
            notebookArrowRight.SetClickable(true);
            notebookHideButton.SetClickable(true);
        }

        yield return null;
    }

    public IEnumerator RightScrollButtonClicked()
    {
        if (notebookArrowRight.GetIsClickable() && notebookCounter < notebookInstancesList.Count - 1)
        {

            notebookArrowLeft.SetClickable(false);
            notebookArrowRight.SetClickable(false);
            notebookHideButton.SetClickable(false);

            //sweep existing notebook out to the left

            lerpManagers[0].SetSpeeds(1, 2);

            lerpManagers[0].Rect = notebookInstancesList[notebookCounter];

            Vector3 endPoint = new Vector3(0, Screen.height * 0.25f, 0);
            GameObject tmp = new GameObject();
            tmp.transform.position = endPoint;
            lerpManagers[0].EndPoint = tmp.transform;

            Vector3 startPoint = new Vector3(Screen.width * 0.5f, Screen.height * 0.25f, 0);
            tmp = new GameObject();
            tmp.transform.position = startPoint;
            lerpManagers[0].StartPoint = tmp.transform;

            //sweep notebook in from the right

            lerpManagers[1].SetSpeeds(1, 2);

            lerpManagers[1].Rect = notebookInstancesList[notebookCounter + 1];

            endPoint = new Vector3(Screen.width * 0.5f, Screen.height * 0.25f, 0);
            tmp = new GameObject();
            tmp.transform.position = endPoint;
            lerpManagers[1].EndPoint = tmp.transform;

            startPoint = new Vector3(Screen.width, Screen.height * 0.25f, 0);
            tmp = new GameObject();
            tmp.transform.position = startPoint;
            lerpManagers[1].StartPoint = tmp.transform;

            //do the lerping and wait until they are finished

            notebookInstancesList[notebookCounter+1].SetActive(true);

            StartCoroutine(lerpManagers[0].LerpRectFixedTimeOneWay());
            yield return StartCoroutine(lerpManagers[1].LerpRectFixedTimeOneWay());

            notebookInstancesList[notebookCounter].transform.position = new Vector3(Screen.width * 0.5f, 0f, 0);
            notebookInstancesList[notebookCounter].SetActive(false);

            notebookCounter++;

            notebookArrowLeft.SetClickable(true);
            notebookArrowRight.SetClickable(true);
            notebookHideButton.SetClickable(true);


        }

        yield return null;
    }

    public IEnumerator HideNotebooks()
    {
        if (notebookHideButton.GetIsClickable() && notebooksDisplayed)
        {
            notebookArrowLeft.SetClickable(false);
            notebookArrowRight.SetClickable(false);
            notebookHideButton.SetClickable(false);

            //hide notebook
            lerpManagers[0].SetSpeeds(0.5f, 1);

            lerpManagers[0].Rect = notebookInstancesList[notebookCounter];

            Vector3 endPoint = new Vector3(Screen.width * 0.5f, 0f, 0);
            GameObject tmp = new GameObject();
            tmp.transform.position = endPoint;
            lerpManagers[0].EndPoint = tmp.transform;

            Vector3 startPoint = new Vector3(Screen.width * 0.5f, Screen.height * 0.25f, 0);
            tmp = new GameObject();
            tmp.transform.position = startPoint;
            lerpManagers[0].StartPoint = tmp.transform;




            
            

            lerpManagers[1].SetSpeeds(0.5f, 1);

            //arrowLeftInstance = Instantiate(notebookArrowLeft);
            notebookArrowLeft.transform.parent = notebookCanvas.transform;
            notebookArrowLeft.transform.position = new Vector3(Screen.width * 0.1f, Screen.height * 0.5f, 1f);
            lerpManagers[1].Rect = notebookArrowLeft.gameObject;

            //StartCoroutine(lerpManagers[1].FadeOutOneWayCanvas());
            //lerpManagers[1].FadeOutOneWayCanvas(true,1f);
            lerpManagers[1].SetActiveFalse();

            lerpManagers[2].SetSpeeds(0.5f, 1);

            //arrowRightInstance = Instantiate(notebookArrowRight);
            notebookArrowRight.transform.parent = notebookCanvas.transform;
            notebookArrowRight.transform.position = new Vector3(Screen.width * 0.9f, Screen.height * 0.5f, 1f);
            lerpManagers[2].Rect = notebookArrowRight.gameObject;

            //StartCoroutine(lerpManagers[2].FadeOutOneWayCanvas());
            //lerpManagers[2].FadeOutOneWayCanvas(true, 1f);
            lerpManagers[2].SetActiveFalse();

            /*
            lerpManagers[3].SetSpeeds(1, 2);

            hideButtonInstance = Instantiate(notebookHideButton);
            hideButtonInstance.transform.parent = notebookCanvas.transform;
            hideButtonInstance.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.8f, 1f);
            lerpManagers[3].Rect = hideButtonInstance.gameObject;

            StartCoroutine(lerpManagers[3].FadeOutOneWayCanvas());
            */
            yield return StartCoroutine(lerpManagers[0].LerpRectFixedTimeOneWay());

            notebookInstancesList[notebookCounter].SetActive(false);

            //notebookShowButton.SetClickable(true);
            notebooksDisplayed = false;
            notebookHideButton.SetClickable(true);
            notebookHideButton.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Show Notes";
        }

        yield return null;
    }

    public void ShowNotebooks()
    {

        if (notebookHideButton.GetIsClickable() && !notebooksDisplayed)
        {
            notebookHideButton.SetClickable(false);

            //has to be executed last because coroutines
            ClickMakeNotebooksAppear();

            //notebookHideButton.SetClickable(true);
            //notebookArrowLeft.SetClickable(true);
            //notebookArrowRight.SetClickable(true);
        }

        //yield return null;
    }

    public void HideNotebooksButtonClicked()
    {
        if (notebookHideButton.GetIsClickable() && !notebooksDisplayed)
        {
            ShowNotebooks();
        }
        else if (notebookHideButton.GetIsClickable() && notebooksDisplayed)
        {
            StartCoroutine(HideNotebooks());
        }
    }













    public void PIOSEEs_Activate()
    {
        foreach (GameObject g in PIOSEEStages)
        {
            g.SetActive(true);
        }
    }

    public void PIOSEEs_Deactivate()
    {
        foreach (GameObject g in PIOSEEStages)
        {
            g.SetActive(false);
        }
    }

    public void PIOSEE_P()
    {
        PIOSEEStages[0].GetComponent<TextMeshProUGUI>().color = Color.red;
    }

    public void PIOSEE_I()
    {
        PIOSEEStages[0].GetComponent<TextMeshProUGUI>().color = Color.white;
        PIOSEEStages[1].GetComponent<TextMeshProUGUI>().color = Color.red;
    }

    public void PIOSEE_O()
    {
        PIOSEEStages[1].GetComponent<TextMeshProUGUI>().color = Color.white;
        PIOSEEStages[2].GetComponent<TextMeshProUGUI>().color = Color.red;
    }

    public void PIOSEE_S()
    {
        PIOSEEStages[2].GetComponent<TextMeshProUGUI>().color = Color.white;
        PIOSEEStages[3].GetComponent<TextMeshProUGUI>().color = Color.red;
    }

    public void PIOSEE_E1()
    {
        PIOSEEStages[3].GetComponent<TextMeshProUGUI>().color = Color.white;
        PIOSEEStages[4].GetComponent<TextMeshProUGUI>().color = Color.red;
    }

    public void PIOSEE_E2()
    {
        PIOSEEStages[4].GetComponent<TextMeshProUGUI>().color = Color.white;
        PIOSEEStages[5].GetComponent<TextMeshProUGUI>().color = Color.red;
    }

    public void PIOSEE_Done()
    {
        PIOSEEStages[5].GetComponent<TextMeshProUGUI>().color = Color.white;
    }



    

    public void ShowOverviewOfProblems()
    {
        //swapMinigame.ShufflePositions();
        swapMinigameHider.gameObject.SetActive(true);
        swapMindMap.gameObject.SetActive(true);
    }

    public void ShowFilledIn()
    {
        swapMindMap.gameObject.SetActive(false);
        finalMindMap.gameObject.SetActive(true);
    }

    public void HideOverviewOfProblems()
    {
        finalMindMap.gameObject.SetActive(false);
    }

    public void ShowFinalMap()
    {
        finalMindMap.gameObject.SetActive(true);
    }

    public void PlayLayton()
    {
        soundEffectsPlayer.SFX2();
    }
}
