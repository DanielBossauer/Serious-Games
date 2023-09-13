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

    [SerializeField] GameObject trigger;
    [SerializeField] GameObject wall2;

    void Start() {
        audio = GetComponent<AudioSource>();
    }
    private void OnMouseDown()
    {
        if (animator != null)
        {
            animator.SetTrigger(triggerName);
            audio.Play();
            trigger.SetActive(true);
            wall2.SetActive(false);
        }
        eIcon.SetActive(true);
    }
}
