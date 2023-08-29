using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressETriggered : MonoBehaviour
{
    [SerializeField] GameObject sprite;

    public bool canTrigger;

    void Start() {
        canTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
