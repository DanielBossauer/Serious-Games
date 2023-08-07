using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstRealFriend : MonoBehaviour
{

    [SerializeField] GameObject sand;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<DialogueSystemTrigger>().OnUse();
        DialogueManager.instance.transform.GetChild(0).GetComponent<Canvas>().sortingOrder = 200;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeImageToSand()
    {
        StartCoroutine(ChangeImageToSandCoroutine());
    }

    IEnumerator ChangeImageToSandCoroutine()
    {
        yield return new WaitForSeconds(3);
        sand.SetActive(true);
        this.GetComponent<DialogueSystemTrigger>().conversation = "New Conversation 1";
        this.GetComponent<DialogueSystemTrigger>().OnUse();
    }

    public void RestartScene()
    {
        DialogueManager.StopAllConversations();
        Destroy(DialogueManager.instance.gameObject);
        SceneManager.LoadScene("FirstRealFriend");
    }

    public void NextScene()
    {
        DialogueManager.StopAllConversations();
        Destroy(DialogueManager.instance.gameObject);
        SceneManager.LoadScene("CantGetOutOfBed");
    }
}