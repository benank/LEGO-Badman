using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
   public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main Menu");
    }
   
   public void LoadLevel1() 
   {
       SceneManager.LoadScene("Level_Tutorial");
   }
}
