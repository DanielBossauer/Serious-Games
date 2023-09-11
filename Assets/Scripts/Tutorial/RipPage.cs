using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RipPage : MonoBehaviour
{
    Animator anim;
    AudioSource audio;

    [SerializeField] Animator animator;
    [SerializeField] string triggerName = "Rip";
    [SerializeField] GameObject eIcon;

    void Start() {
        audio = GetComponent<AudioSource>();
    }
    private void OnMouseDown()
    {
        if (animator != null)
        {
            animator.SetTrigger(triggerName);
            audio.Play();
        }
        eIcon.SetActive(true);
    }
}
