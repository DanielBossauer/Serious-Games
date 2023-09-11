using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RectanglePart : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool allowedToPass;

    bool mouseOverObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void SetMouserOverObject(bool b)
    {
        mouseOverObject = b;
    }
    

    public bool CheckForMouseOnTop()
    {
        return mouseOverObject;
    }

    /*
    private void OnMouseOver()
    {
        mouseOverObject = true;
    }

    private void OnMouseExit()
    {
        mouseOverObject = false;
    }
    */

    /*
    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
    */


    //Do this when the cursor enters the rect area of this selectable UI object.
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("The cursor entered the selectable UI element.");
        mouseOverObject = true;
    }

    //Do this when the cursor exits the rect area of this selectable UI object.
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("The cursor exited the selectable UI element.");
        mouseOverObject = false;
    }
}
