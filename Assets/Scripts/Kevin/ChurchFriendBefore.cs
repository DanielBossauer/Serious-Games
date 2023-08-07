using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChurchFriendBefore : MonoBehaviour
{

    [SerializeField] GameObject dialogueTrigger;

    [SerializeField] GameObject mom;

    // Start is called before the first frame update
    void Start()
    {
        dialogueTrigger.GetComponent<DialogueSystemTrigger>().OnUse();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNextScene()
    {
        DialogueManager.StopAllConversations();
        Destroy(DialogueManager.instance.gameObject);
        SceneManager.LoadScene("");
    }

    public void MakeMumAppear()
    {
        mom.gameObject.SetActive(true);
    }
}
