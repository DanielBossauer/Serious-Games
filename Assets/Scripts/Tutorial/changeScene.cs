using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    [SerializeField]
    int index = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //SceneManager.LoadScene(index);
            int sceneIndex = GetCurrentSceneIndex();
            // Test for existing dialogue manager
            if (DialogueManager.instance != null)
            {
                DialogueManager.StopAllConversations();
                Destroy(DialogueManager.instance.gameObject);
            }
            // DialogueManager.StopAllConversations();
            // Destroy(DialogueManager.instance.gameObject);
            SceneManager.LoadScene(sceneIndex + 1);
        }
    }

    private int GetCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
