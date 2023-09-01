using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownTest : MonoBehaviour
{
    GameObject gameControl;
    AudioSource audio1;
    AudioSource audio2;
    AudioSource audio3;
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
        if (currentIndex > 5) {
            audio1.Play();
        } else if(currentIndex > 3) {
            audio2.Play();
        } else {
            audio3.Play();
        }
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
        audio1 = this.gameObject.transform.GetChild(0).GetComponent<AudioSource>();
        audio2 = this.gameObject.transform.GetChild(1).GetComponent<AudioSource>();
        audio3 = this.gameObject.transform.GetChild(2).GetComponent<AudioSource>();
    }
}
