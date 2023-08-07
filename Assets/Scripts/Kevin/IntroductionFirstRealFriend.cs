using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroductionFirstRealFriend : MonoBehaviour
{

    [SerializeField] GameObject backdrop;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<DialogueSystemTrigger>().OnUse();
        DialogueManager.instance.transform.GetChild(0).GetComponent<Canvas>().sortingOrder = 200;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        backdrop.SetActive(true);
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
