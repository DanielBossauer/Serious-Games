using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroductionHomeEvents : MonoBehaviour
{

    [SerializeField] GameObject objectToSpawn;

    [SerializeField] IntrusiveThoughtManager intrusiveThoughtManager;

    [SerializeField] GameObject button;

    int indexButton;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<DialogueSystemTrigger>().OnUse();
    }

    private void Awake()
    {
        DespawnRosesFriend();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRosesFriend()
    {
        objectToSpawn.SetActive(true);
        
    }

    public void DespawnRosesFriend()
    {
        objectToSpawn.SetActive(false);
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

    public void GetOutOfBedButton()
    {
        if (indexButton < 4)
        {
            indexButton++;
            intrusiveThoughtManager.ItsUseless();
        }
        else
        {
            button.SetActive(false);
        }
    }
}
