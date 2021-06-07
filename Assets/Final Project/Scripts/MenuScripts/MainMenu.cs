using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
<<<<<<< Updated upstream:Assets/Final Project/Scripts/MenuScripts/MainMenu.cs
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("LevelSelection");
=======
        SceneManager.LoadScene("LevelSelection");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
>>>>>>> Stashed changes:Assets/Final Project/Scripts/MainMenu.cs
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
