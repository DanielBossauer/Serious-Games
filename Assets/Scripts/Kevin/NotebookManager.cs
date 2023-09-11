using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NotebookManager : MonoBehaviour
{

    [SerializeField] LerpManager lerpManager;
    [SerializeField] GameObject notebook;
    [SerializeField] Canvas canvas;
    NotebookTimer timer;
    [SerializeField] string nextScene;
    [SerializeField] bool useDefaultText;
    [SerializeField] string defaultText;

    GameObject notebookInstance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void MakeNotebookAppear()
    {
        Debug.Log("Make Notebook Appear");

        notebookInstance = Instantiate(notebook);

        lerpManager.SetSpeeds(1, 2);

        if (useDefaultText)
        {
            notebookInstance.gameObject.transform.GetChild(1).GetComponent<TMP_InputField>().text = defaultText;
        }

        if (timer == null)
        {
            timer = notebookInstance.gameObject.transform.GetChild(2).GetComponent<NotebookTimer>();
            timer.SetNotebookManager(this);
        }

        lerpManager.Rect = notebookInstance;


        Vector3 endPoint = new Vector3(Screen.width*0.5f, Screen.height * 0.40f, 0);
        GameObject tmp = new GameObject();
        tmp.transform.position = endPoint;
        lerpManager.EndPoint = tmp.transform;

        Vector3 startPoint = new Vector3(Screen.width * 0.5f, Screen.height*(-0.6f), 0);
        tmp = new GameObject();
        tmp.transform.position = startPoint;
        lerpManager.StartPoint = tmp.transform;

        //GameObject myBubble = Instantiate(intrusiveThoughtBubble, randomWorldPos, Quaternion.identity) as GameObject;
        notebookInstance.gameObject.transform.SetParent(canvas.transform);
        notebookInstance.gameObject.transform.position = startPoint;

        StartCoroutine(MakeNotebookAppearCoroutine());

    }

    IEnumerator MakeNotebookAppearCoroutine()
    {
        yield return StartCoroutine(lerpManager.LerpRectFixedTimeOneWay());
        timer.gameObject.SetActive(true);
        //NotebookTimer notebookTimerInstance = Instantiate(timer);
    }

    public void CallNextScene()
    {
        SaveText();

        DialogueManager.StopAllConversations();
        Destroy(DialogueManager.instance.gameObject);
        SceneManager.LoadScene(nextScene);
    }

    void SaveText()
    {
        if(StaticVariables.notebookDict == null)
        {
            StaticVariables.notebookDict = new Dictionary<string, string>();


        }
        StaticVariables.notebookDict.Add(SceneManager.GetActiveScene().name, notebookInstance.gameObject.transform.GetChild(1).GetComponent<TMP_InputField>().text);
    }


    
}
