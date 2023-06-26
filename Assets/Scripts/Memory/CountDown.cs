using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    GameObject gameControl;
    SpriteRenderer spriteRenderer;
    public Sprite[] counter;
    public int currentIndex;

    void Start() {
        currentIndex = counter.Length - 1;
        UpdateSprite();
    }

    public void NextNumber() {      
        currentIndex -= 1;
        UpdateSprite(); 
        // Check for Loss
        if (currentIndex == 0) {
            gameControl.GetComponent<GameControl>().CleardFailure();
            return;
        }  
    }

    private void UpdateSprite() {
        spriteRenderer.sprite = counter[currentIndex];
    }

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameControl = GameObject.Find("GameControl");
    }
}
