using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject projectile;
    
    public Transform projectileSpawn;
    
    public int vie;
    public int score;
    
    [SerializeField] GameManager gameManager;
    [SerializeField] List<Material> _materials;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        vie = 3;
        score = 0;
        
        gameManager = GameObject.Find("GAMEMANAGER").GetComponent<GameManager>();
    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetKey(Settings.moveLeft))
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
        }

        if (Input.GetKey(Settings.moveRight))
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }

        if (Input.GetKey(Settings.moveUp))
        {
            transform.position += Vector3.up * Time.deltaTime * speed;
        }

        if (Input.GetKey(Settings.moveDown))
        {
            transform.position += Vector3.down * Time.deltaTime * speed;
        }
        
        
        if (transform.position.y > 6.3f)
        {
            transform.position = new Vector3(transform.position.x, 6.3f, transform.position.z);
        }

        if (transform.position.y < -4.3f)
        {
            transform.position = new Vector3(transform.position.x, -4.3f, transform.position.z);
        }

        if (transform.position.x > 9.2f)
        {
            transform.position = new Vector3(9.2f, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -9.2f)
        {
            transform.position = new Vector3(-9.2f, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(Settings.shoot))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject projectileInstance = Instantiate(projectile, projectileSpawn.position, projectile.transform.rotation);
        
        Projectile  projectileScript = projectileInstance.GetComponent<Projectile>();
        projectileScript.player = this;
        
        Material randomMaterial = _materials[Random.Range(0, _materials.Count)];
        Renderer renderer = projectileInstance.GetComponent<Renderer>();
        renderer.material = randomMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ennemy"))
        {
            Destroy(other.gameObject);
            vie -= 1;
            score += 1;
            gameManager.AddScore(1);
        }
        else
        {
            if (other.gameObject.CompareTag("EnnemyBullet"))
            {
                Destroy(other.gameObject);
                vie -= 1;
                gameManager.AddScore(-1);
            }
        }
    }
    
}
