using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChurchAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoBackHome()
    {
        if(DialogueManager.instance != null)
        {
            DialogueManager.StopAllConversations();
            Destroy(DialogueManager.instance.gameObject);
        }
        SceneManager.LoadScene("Home");
    }
}
