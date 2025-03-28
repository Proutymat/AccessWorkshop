using UnityEngine;
using System;
using System.Linq;
using System.Collections;


public class enceinteMenu : MonoBehaviour
{
    public AudioClip[] sons = new AudioClip[16];
    private AudioSource audioSource;
    private int currentTrackIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        sons = sons.OrderBy(x => Guid.NewGuid()).ToArray();
          
        if (sons.Length > 0)
        {
            PlayTrack(currentTrackIndex);
            StartCoroutine(CheckMusicEnd());
        }
          
          
    }
    
    void PlayTrack(int index)
    {
        if (index < sons.Length)
        {
            audioSource.clip = sons[index];
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
        currentTrackIndex = (currentTrackIndex + 1) % sons.Length; // Revenir au début si on atteint la fin
        PlayTrack(currentTrackIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}