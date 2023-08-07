using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;

public class NotebookTimer : MonoBehaviour
{

    [SerializeField] int timer = 60;
    TextMeshProUGUI tmPro;
    int currentTime;
    NotebookManager notebookManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateTimer()
    {

    }

    private void OnEnable()
    {
        tmPro = this.gameObject.GetComponent<TextMeshProUGUI>();
        //tmPro.text = "0:" + timer;
        currentTime = timer;
        StartCoroutine(CountDown());
    }

    public void SetNotebookManager(NotebookManager n)
    {
        this.notebookManager = n;
    }

    IEnumerator CountDown()
    {
        while (currentTime!=0)
        {
            currentTime -= 1;
            if (currentTime >= 10) tmPro.text = "0:" + currentTime;
            else tmPro.text = "0:0" + currentTime;
            yield return new WaitForSeconds(1);
        }

        //Time is over, save string in input field and go to next scene
        for (int i = DialogueManager.instance.activeConversations.Count - 1;i>=0;i--)
        {
            DialogueManager.instance.activeConversations[i].conversationController.Close();
        }
        //SceneManager.LoadScene("Church_Friend");
        notebookManager.CallNextScene();
    }
}
