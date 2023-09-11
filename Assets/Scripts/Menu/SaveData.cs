using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int sceneIndex;

    public SaveData (int currentScene) {
        sceneIndex = currentScene;
    }
    
}
