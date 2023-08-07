using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;

public class StartConversationThenSkipScene : MonoBehaviour
{
    public string conversation;
    // Start is called before the first frame update
    void Start()
    {
        DialogueManager.StartConversation(conversation);
    }

    // Update is called once per frame
    void Update()
    {
        if (!DialogueManager.IsConversationActive) {
            int sceneIndex = GetCurrentSceneIndex();
            // Test for existing dialogue manager
            if (DialogueManager.instance != null)
            {
                DialogueManager.StopAllConversations();
                Destroy(DialogueManager.instance.gameObject);
            }
            SceneManager.LoadScene(sceneIndex + 1);
        }
    }

    private int GetCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
