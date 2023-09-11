using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressETriggered : MonoBehaviour
{
    [SerializeField] GameObject sprite;

    public bool canTrigger;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (canTrigger) {
            sprite.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        sprite.SetActive(false);
    }
}
