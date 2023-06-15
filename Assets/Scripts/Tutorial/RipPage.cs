using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RipPage : MonoBehaviour
{
    Animator anim;

    [SerializeField] Animator animator;
    [SerializeField] string triggerName = "Rip";
    [SerializeField] GameObject eIcon;

    private void OnMouseDown()
    {
        if (animator != null)
        {
            animator.SetTrigger(triggerName);
        }
        eIcon.SetActive(true);
    }
}
