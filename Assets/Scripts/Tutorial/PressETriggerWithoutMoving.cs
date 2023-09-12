using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class PressETriggerWithoutMovingWhenDialogFinished : MonoBehaviour
{
    [SerializeField] GameObject sprite;

    void Update()
    {
        if (DialogueLua.GetVariable("Finished_Scene").AsBool) {
            sprite.SetActive(true);
        }
    }

}