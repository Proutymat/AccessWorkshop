using TMPro;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{

    private int _score;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _timerText;
    
    private float _timer;

    void Start()
    {
        _score = 0;
        _timer = 120;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ChambouleCube")
        {
            _score++;
            Destroy(other.gameObject);
        }
        else if (other.tag == "Ball")
        {
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        _timer -= Time.deltaTime;
        _scoreText.text = _score.ToString();
       
        // Calcul du temps en minutes et secondes
        int minutes = Mathf.FloorToInt(_timer / 60);
        int seconds = Mathf.FloorToInt(_timer % 60);

        // Affichage du timer formaté
        _timerText.text = $"{minutes:00}:{seconds:00}";
    }
}
