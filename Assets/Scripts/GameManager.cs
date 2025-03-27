using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int _score;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _score = 0;
    }


    public void AddScore(int score)
    {
        _score += score;
    }

    public void NextGame()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
