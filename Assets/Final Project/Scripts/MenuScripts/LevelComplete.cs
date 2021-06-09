using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{

    public void QuitGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level Selection");
    }
}
