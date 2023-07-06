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
        // update sceneIndex automatically
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
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
        // add save function
        print("not implemented yet");
    }

    public void LoadGame() {
        // add load function
        print("not implemented yet");
    }

    public void SkipScene() {
        SceneManager.LoadScene(sceneIndex + 1);
        ResumeGame();
    }

    public void ShowInfoTexts() {
        // ass infotexts
        print("not implemented yet");
    }

    public void QuitGame() {
        Application.Quit();
    }

}
