using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
public class manage : MonoBehaviour
{
    private float min;
    private float max;
    
    public PlayerController player;
    public TMP_Text score;
    public TMP_Text vie;
    public TMP_Text gameOver;
    
    public Transform[] spawnpoints;
    public GameObject ennemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        min = 1;
        max = 3;
        gameOver.gameObject.SetActive(false);
        StartCoroutine(SpawnEnnemies());
    }
/*
    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + player.score;
        vie.text = "Vies: " + player.vie;

        if (player.vie == 0)
        {
            StartCoroutine(GameOver());
        }
    }
    */
    
    private void Spawn()
    {
        int  x = Random.Range(0, spawnpoints.Length);
        Instantiate(ennemy, spawnpoints[x].position, ennemy.transform.rotation);
    }

    private IEnumerator SpawnEnnemies()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(Random.Range(min, max));
        }
    }

    private IEnumerator GameOver()
    {
        gameOver.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
