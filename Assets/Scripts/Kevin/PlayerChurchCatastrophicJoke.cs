using PixelCrushers.DialogueSystem;
using SUPERCharacter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerChurchCatastrophicJoke : MonoBehaviour
{

    public bool alreadyCalled = false;

    [SerializeField] Light[] suns;

    [SerializeField] float someEmpiricConstantClamp = 0.05f; //the higher the less is the effect
    [SerializeField] float someEmpiricConstantMakeRed = 0.05f;

    [SerializeField] float distance = 10f;

    [SerializeField] GameObject didi;

    [SerializeField] GameObject player;

    bool didiDialogueEffects = false;

    SUPERCharacterAIO superCharacter;

    [SerializeField] Volume m_Volume;

    [SerializeField] LerpManager lerper;

    [SerializeField] SoundEffectsPlayer soundEffectsPlayer;

    [SerializeField] SoundEffectsPlayer2 soundEffectsPlayer2;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null) player = this.gameObject;
        superCharacter = player.gameObject.GetComponent<SUPERCharacterAIO>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alreadyCalled)
        {
            //make all lights red over time
            if (suns != null && suns[0] != null)
            {
                foreach (Light sun in suns)
                {
                    if (sun != null) sun.color = new Color(sun.color.r, Mathf.Clamp01(distance * someEmpiricConstantClamp), Mathf.Clamp01(distance * someEmpiricConstantClamp));
                }

            }


            if (distance > 0) distance -= Mathf.Abs(Time.deltaTime * someEmpiricConstantMakeRed);
            else
            {
                distance = 0;
                DidiDialogue();
                alreadyCalled = false;
            } 
        }

        /*
        if (distance == 0 && !didiDialogueStarted)
        {
            
            didiDialogueStarted = true;
        }
        */
    }

    public void SetDidiDialogueEffectsFalse()
    {
        didiDialogueEffects = false;
    }

    public void CatastrophicJoke()
    {
        if (!alreadyCalled)
        {
            alreadyCalled = true;
            PlayStatic();
        }
    }

    void DidiDialogue()
    {
        //didi.gameObject.transform.position = new Vector3(1.75f,0,-9f);
        
        //activate next conversation
        didi.GetComponent<DialogueSystemTrigger>().OnUse();

        
    }

    public void DidiDialogue2()
    {
        //DialogueManager.StopAllConversations();

        //didi.GetComponent<DialogueSystemTrigger>().OnUse();

        player.GetComponent<SUPERCharacterAIO>().enableCameraControl = false;
        player.GetComponent<SUPERCharacterAIO>().playerCamera.transform.rotation = Quaternion.identity;
        StartCoroutine(MovePlayer());
        StartCoroutine(DidiDialogueEffects());
    }



    IEnumerator MovePlayer()
    {
        lerper.Rect = player;
        lerper.StartPoint = player.gameObject.transform;
        GameObject tmp = new GameObject();
        //tmp.transform.position = new Vector3(1.75f, 0, -9f);
        tmp.transform.position = new Vector3(10f, 0, -10.25f);
        tmp.transform.rotation = Quaternion.Euler(new Vector3(0,90f,0));
        lerper.EndPoint = tmp.transform;

        yield return StartCoroutine(lerper.LerpRectAndRotationFixedTimeOneWay());
        didi.gameObject.transform.LookAt(player.transform);
    }


    IEnumerator DidiDialogueEffects()
    {
        superCharacter.rotationWeight = 20f;

        VolumeProfile profile = m_Volume.sharedProfile;
        if (!profile.TryGet<FilmGrain>(out var grain))
        {
            grain = profile.Add<FilmGrain>(false);
        }

        didiDialogueEffects = true;

        while (didiDialogueEffects)
        {
            grain.type = new FilmGrainLookupParameter((FilmGrainLookup)9, true);
            grain.intensity.Override(Mathf.Clamp01(1));


            //Application.targetFrameRate = Mathf.FloorToInt(Random.Range(0, 60f));






            if (!profile.TryGet<Vignette>(out var vignette))
            {
                vignette = profile.Add<Vignette>(false);
            }

            vignette.intensity.Override(Mathf.Clamp01(1 - Random.Range(0, 1f)));
            vignette.smoothness.Override(Mathf.Clamp01(1 - Random.Range(0, 1f)));


            yield return new WaitForEndOfFrame();
        }
        

        yield return null;
    }

    public void PlayStaticAndHeart()
    {
        soundEffectsPlayer.SFX1();
        soundEffectsPlayer2.SFX1();
    }

    public void PlayEpilepsy()
    {
        soundEffectsPlayer.SFX2();
        soundEffectsPlayer2.SFX2();
    }

    public void PlayStatic()
    {
        soundEffectsPlayer.SFX1();
        soundEffectsPlayer2.Stop();
    }
}
