using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class DialogueManagerUpdateVariable : MonoBehaviour
{

    DialogueSystemController dialogueSystemController;
    DialogueDatabase dialogueDatabase;
    [SerializeField] int responseTimeoutIndex;

    // Start is called before the first frame update
    void Start()
    {
        dialogueSystemController = gameObject.GetComponent<DialogueSystemController>();
        dialogueDatabase = dialogueSystemController.initialDatabase;
    }

    // Update is called once per frame
    void Update()
    {
        dialogueSystemController.displaySettings.inputSettings.responseTimeout = dialogueDatabase.variables[responseTimeoutIndex].InitialFloatValue;
    }
}
