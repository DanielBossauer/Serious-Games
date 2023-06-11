using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ViewCalender : MonoBehaviour
{
    [SerializeField] Camera cam1;
    [SerializeField] Camera cam2;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] bool canMove;
    [SerializeField] GameObject gameObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            cam1.enabled = (true);
            cam2.enabled = (false);
            playerMovement.enabled = (canMove);
        }
    }
}
