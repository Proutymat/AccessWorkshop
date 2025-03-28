using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] playlist;
    private int currentTrackIndex = 0;

    void Start()
    {
         playlist = audioSource.GetComponent<enceinteMenu>().sons;
       
        if (playlist.Length > 0)
        {
            PlayTrack(currentTrackIndex);
            StartCoroutine(CheckMusicEnd());
        }
    }

    void PlayTrack(int index)
    {
        if (index < playlist.Length)
        {
            audioSource.clip = playlist[index];
            audioSource.Play();
        }
    }

    IEnumerator CheckMusicEnd()
    {
        while (true)
        {
            if (!audioSource.isPlaying && audioSource.clip != null)
            {
                yield return new WaitForSeconds(0.5f); // Petite pause pour éviter les erreurs
                NextTrack();
            }
            yield return null;
        }
    }

    void NextTrack()
    {
        currentTrackIndex = (currentTrackIndex + 1) % playlist.Length; // Revenir au début si on atteint la fin
        PlayTrack(currentTrackIndex);
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
