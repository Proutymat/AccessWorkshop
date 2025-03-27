using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
public class MainMenu : MonoBehaviour
{
   
   

   public void StartGame()
   {
      SceneManager.LoadScene(1);
   }

   public void QuitGame()
   {
      Application.Quit();
   }

   
}
