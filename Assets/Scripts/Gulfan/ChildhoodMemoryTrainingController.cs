using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers;
using PixelCrushers.DialogueSystem;

public class ChildhoodMemoryTrainingController : MonoBehaviour
{
    public Sprite homeBackground;
    public Sprite homeBackgroundAfter;
    public Sprite memoryBackground;
    public GameObject memoryPrefab;
    public string conversation1;
    public string conversation2;

    public bool gameDone = false;

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

    public void LoadMemory () {
        LoadBackground(memoryBackground);
        memoryPrefab = Instantiate(memoryPrefab, new Vector3(5.105501f, 0.2665106f, -18.48575f), Quaternion.identity);
    }

    public void KillMemory () {
        memoryPrefab.GetComponentInChildren<GameControl>().KillAllTokens();
        Destroy(memoryPrefab);
    }

    public void LoadSecondConversation() {
        if (memoryPrefab.GetComponentInChildren<GameControl>().gameSuccess) {
            DialogueLua.SetVariable("gameWon", true);
        } else {
            DialogueLua.SetVariable("gameWon", false);
        }
        gameDone = true;
        KillMemory();
        LoadBackground(homeBackgroundAfter);
        DialogueManager.StartConversation(conversation2);
    }


    public void LoadNextScene() {
        // get current SceneNumber and then load next Scene
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex + 1);
    }

    // Update is called once per frame
    void Update() {
        // Check if the first Conversation just finished
        if (!firstCoversationDone && !conversationActive()) {
            firstCoversationDone = true;
            LoadMemory();
        }     
        
        // Check if Memory Game just finished
        if (!gameDone && memoryPrefab.GetComponentInChildren<GameControl>().gameFinished) {
            LoadSecondConversation();  
        }

        // Check if the second Conversation just finished
        if (firstCoversationDone && gameDone && !conversationActive()) {
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
