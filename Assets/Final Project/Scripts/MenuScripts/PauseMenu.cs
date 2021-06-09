using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        // Game is paused on escape key (for now)
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (GameisPaused)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }

        //if (!GameisPaused && Cursor.visible)
        //{
        //    ToggleMouseVisible(false);
        //}
    }

    private void Awake()
    {
        ToggleMouseVisible(false);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        ToggleMouseVisible(false); // Do this in update so it works
        Time.timeScale = 1.0f;
        GameisPaused = false; 
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        ToggleMouseVisible(true);
        Time.timeScale = 0.0f;
        GameisPaused = true; 
    }

    void ToggleMouseVisible(bool isVisible)
    {
        Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isVisible;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        ToggleMouseVisible(true);
        SceneManager.LoadScene("Main Menu");
    }
}
