using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;

public class StartMenu : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject background;
    public bool paused;
    // index of the current Scene
    public int sceneIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        pauseScreen.SetActive(true);
        background = GameObject.Find("GamePoster").gameObject;
        background.gameObject.SetActive(false);
        sceneIndex = GetCurrentSceneIndex();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseGame() {
        DialogueTime.Mode = DialogueTime.TimeMode.Gameplay;
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void ResumeGame() {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void SaveGame() {
        sceneIndex = GetCurrentSceneIndex();
        SaveSystem.SaveGame(sceneIndex);
    }

    public void LoadGame() {
        background.gameObject.SetActive(true);
        SaveData save = SaveSystem.LoadGame();

        StaticVariables.notebookDict = save.notebookDict;

        SceneManager.LoadScene(save.sceneIndex);
        ResumeGame();
    }

    public void SkipScene() {
        background.gameObject.SetActive(true);
        
        sceneIndex = GetCurrentSceneIndex();
        
        if (DialogueManager.instance != null)
        {
            DialogueManager.StopAllConversations();
            Destroy(DialogueManager.instance.gameObject);
        }

        SceneManager.LoadScene(sceneIndex + 1);
        ResumeGame();
    }

    public void ShowInfoTexts() {
        // add infotexts
        print("not implemented yet");
    }

    public void QuitGame() {
        background.gameObject.SetActive(true);
        Application.Quit();
    }

    private int GetCurrentSceneIndex() {
        return SceneManager.GetActiveScene().buildIndex;
    }

}
