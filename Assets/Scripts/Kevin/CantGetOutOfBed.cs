using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUPERCharacter;
using TMPro;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;

public class CantGetOutOfBed : MonoBehaviour
{

    [SerializeField] SUPERCharacterAIO SUPERCharacterAIO;
    [SerializeField] GameObject player;
    [SerializeField] CantGetOutOfBedClock clockPrefab;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject startButton;

    [SerializeField] float buttonMashDelay = 0.5f;
    float mash;
    bool pressed;
    bool mashing;
    [SerializeField] GameObject mashText;

    int minigameStage = 0;
    float minigameTime;

    KeyCode keyToMash = KeyCode.Space;

    bool clicking;
    [SerializeField] OutOfBedClickButton clickButtonPrefab;
    List<OutOfBedClickButton> spawnedButtons;

    [SerializeField] GiveUpButton giveUpButton;

    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize clock
        CantGetOutOfBedClock clock = Instantiate(clockPrefab);
        clock.gameObject.transform.parent = canvas.gameObject.transform;
        clock.gameObject.transform.position = new Vector3(Screen.width*0.2f, Screen.height * 0.2f, 0f);
        clock.Run(this);
        clock.SetTime(6f);

        GameObject button = Instantiate(startButton);
        button.gameObject.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f); ;
        button.gameObject.transform.parent = canvas.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (mashing)
        {
            mash -= Time.deltaTime;

            if (Input.GetKeyDown(keyToMash) && !pressed)
            {
                pressed = true;
                mash = buttonMashDelay;
            }
            else if (Input.GetKeyUp(keyToMash))
            {
                pressed = false;
            }

            if (mash <= 0)
            {
                mashText.GetComponent<TextMeshProUGUI>().text = "F A I L !";
                mashing = false;
            }

            //3 seconds passed
            if (Time.realtimeSinceStartup >= minigameTime + 3f)
            {
                minigameStage++;
                if (minigameStage < 5) StartMashing();
                else StartClicking();
            }
        }

        if (clicking)
        {
            foreach (OutOfBedClickButton button in spawnedButtons)
            {
                if (button.timeUp)
                {
                    mashText.GetComponent<TextMeshProUGUI>().text = "F A I L !";
                    clicking = false;
                }
            }

            //3 seconds passed
            if (Time.realtimeSinceStartup >= minigameTime + 3f)
            {
                minigameStage++;
                if (minigameStage < 10) StartClicking();
                else GetOutOfBed();
            }
        }
    }

    void StartGettingUpAnimation()
    {
        animator.SetBool("isGettingUp", true);
    }

    public void StartMashing()
    {
        minigameTime = Time.realtimeSinceStartup;

        mash = buttonMashDelay;

        int randomVal = Random.Range(0,4);

        switch (randomVal)
        {
            case 0:
                mashText.GetComponent<TextMeshProUGUI>().text = "Mash Space!!!";
                keyToMash = KeyCode.Space;
                break;
            case 1:
                mashText.GetComponent<TextMeshProUGUI>().text = "Mash W!!!";
                keyToMash = KeyCode.W;
                break;
            case 2:
                mashText.GetComponent<TextMeshProUGUI>().text = "Mash H!!!";
                keyToMash = KeyCode.H;
                break;
            case 3:
                mashText.GetComponent<TextMeshProUGUI>().text = "Mash Y!!!";
                keyToMash = KeyCode.Y;
                break;
            default:
                mashText.GetComponent<TextMeshProUGUI>().text = "Mash Space!!!";
                keyToMash = KeyCode.Space;
                break;
        }


        mashText.SetActive(true);

        mashing = true;
    }


    public void StartClicking()
    {
        minigameTime = Time.realtimeSinceStartup;
        mashText.GetComponent<TextMeshProUGUI>().text = "Click The 'ENERGY' Buttons Quickly!";
        OutOfBedClickButton clickbutton = Instantiate(clickButtonPrefab);
        spawnedButtons.Add(clickbutton);
    }

    void GetOutOfBed()
    {

    }

    public void DoorReached()
    {
        SceneManager.LoadScene("Church_Attack");
    }





    public void StartNightTime()
    {

    }

    IEnumerator NightTime()
    {
        yield return null;
    }

    //and end night time
    public void StartDayTime()
    {

    }




    //when the "give up" button is clicked
    public void GiveUp()
    {
        //SceneManager.LoadScene("AfterMadness");
        DialogueManager.StopAllConversations();
        Destroy(DialogueManager.instance.gameObject);
        SceneManager.LoadScene("Home");
    }

    public void OpenDoor()
    {
        DialogueManager.StopAllConversations();
        Destroy(DialogueManager.instance.gameObject);
        SceneManager.LoadScene("Church_Attack");
    }
}
