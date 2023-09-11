using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUPERCharacter;

public class PlayerAnimations : MonoBehaviour
{
    Animator animator;
    [SerializeField] SUPERCharacterAIO sUPERCharacterAIO;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if(sUPERCharacterAIO == null) sUPERCharacterAIO = transform.parent.GetComponent<SUPERCharacterAIO>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sUPERCharacterAIO.isIdle)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }
        else if (sUPERCharacterAIO.isSprinting)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isRunning", false);
        }
    }
}
