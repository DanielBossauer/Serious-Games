using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraFromToWhenTriggerd : MonoBehaviour
{
    AudioSource audio;
    public Camera cam1;
    public Camera cam2;

    void Start() {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audio.Play();
        cam1.enabled = (true);
        cam2.enabled = (false);
    }
}
