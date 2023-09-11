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

    public bool GetIsClickable()
    {
        return clickable;
    }

    public void OnClick()
    {
        if (clickable)
        {

        }
    }
}