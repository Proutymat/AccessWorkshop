using System;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _timerText;

    private int _score;
    private int _currentGame;

    private bool _godModeOn;
    
    private float _timer;

    [Button]
    public void ToggleGodMode()
    {
        _godModeOn = !_godModeOn;
    }

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _score = 0;
        _timer = 120;
        _currentGame = 0;
        _godModeOn = false;
    }


    public void AddScore(int score)
    {
        if (_godModeOn && _score < 0) return;
        _score += score;
    }

    [Button]
    public void NextGame()
    {
        _currentGame++;
        _timer = 120;
     
        Debug.Log("Current Game = " + _currentGame);
        if (_currentGame == 1)
            SceneManager.LoadScene("Shmup");
        else if (_currentGame == 2)
            SceneManager.LoadScene("Puzzle");
    }

    private void Update()
    {
        if (_score < 0)
            _score = 0;
        
        _scoreText.text = _score.ToString();
        
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            NextGame();
        }
        
        // Calcul du temps en minutes et secondes
        int minutes = Mathf.FloorToInt(_timer / 60);
        int seconds = Mathf.FloorToInt(_timer % 60);

        // Affichage du timer formaté
        _timerText.text = $"{minutes:00}:{seconds:00}";
        
    }
}
