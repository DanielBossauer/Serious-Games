using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;

public class ChildhoodClassroomDoor : MonoBehaviour
{
    AudioSource audio;

    [SerializeField] DialogueSystemTrigger extraConvo;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Change Scene when Rose touches Door
    private void OnTriggerEnter2D(Collider2D collision)
    {
        audio.Play();
        StartCoroutine(NextSceneWithDelay());
    }


    public IEnumerator NextSceneWithDelay() {

        if (DialogueManager.isConversationActive)
        {
            
            DialogueManager.StopAllConversations(); 
            extraConvo.OnUse();
            yield return new WaitForSeconds(3f);

        }
        
            yield return new WaitForSeconds(0.2f);
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
