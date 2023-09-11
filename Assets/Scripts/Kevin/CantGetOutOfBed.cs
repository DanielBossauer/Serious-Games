using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUPERCharacter;
using TMPro;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;

public class CantGetOutOfBed : MonoBehaviour
{

    [SerializeField] SUPERCharacterAIO sUPERCharacterAIO2;
    [SerializeField] GameObject player;
    [SerializeField] GameObject player2;
    [SerializeField] CantGetOutOfBedClock clockPrefab;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject startButton;

    [SerializeField] float buttonMashDelay = 0.5f;
    [SerializeField] float initialButtonMashDelay = 1f;
    float mashTimer;
    bool pressed;
    bool mashing;
    [SerializeField] GameObject mashText;

    int minigameStage = 0;
    float minigameTime;

    KeyCode keyToMash = KeyCode.Space;

    bool clicking;
    //[SerializeField] OutOfBedClickButton clickButtonPrefab;
    //List<OutOfBedClickButton> spawnedButtons;

    [SerializeField] GiveUpButton giveUpButton;

    [SerializeField] Animator animator;

    [SerializeField] bool crazyClock = false;

    [SerializeField] BedEnergyBar bedEnergyBar;

    [SerializeField] IntrusiveThoughtManager intrusiveThoughtManager;

    //[SerializeField] OutOfBedClickButton energyButtonPrefab;
    //[SerializeField] OutOfBedClickButton depressionButtonPrefab;

    float energyButtonTime;
    float energyLastPlayTime;
    float depressionButtonTime;
    float depressionLastPlayTime;

    [SerializeField] float healthDepleteRate = 0.01f;

    //List<OutOfBedClickButton> storedButtons;

    [SerializeField] string[] intrusiveThoughtsWalking;
    [SerializeField] string[] intrusiveThoughtsLying;
    [SerializeField] string[] intrusiveThoughtsPhoneReply;

    bool isWalking;

    float controlsLastTime;
    float controlsTime;

    CantGetOutOfBedClock clock;

    [SerializeField] bool debugInstantWin;

    bool isNightTime;

    bool phoneUnlocked;
    [SerializeField] GameObject bedPhone;
    [SerializeField] BedPhone screenPhone;
    [SerializeField] GameObject rightButton;
    [SerializeField] GameObject leftButton;
    [SerializeField] GameObject putAwayButton;
    int phoneStage;

    bool watchingOnPhone;

    [SerializeField] VisualEffectsChanger visualEffectsChanger;

    [SerializeField] float clockTimeSpeed = 1f;

    [SerializeField] GameObject textAbovePhone;

    [SerializeField] Light sun;

    [SerializeField] GameObject playerModelHolder;

    [SerializeField] EffectsOnStart effectsOnStart;

    bool gotThroughOneNightTrigger = false;

    [SerializeField] GameObject messenger;

    bool messengerIsOpen;

    private void Awake()
    {
        player2.SetActive(false);
        bedPhone.SetActive(true);

        bedEnergyBar.gameObject.SetActive(false);

        bedPhone.gameObject.GetComponent<DialogueSystemTrigger>().OnUse();

        screenPhone.gameObject.SetActive(false);
        rightButton.SetActive(false);
        leftButton.SetActive(false);
        putAwayButton.SetActive(false);

        intrusiveThoughtManager.KeepTrackOfSpawnedBubbles(true);

        textAbovePhone.SetActive(false);

        messenger.SetActive(false);

        visualEffectsChanger.ChangeBloom(0.9f, new Color(0.4235294f, 0.3019608f, 0.1215686f), 0.9f);
    }

    // Start is called before the first frame update
    void Start()
    {
        //storedButtons = new List<OutOfBedClickButton>();

        //Initialize clock
        
            clock = Instantiate(clockPrefab);

            clock.updateTime = 1/clockTimeSpeed;

            clock.gameObject.transform.parent = canvas.gameObject.transform;
            clock.gameObject.transform.position = new Vector3(Screen.width * 0.2f, Screen.height * 0.2f, 0f);
            clock.Run(this);
            clock.SetTime(6f);

        if (crazyClock)
        {
            clock.crazyClockOn = true;
        }

        //GameObject button = Instantiate(startButton);
        //button.gameObject.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f); ;
        //button.gameObject.transform.parent = canvas.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!crazyClock)
        {
            Quaternion tmpTran = sun.gameObject.transform.rotation;
            tmpTran = Quaternion.Euler(clock.GetTimeAsDecimalFloat()*360/24 - 90, -30, 0);
            sun.gameObject.transform.rotation = tmpTran;
        }
        
        if (!mashing && !clicking && !watchingOnPhone)
        {
            StartCoroutine(IntrusiveThoughtsWhileLyingInBed());
        }

        if (watchingOnPhone)
        {
            intrusiveThoughtManager.DeleteAllThoughts();
        }

        if (mashing)
        {
            mashTimer -= Time.deltaTime;

            if (Input.GetKeyDown(keyToMash) && !pressed)
            {
                pressed = true;
                mashTimer = buttonMashDelay;
            }
            else if (Input.GetKeyUp(keyToMash))
            {
                pressed = false;
            }

            if (mashTimer <= 0 || phoneUnlocked)
            {
                mashText.GetComponent<TextMeshProUGUI>().text = "F A I L !";
                minigameStage = 0;
                mashText.transform.position = new Vector3(Screen.width*0.5f,Screen.height*0.6f,1f);
                startButton.SetActive(true);
                mashing = false;
            }

            //3 seconds passed
            if (Time.realtimeSinceStartup >= minigameTime + 3f)
            {
                mashing = false;

                minigameStage++;
                if (minigameStage == 3 || minigameStage == 7 || minigameStage == 15) InitClicking();
                else InitMashing();
            }

            if (debugInstantWin)
            {
                GetOutOfBed();
            }
        }

        if (clicking)
        {
            StopCoroutine(IntrusiveThoughtsWhileLyingInBed());

            /*
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
                clicking = false;

                minigameStage++;
                if (minigameStage < 10) InitClicking();
                else GetOutOfBed();
            }
            */

            if (bedEnergyBar.GetValue() <= 0 || phoneUnlocked)
            {
                mashText.gameObject.SetActive(true);
                mashText.GetComponent<TextMeshProUGUI>().text = "F A I L !";
                minigameStage = 0;
                
                mashText.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.6f, 1f);
                startButton.SetActive(true);
                bedEnergyBar.gameObject.SetActive(false);
                mashing = false;
                clicking = false;

                ClearAllClickingButtons();
            }

            //20 seconds passed
            if (Time.realtimeSinceStartup >= minigameTime + 20f)
            {
                mashText.gameObject.SetActive(true);

                clicking = false;
                bedEnergyBar.gameObject.SetActive(false);
                ClearAllClickingButtons();

                minigameStage++;
                if (minigameStage < 16) InitMashing();
                else GetOutOfBed();
            }

            //3 seconds passed
            if (Time.realtimeSinceStartup >= minigameTime + 3f)
            {
                mashText.gameObject.SetActive(false);
            }
        }

        if (!isNightTime && clock.IsNightTime())
        {
            isNightTime = true;
            StartCoroutine(NightTimeRoutine());

            if (!watchingOnPhone) visualEffectsChanger.HouseNightTime();
            else visualEffectsChanger.HouseDayTime();
        }

        if ((isNightTime && !clock.IsNightTime()))
        {
            isNightTime = false;

            if (!watchingOnPhone) visualEffectsChanger.HouseDayTime();
            else effectsOnStart.Start();
        }

        


    }

    void ClearAllClickingButtons()
    {
        /*
        foreach (OutOfBedClickButton b in storedButtons)
        {
            if(b != null) Destroy(b.gameObject);
        }
        storedButtons.Clear();
        */

        intrusiveThoughtManager.DeleteAllThoughts();
    }

    void StartGettingUpAnimation()
    {
        animator.SetBool("isGettingUp", true);
    }

    public void InitMashing()
    {
        if (!mashing)
        {
            startButton.SetActive(false);
            StartMashing();
        }
    }

    void StartMashing()
    {
        minigameTime = Time.realtimeSinceStartup;

        mashTimer = initialButtonMashDelay;

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

        mashText.transform.position = new Vector3(Random.Range(Screen.width*0.4f, Screen.width * 0.6f), Random.Range(Screen.height * 0.4f, Screen.height * 0.6f), 1f);

        mashText.SetActive(true);

        mashing = true;
    }


    void InitClicking()
    {
        minigameTime = Time.realtimeSinceStartup;
        StartClicking();
    }


    void StartClicking()
    {
        //minigameTime = Time.realtimeSinceStartup;

        mashText.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.6f, 1f);
        mashText.GetComponent<TextMeshProUGUI>().text = "Click The 'ENERGY' Buttons Quickly!";
        //OutOfBedClickButton clickbutton = Instantiate(clickButtonPrefab);
        //spawnedButtons.Add(clickbutton);

        bedEnergyBar.IncreaseValue(1f);
        bedEnergyBar.gameObject.SetActive(true);

        clicking = true;

        energyButtonTime = Random.Range(0f,3f);
        energyLastPlayTime = Time.realtimeSinceStartup;
        depressionButtonTime = Random.Range(0f, 1f);
        depressionLastPlayTime = Time.realtimeSinceStartup;
        StartCoroutine(SpawnButtons());
    }

    IEnumerator SpawnButtons()
    {
        while (clicking)
        {
            if (Time.realtimeSinceStartup > energyLastPlayTime + energyButtonTime)
            {
                OutOfBedClickButton button = intrusiveThoughtManager.MakeEnergyButtonAppear();
                button.cantGetOutOfBed = this;
                //storedButtons.Add(button);
                energyButtonTime = Random.Range(0f, 3f);
                energyLastPlayTime = Time.realtimeSinceStartup;
            }
            if (Time.realtimeSinceStartup > depressionLastPlayTime + depressionButtonTime)
            {
                OutOfBedClickButton button = intrusiveThoughtManager.MakeDepressionButtonAppear();
                button.cantGetOutOfBed = this;
                //storedButtons.Add(button);
                depressionButtonTime = Random.Range(0f, 1f);
                depressionLastPlayTime = Time.realtimeSinceStartup;
            }

            bedEnergyBar.DecreaseValue(healthDepleteRate);

            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }

    public void EnergyButtonClicked(float energy)
    {
        if(clicking) bedEnergyBar.IncreaseValue(energy);
    }

    public void DepressionButtonClicked(float energy)
    {
        if (clicking) bedEnergyBar.DecreaseValue(energy);
    }

    void GetOutOfBed()
    {
        clicking = false;
        mashing = false;
        mashText.SetActive(true);
        mashText.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.6f, 1f);
        mashText.GetComponent<TextMeshProUGUI>().text = "Find the door!";

        if (bedPhone.transform.GetChild(0) != null) bedPhone.transform.GetChild(0).gameObject.SetActive(false);

        //sUPERCharacterAIO2.enableMovementControl = true;
        player.gameObject.SetActive(false);
        player2.gameObject.SetActive(true);
        playerModelHolder.gameObject.SetActive(false);

        isWalking = true;

        //clock.Stop();

        StartCoroutine(IntrusiveThoughtsWhileWalking());
    }

    IEnumerator IntrusiveThoughtsWhileWalking()
    {
        while (isWalking)
        {
            if (Time.realtimeSinceStartup > depressionLastPlayTime + depressionButtonTime)
            {
                intrusiveThoughtManager.MakeThoughtAppear(intrusiveThoughtsWalking[Random.Range(0,intrusiveThoughtsWalking.Length)]);
                //button.cantGetOutOfBed = this;
                //storedButtons.Add(button);
                depressionButtonTime = Random.Range(1f, 2f);
                depressionLastPlayTime = Time.realtimeSinceStartup;
            }

            if (Time.realtimeSinceStartup > controlsLastTime + controlsTime)
            {
                ScrewUpControls();
                controlsTime = Random.Range(5f, 8f);
                controlsLastTime = Time.realtimeSinceStartup;
            }

            sUPERCharacterAIO2.walkingSpeed = Random.Range(0f,100f);

            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator IntrusiveThoughtsWhileLyingInBed()
    {
        while (!mashing && !clicking && !watchingOnPhone)
        {
            if (Time.realtimeSinceStartup > depressionLastPlayTime + depressionButtonTime)
            {
                intrusiveThoughtManager.MakeThoughtAppear(intrusiveThoughtsLying[Random.Range(0, intrusiveThoughtsWalking.Length)]);
                //button.cantGetOutOfBed = this;
                //storedButtons.Add(button);
                depressionButtonTime = Random.Range(2f, 10f);
                depressionLastPlayTime = Time.realtimeSinceStartup;
            }
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }

    void GoToBedAgain()
    {
        clock.Run(this);
        isWalking = false;
        player2.SetActive(false);
        player2.transform.position = new Vector3();
        player.SetActive(true);
        playerModelHolder.gameObject.SetActive(true);
    }

    void ScrewUpControls()
    {
        //sUPERCharacterAIO2
    }

    IEnumerator NightTimeRoutine()
    {

        clock.crazyClockOn = true;

        startButton.SetActive(false);

        //give up button stuff
        Vector3 initScale = giveUpButton.gameObject.transform.localScale;
        float maxScale = 10f;
        float growFactor = 0.05f;

        while (isNightTime)
        {
            //clock.Stop();

            if(!watchingOnPhone) giveUpButton.gameObject.SetActive(true);
            else giveUpButton.gameObject.SetActive(false);

            //grow give up button in size
            if (giveUpButton.gameObject.transform.localScale.x < maxScale)
            {
                Vector3 localScale = giveUpButton.gameObject.transform.localScale;
                float growth = 1 + growFactor * Time.deltaTime;
                giveUpButton.gameObject.transform.localScale = new Vector3(localScale.x * growth, localScale.y * growth, localScale.z * growth);
                giveUpButton.gameObject.transform.position = new Vector3(giveUpButton.transform.position.x + Random.Range(0, 1) * Time.deltaTime, giveUpButton.transform.position.y + Random.Range(0, 1) * Time.deltaTime, giveUpButton.transform.position.z);

            }

            yield return new WaitForEndOfFrame();
        }

        giveUpButton.gameObject.transform.localScale = initScale;

        clock.Run(this);
        clock.crazyClockOn = false;

        startButton.SetActive(true);
        giveUpButton.gameObject.SetActive(false);

        gotThroughOneNightTrigger = true;

        yield return null;
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



    public void UnlockPhone()
    {
        if (!phoneUnlocked)
        {
            phoneUnlocked = true;


            mashText.GetComponent<TextMeshProUGUI>().text = "F A I L !";

            mashText.SetActive(false);
            
            


            bedPhone.gameObject.SetActive(false);
            screenPhone.gameObject.SetActive(true);
            putAwayButton.gameObject.SetActive(true);
            startButton.SetActive(false);

            //RESET MINIGAMES
            minigameStage = 0;
            mashText.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.6f, 1f);
            startButton.SetActive(false);
            bedEnergyBar.gameObject.SetActive(false);
            mashing = false;
            clicking = false;

            textAbovePhone.SetActive(true);

            if (phoneStage == 0)
            {
                PhoneScrollLeft();
            }
            else if (phoneStage == 1)
            {
                PhoneScrollRight();
            }
        }
    }

    public void PhoneScrollRight()
    {
        phoneStage = 1;
        leftButton.SetActive(true);
        rightButton.SetActive(false);

        Debug.Log("PhoneScrollRight");

        textAbovePhone.GetComponent<TextMeshProUGUI>().text = "Messenger";
        screenPhone.WhiteScreen();

        NotWatchingOnPhone();

        messenger.SetActive(true);
        messengerIsOpen = true;
        StartCoroutine(IntrusiveThoughtsWhileMessaging());
    }

    IEnumerator IntrusiveThoughtsWhileMessaging()
    {

        float messagingLastPlayTime = 0f;
        float messagingButtonTime = 0f;

        while (messengerIsOpen)
        {
            
            if (Time.realtimeSinceStartup > messagingLastPlayTime + messagingButtonTime)
            {
                intrusiveThoughtManager.MessengerBubbles(intrusiveThoughtsPhoneReply[Random.Range(0, intrusiveThoughtsPhoneReply.Length)]);
                //button.cantGetOutOfBed = this;
                //storedButtons.Add(button);
                messagingButtonTime = 0.5f;
                messagingLastPlayTime = Time.realtimeSinceStartup;
            }
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }

    public void PhoneScrollLeft()
    {
        phoneStage = 0;
        leftButton.SetActive(false);
        rightButton.SetActive(true);

        textAbovePhone.GetComponent<TextMeshProUGUI>().text = "Short Videos";

        WatchingOnPhone();
        screenPhone.WhiteScreen();

        messenger.SetActive(false);
        messengerIsOpen = false;

        Debug.Log("PhoneScrollLeft");
    }

    public void PutPhoneAway()
    {
        phoneUnlocked = false;
        bedPhone.gameObject.SetActive(true);
        screenPhone.gameObject.SetActive(false);
        putAwayButton.gameObject.SetActive(false);
        leftButton.SetActive(false);
        rightButton.SetActive(false);

        startButton.SetActive(true);

        textAbovePhone.SetActive(false);

        messenger.SetActive(false);
        messengerIsOpen = false;

        NotWatchingOnPhone();
    }
    
    public void WatchingOnPhone()
    {
        if (!watchingOnPhone)
        {
            visualEffectsChanger.ChangeBloom(10f, new Color(0.2470588f, 0.5845474f, 0.7647059f), 0.1f);
            if (!isNightTime) effectsOnStart.Start();
            else visualEffectsChanger.HouseDayTime();
            clock.SetSpeed(2*clockTimeSpeed);
            watchingOnPhone = true;
        }
        
    }

    public void NotWatchingOnPhone()
    {
        if (watchingOnPhone)
        {
            visualEffectsChanger.ChangeBloom(0.9f, new Color(0.4235294f, 0.3019608f, 0.1215686f), 0.9f);
            clock.ResetSpeed();
            watchingOnPhone = false;

            if (isNightTime) visualEffectsChanger.HouseNightTime();
            else if (!isNightTime && gotThroughOneNightTrigger) visualEffectsChanger.HouseDayTime();
            else effectsOnStart.Start();
        }
    }

}
