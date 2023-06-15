using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontViewCalender : MonoBehaviour
{
    [SerializeField] Camera cam1;
    [SerializeField] Camera cam2;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] bool canMove;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            cam1.enabled = (true);
            cam2.enabled = (false);
            playerMovement.enabled = (canMove);
            this.gameObject.SetActive(false);
        }
    }
}
