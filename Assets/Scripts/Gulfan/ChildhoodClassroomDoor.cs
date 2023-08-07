using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;

public class ChildhoodClassroomDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Change Scene when Rose touches Door
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int sceneIndex = GetCurrentSceneIndex();
        // Test for existing dialogue manager
        if (DialogueManager.instance != null)
        {
            DialogueManager.StopAllConversations();
            Destroy(DialogueManager.instance.gameObject);
        }
        SceneManager.LoadScene(sceneIndex + 1);
    }

    private int GetCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
