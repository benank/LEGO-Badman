using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main Menu");
    }
   public void LoadLevelTutorial_1()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level_Tutorial");
    }

    public void LoadLevelTutorial_2()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Blueprint Test Scene");
    }

    public void LoadLevelTutorial_3()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("VolcanoParkour");
    }

    public void LoadLevelIce()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level_try");
    }

    public void LoadLevelVolcano()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("VolcanoParkour");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

