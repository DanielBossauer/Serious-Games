using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static bool SaveGame(int currentScene) {
        
        string path = GetPath();
        BinaryFormatter formatter = GetBinaryFormatter();               //binaryencoder
        FileStream file = new FileStream(path, FileMode.Create);        
        SaveData saveData = new SaveData(currentScene, StaticVariables.GetNotebookDict());
        formatter.Serialize(file, saveData);
        file.Close();
        return true;
    }

    public static SaveData LoadGame() {

        string path = GetPath();

        if (!File.Exists(path)) {
            return null;
        }
        BinaryFormatter formatter = GetBinaryFormatter();
        FileStream file = File.Open(path, FileMode.Open);

        try {
            SaveData save = formatter.Deserialize(file) as SaveData;
            file.Close();
            return save;
        } catch {
            Debug.LogErrorFormat("Failed to load a file at {0}", path);
            file.Close();
            return null;
        }
    }

    public static BinaryFormatter GetBinaryFormatter() {
        return new BinaryFormatter();
    }

    public static string GetPath() {
        string directoryPath = Application.persistentDataPath;
        string fileName = "/sgsave";
        string format = ".sus";
        return Path.GetFullPath(directoryPath + fileName + format);
    }
}
