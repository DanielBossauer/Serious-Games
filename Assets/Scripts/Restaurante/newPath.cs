using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPath : MonoBehaviour
{
    public DialogueUtility obj;
    public int index;

    public void triggerDialogueUtility()
    {
        obj.SplitAndEnqueue(index);
    } 
}
