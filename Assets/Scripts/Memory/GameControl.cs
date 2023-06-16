using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    GameObject flipToken;
    GameObject openToken;
    // Both Lists must be as long as size of Token Array
    List<int> openIndexes = new List<int> {0,1,2,3,4};
    List<int> flipIndexes = new List<int> {0,1,2,3,4};
    public List<bool> matchedIndexes = new List<bool> {false, false, false, false, false};
    public static System.Random rand = new System.Random();
    public int shuffleNum = 0;
    int[] selectedTokens = {-1, -2};

    void Start() {

        int originalListLength = openIndexes.Count;
        float yPositionUp = 2.3f;
        float xPositionUp = -2.2f;
        float yPositionDown = -2.3f;
        float xPositionDown = -2.2f;
        // generate cards starting with the second one
        for (int i = 1; i < originalListLength; i++) {

            // instantiate Open Tokens
            shuffleNum = rand.Next(0, (openIndexes.Count));
            var temp2 = Instantiate(openToken, new Vector3(xPositionUp, yPositionUp, 0),
                Quaternion.identity);
            temp2.GetComponent<OpenToken>().faceIndex = openIndexes[shuffleNum];
            openIndexes.Remove(openIndexes[shuffleNum]);
            xPositionUp = xPositionUp + 3;

            // instantiate flippable Tokens
            shuffleNum = rand.Next(0, (flipIndexes.Count));
            var temp = Instantiate(flipToken, new Vector3(xPositionDown, yPositionDown, 0),
                Quaternion.identity);
            temp.GetComponent<FlippableToken>().faceIndex = flipIndexes[shuffleNum];
            flipIndexes.Remove(flipIndexes[shuffleNum]);
            xPositionDown = xPositionDown + 3;

        }
        flipToken.GetComponent<FlippableToken>().faceIndex = flipIndexes[0];
        openToken.GetComponent<OpenToken>().faceIndex = openIndexes[0];
    }
    
    public bool TwoCardsUp() {
        if(selectedTokens[0] > -1 && selectedTokens[1] > -1) {
            return true;
        }
        return false;
    }

    public void SelectToken(int index) {
        if (selectedTokens[0] < 0) {
            selectedTokens[0] = index;
        } else if (selectedTokens[1] < 0) {
            selectedTokens[1] = index;
        }

    }

    public void RemoveSelectedToken(int index) {
        if (selectedTokens[0] == index) {
            selectedTokens[0] = -1;
        } else if (selectedTokens[1] == index) {
            selectedTokens[1] = -2;
        }
    }

    public void CheckMatch() {
        if (selectedTokens[0] == selectedTokens[1]) {
            matchedIndexes[selectedTokens[0]] = true;
            selectedTokens[0] = -1;
            selectedTokens[1] = -2;
        }
    }

    private void Awake() {
        flipToken = GameObject.Find("FlippableToken");
        openToken = GameObject.Find("OpenToken");
    }
}
