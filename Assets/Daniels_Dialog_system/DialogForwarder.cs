using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogForwarder: MonoBehaviour
{
    private dialogs dialogue;
    private DialogueUtility utility;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = new dialogs();
        utility = GetComponent<DialogueUtility>();
        utility.path = dialogue.startDialog;
    }
}
