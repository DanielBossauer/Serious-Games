using PixelCrushers.DialogueSystem;
using SUPERCharacter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseDoor : MonoBehaviour, IInteractable
{

    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    bool doorAppeared;

    [SerializeField] Canvas canvas;
    [SerializeField] GameObject escapeButton;

    public bool Interact()
    {
        //throw new System.NotImplementedException();
        DialogueManager.StopAllConversations();
        Destroy(DialogueManager.instance.gameObject);
        SceneManager.LoadScene("Church_Attack");
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.gameObject.transform.position,player1.transform.position) < 2f || Vector3.Distance(this.gameObject.transform.position, player2.transform.position) < 2f)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            escapeButton.SetActive(true);
            escapeButton.transform.position = new Vector3(Random.Range(Screen.width*0.3f,Screen.width*0.7f),Random.Range(Screen.height * 0.3f, Screen.height * 0.7f),1f);
            doorAppeared = true;
        }
        else if(doorAppeared)
        {
            //this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            //this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            escapeButton.SetActive(false);
            doorAppeared = false;
        }
    }
}
