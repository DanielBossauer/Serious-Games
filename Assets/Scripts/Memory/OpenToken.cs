using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenToken : MonoBehaviour
{
    GameObject gameControl;
    SpriteRenderer spriteRenderer;
    public Sprite[] faces; // selected Opentokens
    public Sprite[] backs; // unselected Opentokens
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
                FlipCardBack();
            }
        }
    }

    public void FlipCardBack() {
        spriteRenderer.sprite = backs[index];
        gameControl.GetComponent<GameControl>().RemoveSelectedOpenToken(index);
    }

    public void DramaticFlip(float dramaticFlipTime) {
        StartCoroutine(Drama(dramaticFlipTime));
    }

    public IEnumerator Drama(float dramaticFlipTime) {
        yield return new WaitForSeconds(dramaticFlipTime);
        // flips when player did not flip the FlipToken
        if (!matched && gameControl.GetComponent<GameControl>().TwoCardsSelected()) {
            // animation hier wäre cool
            FlipCardBack();
        }
    }

    public void UpdateBack() {
        spriteRenderer.sprite = backs[index];
    }

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameControl = GameObject.Find("GameControl");
    }

}
