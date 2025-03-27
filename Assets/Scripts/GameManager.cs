using System;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _timerText;

    private bool _isWindowed;

    private int _score;
    private int _currentGame;

    private bool _godModeOn;
    
    private float _timer;
    
    public Toggle windowedToggle; // Associe un Toggle de l'UI

    [Button]
    public void ToggleGodMode()
    {
        _godModeOn = !_godModeOn;
    }

    void SetWindowedMode(bool isWindowed)
    {
        if (isWindowed)
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
            Screen.SetResolution(1920, 1080, false); // Met une résolution adaptée
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        }
    }
    
    void Start()
    {
        /*
        _isWindowed = false;
        windowedToggle.isOn = _isWindowed;
        SetWindowedMode(_isWindowed);
        windowedToggle.onValueChanged.AddListener(SetWindowedMode);*/
        
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
        else if (_currentGame == 3)
        {
            Debug.Log("Game Over");
            _currentGame = 0;
            SceneManager.LoadScene("MainMenu");
            
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            _isWindowed = !_isWindowed;
            SetWindowedMode(_isWindowed);
        }
        
        
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
