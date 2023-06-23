using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippableToken : MonoBehaviour
{
    GameObject gameControl;
    SpriteRenderer spriteRenderer;
    public Sprite[] faces;
    public Sprite back;
    public int index;
    public bool matched;


    public void OnMouseDown() {
        // already matched token wll not react and OpenToken must be flipped first
        if (!matched && !gameControl.GetComponent<GameControl>().NoCardsSelected()) {
            // token is not selected
            if(spriteRenderer.sprite == back) {
                if (!gameControl.GetComponent<GameControl>().TwoCardsSelected()) {
                    spriteRenderer.sprite = faces[index];
                    gameControl.GetComponent<GameControl>().SelectFlipToken(index);
                    gameControl.GetComponent<GameControl>().CheckMatch();
                    }
            } else
            {
                flipCardBack();
            }
        }
    }

    public void flipCardBack() {
        spriteRenderer.sprite = back;
        gameControl.GetComponent<GameControl>().RemoveSelectedFlipToken(index);
    }

    public void dramaticFlip(float dramaticFlipTime) {
        StartCoroutine(drama(dramaticFlipTime));
    }

    public IEnumerator drama(float dramaticFlipTime) {
        yield return new WaitForSeconds(dramaticFlipTime);
        // flips
        if (!matched) {
            // animation hier wäre cool
            flipCardBack();
        }
    }

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameControl = GameObject.Find("GameControl");
    }

}
