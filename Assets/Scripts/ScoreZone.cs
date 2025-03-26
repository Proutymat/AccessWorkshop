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
            Destroy(other.gameObject);
        }
        else if (other.tag == "Ball")
        {
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        _scoreText.text = _score.ToString();
    }
}
