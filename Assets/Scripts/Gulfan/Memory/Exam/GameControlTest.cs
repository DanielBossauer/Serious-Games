using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;

public class GameControlTest : MonoBehaviour
{
    GameObject flipToken;
    GameObject openToken;
    GameObject[] flipTokens;
    GameObject[] openTokens;

    GameObject countDown;
    GameObject background;

    // Both Lists must be as long as size of Token Array
    List<int> openIndexes = new List<int> {0,1,2,3,4,5,6,7,8,9};
    List<int> flipIndexes = new List<int> {0,1,2,3,4,5,6,7,8,9};
    public static System.Random rand = new System.Random();
    public int shuffleNum = 0;
    // first postion is OpenToken, second is FlipToken negative Value means unselected
    int[] selectedTokens = {-1, -2};

    public bool gameFinished = false;
    public bool gameSuccess = false;

    // Parameters to be changed for each Instance of the Game
    public float dramaticFlipTime;
    public float showTime;
    public float tokenDistance;
    public float tokenDistanceVertical;
    public Sprite[] backgrounds;

    void Start() {

        int originalListLength = openIndexes.Count;
        float ogXPostionOpen = openToken.GetComponent<OpenTokenTest>().transform.position[0];
        float ogXPostionFlip = flipToken.GetComponent<FlippableTokenTest>().transform.position[0];

        float xPositionOpen = ogXPostionOpen + tokenDistance;
        float yPositionOpen = openToken.GetComponent<OpenTokenTest>().transform.position[1];
        float xPositionFlip = ogXPostionFlip + tokenDistance;
        float yPositionFlip = flipToken.GetComponent<FlippableTokenTest>().transform.position[1];
        flipTokens = new GameObject[openIndexes.Count];
        openTokens = new GameObject[openIndexes.Count];

        // generate cards starting with the second one
        for (int i = 1; i < originalListLength; i++) {

            // instantiate Open Tokens (DO NOT PRINT INDEX OF CURRENT TOKEN IT DESTORYS EVERYTHING AND I HAVE NO REASON WHY!!!!! (I want my Friday Evening back..))
            // make colomns with 2 tokens each

            //go left and down
            if (i % 2 == 0) {
                yPositionOpen = yPositionOpen - tokenDistanceVertical;
                xPositionOpen = ogXPostionOpen;
                yPositionFlip = yPositionFlip - tokenDistanceVertical;
                xPositionFlip = ogXPostionFlip;
            }
            shuffleNum = rand.Next(0, (openIndexes.Count));
            openTokens[openIndexes[shuffleNum]] = Instantiate(openToken, new Vector3(xPositionOpen, yPositionOpen, 0),
                Quaternion.identity) as GameObject;
            openTokens[openIndexes[shuffleNum]].GetComponent<OpenTokenTest>().index = openIndexes[shuffleNum];
            openIndexes.Remove(openIndexes[shuffleNum]);
            xPositionOpen = xPositionOpen + tokenDistance;

            // instantiate flippable Tokens
            shuffleNum = rand.Next(0, (flipIndexes.Count));
            flipTokens[flipIndexes[shuffleNum]] = Instantiate(flipToken, new Vector3(xPositionFlip, yPositionFlip, 0),
                Quaternion.identity) as GameObject;
            flipTokens[flipIndexes[shuffleNum]].GetComponent<FlippableTokenTest>().index = flipIndexes[shuffleNum];
            flipIndexes.Remove(flipIndexes[shuffleNum]);
            xPositionFlip = xPositionFlip + tokenDistance;

        }
        //last slot will be given to the OG Token
        openTokens[openIndexes[0]] = openToken;
        openTokens[openIndexes[0]].GetComponent<OpenTokenTest>().index = openIndexes[0];
        openToken.GetComponent<OpenTokenTest>().UpdateBack();
        flipTokens[flipIndexes[0]] = flipToken;
        flipTokens[flipIndexes[0]].GetComponent<FlippableTokenTest>().index = flipIndexes[0];

        // Start Text
         DialogueManager.StartConversation("Szene_7_Start");

        //flip Tokens for Player
        foreach (GameObject token in flipTokens) {
            token.GetComponent<FlippableTokenTest>().ShowCard(showTime);
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
            openTokens[selectedTokens[0]].GetComponent<OpenTokenTest>().matched = true;
            flipTokens[selectedTokens[1]].GetComponent<FlippableTokenTest>().matched = true;
            selectedTokens[0] = -1;
            selectedTokens[1] = -2;
            CheckCleared();
            countDown.GetComponent<CountDownTest>().NextNumber();
            return true;
        }
        if (TwoCardsSelected()) {
            //flip back selected automatically && kill flipped Token
            openTokens[selectedTokens[0]].GetComponent<OpenTokenTest>().DramaticFlip(dramaticFlipTime);
            int destroyFlipIndex = selectedTokens[1];
            flipTokens[destroyFlipIndex].GetComponent<FlippableTokenTest>().FlipCardBack(); 
            flipTokens[destroyFlipIndex].GetComponent<FlippableTokenTest>().killToken(); 
            countDown.GetComponent<CountDownTest>().NextNumber();
        }
        return false;
    }

    public bool CheckCleared() {
        for (int i = 0; i < openTokens.Length; i++) {
            // Check if alle tokens are matched
            if (!openTokens[i].GetComponent<OpenTokenTest>().matched) {
                return false;
            }
        }
        ClearedSuccess();
        return true;
    }

    public void ClearedSuccess() {
       gameFinished = true;
       gameSuccess = true;
       NextScene();
       // End Scene in controller for Instantiation
    }

    public void CleardFailure() {
        gameFinished = true;
        gameSuccess = false;
        NextScene();
       // End Scene in controller for Instantiation
    }

    private void NextScene() {
        int sceneIndex = GetCurrentSceneIndex();
        // Test for existing dialogue manager
        if (DialogueManager.instance != null)
        {
            DialogueManager.StopAllConversations();
            Destroy(DialogueManager.instance.gameObject);
        }
        SceneManager.LoadScene(sceneIndex + 1);
    }
    private int GetCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void KillAllTokens() {
         for (int i = 0; i < openTokens.Length; i++) {
            flipTokens[i].GetComponent<FlippableTokenTest>().killToken();
            openTokens[i].GetComponent<OpenTokenTest>().killToken();
         }
    }

    public void UpdateBackground(int index) {
        background.GetComponent<SpriteRenderer>().sprite = backgrounds[index];
    }

    private void Awake() {
        flipToken = GameObject.Find("FlippableToken");
        openToken = GameObject.Find("OpenToken");
        countDown = GameObject.Find("CountDown");
        background = GameObject.Find("Background").gameObject;
    }

}
