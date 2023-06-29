using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    GameObject flipToken;
    GameObject openToken;
    GameObject[] flipTokens;
    GameObject[] openTokens;

    GameObject countDown;

    // Both Lists must be as long as size of Token Array
    List<int> openIndexes = new List<int> {0,1,2,3,4};
    List<int> flipIndexes = new List<int> {0,1,2,3,4};
    public static System.Random rand = new System.Random();
    public int shuffleNum = 0;
    // first postion is OpenToken, second is FlipToken negative Value means unselected
    int[] selectedTokens = {-1, -2};

    // Parameters to be changed for each Instance of the Game (currently changing this value does nothing for some reason :) )
    public float dramaticFlipTime;
    public float showTime;


    void Start() {

        int originalListLength = openIndexes.Count;
        float yPositionUp = 2.3f;
        float xPositionUp = -3.2f;
        float yPositionDown = -2.3f;
        float xPositionDown = -3.2f;
        flipTokens = new GameObject[openIndexes.Count];
        openTokens = new GameObject[openIndexes.Count];

        // generate cards starting with the second one
        for (int i = 1; i < originalListLength; i++) {

            // instantiate Open Tokens (DO NOT PRINT INDEX OF CURRENT TOKEN IT DESTORYS EVERYTHING AND I HAVE NO REASON WHY!!!!! (I want my Friday Evening back..))
            shuffleNum = rand.Next(0, (openIndexes.Count));
            openTokens[openIndexes[shuffleNum]] = Instantiate(openToken, new Vector3(xPositionUp, yPositionUp, 0),
                Quaternion.identity) as GameObject;
            openTokens[openIndexes[shuffleNum]].GetComponent<OpenToken>().index = openIndexes[shuffleNum];
            openIndexes.Remove(openIndexes[shuffleNum]);
            xPositionUp = xPositionUp + 3;

            // instantiate flippable Tokens
            shuffleNum = rand.Next(0, (flipIndexes.Count));
            flipTokens[flipIndexes[shuffleNum]] = Instantiate(flipToken, new Vector3(xPositionDown, yPositionDown, 0),
                Quaternion.identity) as GameObject;
            flipTokens[flipIndexes[shuffleNum]].GetComponent<FlippableToken>().index = flipIndexes[shuffleNum];
            flipIndexes.Remove(flipIndexes[shuffleNum]);
            xPositionDown = xPositionDown + 3;

        }
        //last slot will be given to the OG Token
        openTokens[openIndexes[0]] = openToken;
        openTokens[openIndexes[0]].GetComponent<OpenToken>().index = openIndexes[0];
        flipTokens[flipIndexes[0]] = flipToken;
        flipTokens[flipIndexes[0]].GetComponent<FlippableToken>().index = flipIndexes[0];

        //flip Tokens for Player
        foreach (GameObject token in flipTokens) {
            token.GetComponent<FlippableToken>().ShowCard(showTime);
        }

    }
    
    public bool TwoCardsSelected() {
        if(selectedTokens[0] > -1 && selectedTokens[1] > -1) {
            return true;
        }
        return false;
    }

    public bool NoCardsSelected() {
        if(selectedTokens[0] < 0 && selectedTokens[1] < 0) {
            return true;
        }
        return false;
    }

    public bool OneCardSelected() {
        if(!TwoCardsSelected() && !NoCardsSelected()) {
            return true;
        }
        return false;
    }

    public void SelectOpenToken(int index) {
        if (selectedTokens[0] < 0) {
            selectedTokens[0] = index;
        }
    }

    public void SelectFlipToken(int index) {
        if (selectedTokens[1] < 0) {
            selectedTokens[1] = index;
        }
    }

    public void RemoveSelectedOpenToken(int index) {
        if (selectedTokens[0] == index) {
            selectedTokens[0] = -1;
        } 
    }

    public void RemoveSelectedFlipToken(int index) {
        if (selectedTokens[1] == index) {
            selectedTokens[1] = -2;
        }
    }

    public bool CheckMatch() {
        if (selectedTokens[0] == selectedTokens[1]) {
            openTokens[selectedTokens[0]].GetComponent<OpenToken>().matched = true;
            flipTokens[selectedTokens[1]].GetComponent<FlippableToken>().matched = true;
            selectedTokens[0] = -1;
            selectedTokens[1] = -2;
            CheckCleared();
            countDown.GetComponent<CountDown>().NextNumber();
            return true;
        }
        if (TwoCardsSelected()) {
            //flip back selected automatically
            openTokens[selectedTokens[0]].GetComponent<OpenToken>().DramaticFlip(dramaticFlipTime);
            flipTokens[selectedTokens[1]].GetComponent<FlippableToken>().DramaticFlip(dramaticFlipTime);
            countDown.GetComponent<CountDown>().NextNumber();
        }
        return false;
    }

    public bool CheckCleared() {
        for (int i = 0; i < 5; i++) {
            // Check if alle tokens are matched
            if (!flipTokens[i].GetComponent<FlippableToken>().matched) {
                return false;
            }
        }
        ClearedSuccess();
        return true;
    }

    public void ClearedSuccess() {
       print("Congrats!");
       // End Scene
    }

    public void CleardFailure() {
        print("You can't even clear a memory Game? Pathetic!");
        // Ende Scene
    }

    private void Awake() {
        flipToken = GameObject.Find("FlippableToken");
        openToken = GameObject.Find("OpenToken");
        countDown = GameObject.Find("CountDown");
    }

}
