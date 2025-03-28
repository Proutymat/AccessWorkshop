using UnityEngine;
using System;
using System.Linq;


public class enceinteMenu : MonoBehaviour
{
    public AudioClip[] sons = new AudioClip[16]; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
          sons = sons.OrderBy(x => Guid.NewGuid()).ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
