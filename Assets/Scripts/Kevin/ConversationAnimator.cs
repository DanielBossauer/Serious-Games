using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationAnimator : MonoBehaviour
{

    [SerializeField] Animator animator;

    //bool disableAnimations;

    [SerializeField] int conversantID;

    // Start is called before the first frame update
    void Start()
    {
        if(animator == null) animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Arguing()
    {
        if (conversantID == DialogueManager.currentConversationState.subtitle.speakerInfo.id)
        {
            animator.SetBool("isArguing", true);
            animator.SetBool("isTalking", false);
            animator.SetBool("isIdle", false);
        }
        
    }

    public void Idle()
    {
        if (conversantID == DialogueManager.currentConversationState.subtitle.speakerInfo.id)
        {
            animator.SetBool("isArguing", false);
            animator.SetBool("isTalking", false);
            animator.SetBool("isIdle", true);
        }
            
    }

    public void Talking()
    {
        if (conversantID == DialogueManager.currentConversationState.subtitle.speakerInfo.id)
        {
            animator.SetBool("isArguing", false);
            animator.SetBool("isTalking", true);
            animator.SetBool("isIdle", false);
        }
            
    }
}
