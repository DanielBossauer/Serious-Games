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


    // Start is called before the first frame update
    void Start()
    {
        LoadBackground(homeBackground);
        DialogueManager.StartConversation(conversation1);
    }


    public void LoadBackground(Sprite sprite) {
        background.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    public void KillBackground () {
        Destroy(background);
    }

    public void LoadSecondConversation() {
        KillBackground();
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
        if (firstCoversationDone && !conversationActive()) {
            LoadNextScene();
        }    

    }

    private bool conversationActive() {
        return DialogueManager.IsConversationActive;
    }

    private void Awake() {
        background = GameObject.Find("Background");
    }
}
