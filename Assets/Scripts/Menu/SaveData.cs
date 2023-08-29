using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int sceneIndex;

    public Dictionary<string,string> notebookDict = new Dictionary<string, string>();

    public SaveData (int currentScene, Dictionary<string, string> notebookDict) {
        sceneIndex = currentScene;
        this.notebookDict = notebookDict;
    }
    
}
