using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers;
using PixelCrushers.DialogueSystem;

public class MentalBreakDown : MonoBehaviour
{
    public Sprite homeBackground;
    public string conversation1;
    public string conversation2;

    public bool firstCoversationDone = false;
    GameObject background;
    
    AudioSource audio1;
    AudioSource audio2;


    // Start is called before the first frame update
    void Start()
    {
        LoadBackground(homeBackground);
        DialogueManager.StartConversation(conversation1);
        audio1 = this.gameObject.transform.GetChild(0).GetComponent<AudioSource>();
        audio2 = this.gameObject.transform.GetChild(1).GetComponent<AudioSource>();
    }


    public void LoadBackground(Sprite sprite) {
        background.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    public void KillBackground () {
        Destroy(background);
    }

    public void LoadSecondConversation() {
        KillBackground();
        audio1.Play();
        StartCoroutine(DelaySecondConversation());
    }

    public IEnumerator DelaySecondConversation() {
        yield return new WaitForSeconds(1.4f);
        audio2.Play();
        DialogueManager.StartConversation(conversation2);
    }


    public void LoadNextScene() {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Test for existing dialogue manager
        if (DialogueManager.instance != null)
        {
            DialogueManager.StopAllConversations();
            Destroy(DialogueManager.instance.gameObject);
        }
        SceneManager.LoadScene(sceneIndex + 1);
    }

    // Update is called once per frame
    void Update() {
        // Check if the first Conversation just finished
        if (!firstCoversationDone && !conversationActive()) {
            firstCoversationDone = true;
            LoadSecondConversation();
        }     

        // Check if the second Conversation just finished
        if (FinishedScene() && firstCoversationDone && !conversationActive()) {
            LoadNextScene();
        }    

    }

    private bool FinishedScene() {
        return DialogueLua.GetVariable("Finished_Scene").AsBool;
    }

    private bool conversationActive() {
        return DialogueManager.IsConversationActive;
    }

    private void Awake() {
        background = GameObject.Find("Background");
    }
}
