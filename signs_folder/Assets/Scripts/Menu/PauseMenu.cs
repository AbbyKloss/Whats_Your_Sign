using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    public bool pubPaused;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update() {
        pubPaused = isPaused;
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        pubPaused = isPaused;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        pubPaused = isPaused;
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        isPaused = false;
        pubPaused = isPaused;
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame() {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void Retry() {
        Time.timeScale = 1f;
        isPaused = false;
        pubPaused = isPaused;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
