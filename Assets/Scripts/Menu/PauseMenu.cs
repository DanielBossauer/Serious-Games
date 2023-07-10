using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool paused;
    // index of the current Scene
    public int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        sceneIndex = GetCurrentSceneIndex();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if(paused) {
                ResumeGame();
            } else {
                PauseGame();
            }
        }
    }

    public void PauseGame() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void ResumeGame() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void SaveGame() {
        sceneIndex = GetCurrentSceneIndex();
        SaveSystem.SaveGame(sceneIndex);
    }

    public void LoadGame() {
        SaveData save = SaveSystem.LoadGame();
        SceneManager.LoadScene(save.sceneIndex);
        ResumeGame();
    }

    public void SkipScene() {
        sceneIndex = GetCurrentSceneIndex();
        SceneManager.LoadScene(sceneIndex + 1);
        ResumeGame();
    }

    public void ShowInfoTexts() {
        // add infotexts
        print("not implemented yet");
    }

    public void QuitGame() {
        Application.Quit();
    }

    private int GetCurrentSceneIndex() {
        return SceneManager.GetActiveScene().buildIndex;
    }

}
