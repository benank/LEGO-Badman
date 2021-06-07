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
<<<<<<< Updated upstream:Assets/Final Project/Scripts/MenuScripts/LevelSelector.cs
   
   public void LoadLevel1() 
   {
       SceneManager.LoadScene("Level_Tutorial");
   }
=======
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
>>>>>>> Stashed changes:Assets/Final Project/Scripts/LevelSelector.cs
}
