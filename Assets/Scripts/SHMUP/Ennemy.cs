using UnityEngine;
using System.Collections;
public class Ennemy : MonoBehaviour
{
    public GameObject ennemyBullet;
    public Transform spawnpoint;

    private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 3f;
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            float min = 1f;
            float max = 3f;
        
            yield return new WaitForSeconds(Random.Range(min, max));

            Instantiate(ennemyBullet, spawnpoint.position, ennemyBullet.transform.rotation);
        }
    }
}
