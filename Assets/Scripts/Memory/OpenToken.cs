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
        // get current matching
        matched = gameControl.GetComponent<GameControl>().matchedIndexes[index];
        // already matched token wll not react
        if (!matched) {
            // token is not selected
            if(spriteRenderer.sprite == backs[index]) {
                if (!gameControl.GetComponent<GameControl>().TwoCardsUp()) {
                    spriteRenderer.sprite = faces[index];
                    gameControl.GetComponent<GameControl>().SelectToken(index);
                    gameControl.GetComponent<GameControl>().CheckMatch();
                }
            } else
            {
                // turn card
                spriteRenderer.sprite = backs[index];
                gameControl.GetComponent<GameControl>().RemoveSelectedToken(index);
            }
        }
    }

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameControl = GameObject.Find("GameControl");
    }
}
