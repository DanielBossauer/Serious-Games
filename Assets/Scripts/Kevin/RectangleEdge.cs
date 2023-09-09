using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RectangleEdge : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    float time;
    float absoluteGameTime;

    bool mouseOverObject;

    bool setTimeCalled;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnDisable()
    {
        setTimeCalled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //mouseOverObject = IsMouseOverUI();
        if (setTimeCalled)
        {
            Debug.Log("Time.realtimeSinceStartup " + Time.realtimeSinceStartup);
            Debug.Log("absoluteGameTime " + absoluteGameTime);
            Debug.Log("time " + time);
            Debug.Log("absoluteGameTime " + absoluteGameTime);
        }
        
    }

    public void SetTime(float time)
    {
        if (!setTimeCalled)
        {
            Debug.LogWarning("SetTime");
            this.time = time;
            absoluteGameTime = Time.realtimeSinceStartup;
            setTimeCalled = true;
        }
        
    }

    public bool EnoughTimePassed()
    {
        Debug.Log("Time.realtimeSinceStartup" + (Time.realtimeSinceStartup));
        Debug.Log("time + absoluteGameTime" + (time + absoluteGameTime));
        return ((Time.realtimeSinceStartup) > (time + absoluteGameTime));
    }

    public bool CheckForMouseOnTop()
    {
        return mouseOverObject;
    }

    /*
    private void OnMouseOver()
    {
        mouseOverObject = true;
        Debug.Log("OnTop");
    }

    private void OnMouseExit()
    {
        mouseOverObject = false;
        Debug.Log("NotOnTop");
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

    public void SetMouserOverObject(bool b)
    {
        mouseOverObject = b;
    }
}
