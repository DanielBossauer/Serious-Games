using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    GameObject token;
    List<int> faceIndexes = new List<int> {0,1,2,3,4,0,1,2,3,4};
    public static System.Random rand = new System.Random();
    public int shuffleNum = 0;
    int[] visibleFaces = {-1, -2};

    void Start() {

        int originalLength = faceIndexes.Count;
        float yPosition = 2.3f;
        float xPosition = -2.2f;
        // generate cards starting with the second one
        for (int i = 1; i < 10; i++) {
            shuffleNum = rand.Next(0, (faceIndexes.Count));
            var temp = Instantiate(token, new Vector3(xPosition, yPosition, 0),
                Quaternion.identity);
            temp.GetComponent<MainToken>().faceIndex = faceIndexes[shuffleNum];
            faceIndexes.Remove(faceIndexes[shuffleNum]);
            xPosition = xPosition + 3;
            // new row
            if (i == (originalLength/2 - 1)) {
                yPosition = -2.3f;
                xPosition = -5.2f;
            }
        }
        token.GetComponent<MainToken>().faceIndex = faceIndexes[0];
    }
    public bool TwoCardsUp() {
        if(visibleFaces[0] > -1 && visibleFaces[1] > -1) {
            return true;
        }
        return false;
    }

    public void AddVisibleFace(int index) {
        if (visibleFaces[0] == -1) {
            visibleFaces[0] = index;
        } else if (visibleFaces[1] == -2) {
            visibleFaces[1] = index;
        }

    }

    public void RemoveVisibleFace(int index) {
        if (visibleFaces[0] == index) {
            visibleFaces[0] = -1;
        } else if (visibleFaces[1] == index) {
            visibleFaces[1] = -2;
        }
    }

    public bool CheckMatch() {
        if (visibleFaces[0] == visibleFaces[1]) {
            visibleFaces[0] = -1;
            visibleFaces[1] = -2;
            return true;
        }
        return false;
    }

    private void Awake() {
        token = GameObject.Find("Token");
    }
}
