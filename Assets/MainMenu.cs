using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
public class MainMenu : MonoBehaviour
{
   public GameObject ouille;
   private AudioSource audio;
   private AudioClip song;
   public GameObject sous;

   void Start()
   {
      sous.SetActive(true);
      song = sous.transform.GetChild(0).GetComponent<Subtitle>().son;
      audio = GetComponent<AudioSource>();
      audio.clip = song;
      audio.Play();
   }

   public void StartGame()
   {
      SceneManager.LoadScene(1);
   }

   public void QuitGame()
   {
      Application.Quit();
   }

   
}
