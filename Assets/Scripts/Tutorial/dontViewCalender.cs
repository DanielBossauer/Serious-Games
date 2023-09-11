using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontViewCalender : MonoBehaviour
{
    [SerializeField] Camera cam1;
    [SerializeField] Camera cam2;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] bool canMove;

    GameObject calendarETrigger;
    GameObject kira;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            calendarETrigger.GetComponent<PressETriggered>().canTrigger = false;
            cam1.enabled = (true);
            cam2.enabled = (false);
            playerMovement.enabled = (canMove);
            // nudge kira out of hitbox so that it deactivates (I know genius solution)
            ChangeKiraPosition();
            this.gameObject.SetActive(false);
        }
    }

    public void ChangeKiraPosition() {
        kira.transform.position -= new Vector3(1.35f,0,0);
    }

    private void Awake() {
        calendarETrigger = GameObject.Find("EpressTrigger");
        kira = GameObject.Find("Kira");
    }
}
