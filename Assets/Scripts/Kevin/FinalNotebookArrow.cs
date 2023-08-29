using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FinalNotebookArrow : MonoBehaviour
{
    bool clickable;

    public void SetClickable(bool b)
    {
        clickable = b;
    }

    public void OnClick()
    {
        if (clickable)
        {

        }
    }
}