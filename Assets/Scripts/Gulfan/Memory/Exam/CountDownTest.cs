using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownTest : MonoBehaviour
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
        UpdateScale(0.8f / (currentIndex + 0.3f)); 
        // Check for Loss
        if (currentIndex == 0 && !gameControl.GetComponent<GameControlTest>().gameSuccess) {
            gameControl.GetComponent<GameControlTest>().CleardFailure();
            return;
        }  
    }

    private void UpdateSprite() {
        spriteRenderer.sprite = counter[currentIndex];
    }

    private void UpdateScale(float scaling) {
        this.transform.localScale = this.transform.localScale + new Vector3(scaling, scaling, 0);
    }

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameControl = GameObject.Find("GameControl");
    }
}
