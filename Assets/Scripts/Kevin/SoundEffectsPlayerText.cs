using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsPlayerText : MonoBehaviour
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
}
