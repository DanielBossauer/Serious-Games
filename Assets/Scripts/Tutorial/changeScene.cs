using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;

public class changeScene : MonoBehaviour
{
    [SerializeField]
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int sceneIndex = GetCurrentSceneIndex();
            // Test for existing dialogue manager
            if (DialogueManager.instance != null)
            {
                DialogueManager.StopAllConversations();
                Destroy(DialogueManager.instance.gameObject);
            }
            // Destroy(DialogueManager.instance.gameObject);
            SceneManager.LoadScene(sceneIndex + 1);
        }
    }

    private int GetCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
