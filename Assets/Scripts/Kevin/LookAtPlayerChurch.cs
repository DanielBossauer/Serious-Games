using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayerChurch : MonoBehaviour
{

    [SerializeField] GameObject player;
    //DialogueSystemController dialogueSystemController;
    //DialogueDatabase dialogueDatabase;

    [SerializeField] VisualEffectsChanger visualEffectsChanger;
    PlayerChurchCatastrophicJoke lel;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //dialogueSystemController = gameObject.GetComponent<DialogueSystemController>();
        //dialogueDatabase = dialogueSystemController.initialDatabase;
        //lel = player.GetComponent<PlayerChurchCatastrophicJoke>();
    }

    // Update is called once per frame
    void Update()
    {
        //dialogueDatabase.variables.Find(isShocked);
        
    }

    public void Shocked()
    {
        StartCoroutine(ShockedCoRoutine());
    }

    IEnumerator ShockedCoRoutine()
    {
        yield return new WaitForSeconds(3);

        transform.LookAt(player.transform);

        visualEffectsChanger.CALLVeryNervous0();

        //StartCoroutine(visualEffectsChanger.CALLVeryNervous0);

        if (animator != null) animator.SetBool("isShocked", true);
        else Debug.LogWarning("LookAtPlayerChurch: Animator could not be found on this object.");

        lel = visualEffectsChanger.GetComponent<PlayerChurchCatastrophicJoke>();

        if (!lel.alreadyCalled) lel.CatastrophicJoke();
    }
}
