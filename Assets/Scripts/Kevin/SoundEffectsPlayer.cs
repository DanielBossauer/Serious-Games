using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsPlayer : MonoBehaviour
{
    [SerializeField] AudioSource src;
    [SerializeField] AudioClip[] audioClips;

    // Start is called before the first frame update
    void Awake()
    {
        if (src == null) this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SFX1()
    {
        src.clip = audioClips[0];
        src.Play();
    }

    public void SFX2()
    {
        src.clip = audioClips[1];
        src.Play();
    }

    public void Stop()
    {
        src.Stop();
    }

    public void ChangePitch(string newPitch)
    {
        var sStrings = newPitch.Split(","[0]);
        float x = float.Parse(sStrings[0]);
        src.pitch = x;
    }

    public void ChangeVolume(string newVolume)
    {
        var sStrings = newVolume.Split(","[0]);
        float x = float.Parse(sStrings[0]);
        src.volume = x;
    }
}
