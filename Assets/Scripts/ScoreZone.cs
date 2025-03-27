using TMPro;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{

    private int _score;
    [SerializeField] private GameManager _gameManager;
    
    private float _timer;

    void Start()
    {
        _score = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ChambouleCube")
        {
            _score++;
            _gameManager.AddScore(1);
            Destroy(other.gameObject);
        }
        else if (other.tag == "Ball")
        {
            Destroy(other.gameObject);
        }
    }
}
