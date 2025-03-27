using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    public float speed;
    private Rigidbody rb;
    public PlayerController player;
    
    [SerializeField] GameManager gameManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GAMEMANAGER").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.x > 40)
        {
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Enter");
        if (other.gameObject.CompareTag("Ennemy"))
        {
            Debug.Log("touché");
            player.score += 1;
            gameManager.AddScore(1);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}



//10 8 6 4 2   5 3 1 -1 -3              6 3.8 1.6 -0.6 -2.8             6 3.6 1.2 -1.2 3.6   