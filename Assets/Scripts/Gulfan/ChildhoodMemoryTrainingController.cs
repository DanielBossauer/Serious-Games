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
    public bool firstMemoryScene;

    public bool gameDone = false;
    public bool sceneDone = false;

    public bool firstCoversationDone = false;
    GameObject background;

    private Vector3 homeBackgroundScale;
    private Vector3 memoryScale;


    // Start is called before the first frame update
    void Start()
    {
        homeBackgroundScale = new Vector3(1.047f, 1.047f, 1f);
        memoryScale = new Vector3(1f, 1f, 1f);
        LoadBackground(homeBackground);
        DialogueManager.StartConversation(conversation1);
    }


    public void LoadBackground(Sprite sprite) {
        background.GetComponent<SpriteRenderer>().sprite = sprite;
        background.transform.localScale = homeBackgroundScale;
    }

    public void LoadMemory () {
        LoadBackground(memoryBackground);
        background.transform.localScale = memoryScale;
        memoryPrefab = Instantiate(memoryPrefab, new Vector3(5.105501f, 0.2665106f, -18.48575f), Quaternion.identity);
        memoryPrefab.transform.localScale = memoryScale;
        if (firstMemoryScene) {
            DialogueManager.StartConversation("MemoryTutorial");
        }
    }

    public void KillMemory () {
        memoryPrefab.GetComponentInChildren<GameControl>().KillAllTokens();
        Destroy(memoryPrefab);
    }

    public void LoadSecondConversation() {        
        if (DialogueManager.instance != null)
        {
            DialogueManager.StopConversation();
            DialogueManager.StopAllConversations();
        }
        
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
            LoadMemory();
        }     
        
        // Check if Memory Game just finished
        if (!gameDone && memoryPrefab.GetComponentInChildren<GameControl>().gameFinished) {
            LoadSecondConversation();  
        }

        // Check if the second Conversation just finished
        if (firstCoversationDone && gameDone && (DialogueLua.GetVariable("Finished_Scene").AsBool || !conversationActive())) {
            LoadNextScene();
        }    

    }

    private bool conversationActive() {
        return DialogueManager.IsConversationActive;
    }

    private void Awake() {
        background = GameObject.Find("TrueBackground");
    }

}
