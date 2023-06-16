using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippableToken : MonoBehaviour
{
    GameObject gameControl;
    SpriteRenderer spriteRenderer;
    public Sprite[] faces;
    public Sprite back;
    public int faceIndex;
    public bool matched;

    public void OnMouseDown() {
        // get current matching
        matched = gameControl.GetComponent<GameControl>().matchedIndexes[faceIndex];
        // already matched token wll not react
        if (!matched) {
            if(spriteRenderer.sprite == back) {
                if (!gameControl.GetComponent<GameControl>().TwoCardsUp()) {
                    spriteRenderer.sprite = faces[faceIndex];
                    gameControl.GetComponent<GameControl>().SelectToken(faceIndex);
                    gameControl.GetComponent<GameControl>().CheckMatch();
                }
            } else
            {
                // turn card
                spriteRenderer.sprite = back;
                gameControl.GetComponent<GameControl>().RemoveSelectedToken(faceIndex);
            }
        }
    }

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameControl = GameObject.Find("GameControl");
    }
}
