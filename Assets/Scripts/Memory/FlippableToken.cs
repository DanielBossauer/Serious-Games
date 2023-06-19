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
        // get current matching
        matched = gameControl.GetComponent<GameControl>().matchedIndexes[index];
        // already matched token wll not react
        if (!matched) {
            // token is not selected
            if(spriteRenderer.sprite == back) {
                if (!gameControl.GetComponent<GameControl>().TwoCardsUp()) {
                    spriteRenderer.sprite = faces[index];
                    gameControl.GetComponent<GameControl>().SelectToken(index);
                    gameControl.GetComponent<GameControl>().CheckMatch();
                }
            } else
            {
                // turn card
                spriteRenderer.sprite = back;
                gameControl.GetComponent<GameControl>().RemoveSelectedToken(index);
            }
        }
    }

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameControl = GameObject.Find("GameControl");
    }
}
