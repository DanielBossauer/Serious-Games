using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroductionHomeEvents : MonoBehaviour
{

    [SerializeField] GameObject objectToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<DialogueSystemTrigger>().OnUse();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRosesFriend(string s = "true")
    {
        if(s == "true") objectToSpawn.SetActive(true);
        else objectToSpawn.SetActive(false);
    }

    public void StartNextScene()
    {
        DialogueManager.StopAllConversations();
        Destroy(DialogueManager.instance.gameObject);
        SceneManager.LoadScene("Tutorial_Daniel");
    }

    public void BackToTherapist()
    {
        DialogueManager.StopAllConversations();
        Destroy(DialogueManager.instance.gameObject);
        SceneManager.LoadScene("BackToTherapist2");
    }
}
