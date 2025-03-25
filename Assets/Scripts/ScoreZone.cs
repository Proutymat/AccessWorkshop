using TMPro;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{

    private int _score;
    [SerializeField] private TextMeshProUGUI _scoreText;

    void Start()
    {
        _score = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ChambouleCube")
        {
            _score++;
        }
    }

    void Update()
    {
        _scoreText.text = _score.ToString();
    }
}
