using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class ActivateETriggerWhenSceneEnds : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        UpdateETrigger();
    }

    private void UpdateETrigger() {
        this.GetComponent<PressETriggered>().canTrigger = DialogueLua.GetVariable("Finished_Scene").AsBool;
    }


}
