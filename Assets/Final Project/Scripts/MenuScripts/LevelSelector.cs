using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main Menu");
    }
   public void LoadLevel1_1()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level_Tutorial");
    }

    public void LoadLevel2_1()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level_try");
    }

    public void LoadLevel2_2()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("VolcanoParkour");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
