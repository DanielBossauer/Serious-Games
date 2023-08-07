using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CafeteriaManager : MonoBehaviour
{
    [SerializeField] GameObject convoTrigger;

    [SerializeField] GameObject Player;

    [SerializeField] GameObject playerTable;

    bool moveTable;

    bool moveTableInfinitely;

    [SerializeField] float speed;

    float startScale;
    float endScale;
    float startPosTableX;

    Vector3 playerEndPosition;

    // Start is called before the first frame update
    void Start()
    {
        convoTrigger.GetComponent<DialogueSystemTrigger>().OnUse();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTable)
        {
            Transform tr = playerTable.gameObject.transform;

            playerTable.gameObject.transform.localScale = new Vector3(tr.localScale.x + Time.deltaTime * speed * 0.8f, tr.localScale.y, tr.localScale.z);
            //playerTable.gameObject.transform.position = new Vector3(tr.position.x - (((tr.localScale.x + Time.deltaTime * speed) - startScale) / 2), tr.position.y, tr.position.z);
            playerTable.gameObject.transform.position = new Vector3(tr.position.x - Time.deltaTime * speed*0.8f, tr.position.y, tr.position.z);
            Player.transform.position = new Vector3(Player.transform.position.x - Time.deltaTime * speed, playerEndPosition.y, playerEndPosition.z);
            if (tr.localScale.x + Time.deltaTime * speed >= endScale)
            {
                playerTable.gameObject.transform.localScale = new Vector3(endScale, tr.localScale.y, tr.localScale.z);
                playerTable.gameObject.transform.position = new Vector3(startPosTableX - ((endScale-startScale)/2), tr.position.y, tr.position.z);
                //Player.transform.position = new Vector3(Player.transform.position.x - 1f - ((endScale - startScale) / 2), tr.position.y, tr.position.z);
                Player.transform.position = playerEndPosition;
                moveTable = false;
            }


            //playerTable.gameObject.transform.localScale = new Vector3(Mathf.MoveTowards(transform.localScale.x, endScale, Time.deltaTime * speed), tr.localScale.y, tr.localScale.z);

            //playerTable.gameObject.transform.position = playerTable.gameObject.transform.position + playerTable.gameObject.transform.forward * (transform.localScale.z / 2.0f + Mathf.MoveTowards(transform.localScale.x, endScale, Time.deltaTime * speed) / 2.0f);



        }

        if (moveTableInfinitely)
        {
            Transform tr = playerTable.gameObject.transform;
            playerTable.gameObject.transform.localScale = new Vector3(tr.localScale.x + Time.deltaTime * speed * 0.8f * 2f, tr.localScale.y, tr.localScale.z);

            playerTable.gameObject.transform.position = new Vector3(tr.position.x - Time.deltaTime * speed * 0.8f *2f, tr.position.y, tr.position.z);

            Player.transform.position = new Vector3(Player.transform.position.x - Time.deltaTime * speed*2f, playerEndPosition.y, playerEndPosition.z);
        }
    }

    public void MoveTable1()
    {
        endScale = 3f;
        startScale = playerTable.gameObject.transform.localScale.x;
        playerEndPosition = new Vector3(-3f,0.5f,-1.25f);
        startPosTableX = playerTable.gameObject.transform.position.x;
        moveTable = true;
    }

    public void MoveTable2()
    {
        endScale = 4f;
        startScale = playerTable.gameObject.transform.localScale.x;
        playerEndPosition = new Vector3(-4f, 0.5f, -1.25f);
        startPosTableX = playerTable.gameObject.transform.position.x;
        moveTable = true;
    }

    public void MoveTable3()
    {
        endScale = 5f;
        startScale = playerTable.gameObject.transform.localScale.x;
        playerEndPosition = new Vector3(-5f, 0.5f, -1.25f);
        startPosTableX = playerTable.gameObject.transform.position.x;
        moveTable = true;
    }

    public void MoveTable4()
    {
        moveTable = false;
        startScale = playerTable.gameObject.transform.localScale.x;
        startPosTableX = playerTable.gameObject.transform.position.x;
        moveTableInfinitely = true;
    }

    public void CallNextScene()
    {
        DialogueManager.StopAllConversations();
        Destroy(DialogueManager.instance.gameObject);
        SceneManager.LoadScene("Church_Friend_Before");
    }
}
