using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenToken : MonoBehaviour
{
    GameObject gameControl;
    SpriteRenderer spriteRenderer;
    public Sprite[] faces;
    public Sprite[] backs;
    public int index;
    public bool matched;


    public void Start() {
        spriteRenderer.sprite = backs[index];
    }

    public void OnMouseDown() {
        // already matched token wll not react and it can only be the first flipped Token
        if (!matched && !gameControl.GetComponent<GameControl>().TwoCardsSelected()) {
            // token is not selected
            if(spriteRenderer.sprite == backs[index] && gameControl.GetComponent<GameControl>().NoCardsSelected()) {
                spriteRenderer.sprite = faces[index];
                gameControl.GetComponent<GameControl>().SelectOpenToken(index);
                gameControl.GetComponent<GameControl>().CheckMatch();
            } else {
                flipCardBack();
            }
        }
    }

    public void flipCardBack() {
        spriteRenderer.sprite = backs[index];
        gameControl.GetComponent<GameControl>().RemoveSelectedOpenToken(index);
    }

    public void dramaticFlip(float dramaticFlipTime) {
        StartCoroutine(drama(dramaticFlipTime));
    }

    public IEnumerator drama(float dramaticFlipTime) {
        yield return new WaitForSeconds(dramaticFlipTime);
        // flips when player did not flip the FlipToken
        if (!matched && gameControl.GetComponent<GameControl>().TwoCardsSelected()) {
            // animation hier wäre cool
            flipCardBack();
        }
    }

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameControl = GameObject.Find("GameControl");
    }

}
