using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippableTokenTest : MonoBehaviour
{
    GameObject gameControl;
    SpriteRenderer spriteRenderer;
    public Sprite[] faces; // selected FlippableTokens
    public Sprite back; //Icon_hidden
    public Sprite[] unselectedFaces; // unselected FlippableTokens
    public int index;
    public bool matched;


    public void OnMouseDown() {
        // already matched token wll not react and OpenToken must be flipped first
        if (!matched && !gameControl.GetComponent<GameControlTest>().NoCardsSelected()) {
            // token is not selected
            if(spriteRenderer.sprite == back) {
                if (!gameControl.GetComponent<GameControlTest>().TwoCardsSelected()) {
                    spriteRenderer.sprite = faces[index];
                    gameControl.GetComponent<GameControlTest>().SelectFlipToken(index);
                    gameControl.GetComponent<GameControlTest>().CheckMatch();
                    }
            } else
            {
                FlipCardBack();
            }
        }
    }

    public void FlipCardBack() {
        spriteRenderer.sprite = back;
        gameControl.GetComponent<GameControlTest>().RemoveSelectedFlipToken(index);
    }

    public void DramaticFlip(float dramaticFlipTime) {
        StartCoroutine(Drama(dramaticFlipTime));
    }

    public IEnumerator Drama(float dramaticFlipTime) {
        yield return new WaitForSeconds(dramaticFlipTime);
        // flips
        if (!matched) {
            // animation hier wäre cool
            FlipCardBack();
        }
    }

    public void ShowCard(float showTime) {
        spriteRenderer.sprite = unselectedFaces[index];
        StartCoroutine(ShowTime(showTime));
    }

    public IEnumerator ShowTime(float showTime) {
        yield return new WaitForSeconds(showTime);
        spriteRenderer.sprite = back;
    }

    public void killToken() {
        Destroy(gameObject);
    }

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameControl = GameObject.Find("GameControl");
    }

}
