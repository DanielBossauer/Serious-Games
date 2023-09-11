using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroductionFirstRealFriend : MonoBehaviour
{

    [SerializeField] GameObject backdrop;

    [SerializeField] float fadeDuration = 2f;

    bool fadeIn;

    float lastTime;
    float timeToPass;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<DialogueSystemTrigger>().OnUse();
        DialogueManager.instance.transform.GetChild(0).GetComponent<Canvas>().sortingOrder = 200;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            //this.Rect.GetComponent<Image>().canvasRenderer.SetAlpha(0.01f);
            backdrop.GetComponent<Image>().CrossFadeAlpha(1f, fadeDuration, false);
            //this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().CrossFadeAlpha(1f, fadeDuration, false);
            if (Time.realtimeSinceStartup > lastTime + timeToPass)
            {
                lastTime = Time.realtimeSinceStartup;
                fadeIn = false;
                
            }
        }
    }

    public void SwitchToMainConvo()
    {
        StartCoroutine(SwitchToMainConvoCoroutine());
    }

    IEnumerator SwitchToMainConvoCoroutine()
    {
        yield return new WaitForSeconds(3);
        DialogueManager.StopAllConversations();
        this.GetComponent<DialogueSystemTrigger>().conversation = "New Conversation 3";
        this.GetComponent<DialogueSystemTrigger>().OnUse();

        
        backdrop.GetComponent<Image>().canvasRenderer.SetAlpha(0.01f);
        backdrop.SetActive(true);
        fadeIn = true;
        timeToPass = 5f;
        lastTime = Time.realtimeSinceStartup;
    }

    public void StartNextScene()
    {
        DialogueManager.StopAllConversations();
        //DialogueManager.
        //Destroy(DialogueManager.instance);
        //DialogueManager.databaseManager.
        //DialogueManager.StartConversation();
        Destroy(DialogueManager.instance.gameObject);
        SceneManager.LoadScene("IntroductionHome");
    }


}
