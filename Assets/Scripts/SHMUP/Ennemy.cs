using UnityEngine;
using System.Collections;
public class Ennemy : MonoBehaviour
{
    public GameObject ennemyBullet;
    public Transform spawnpoint;

    private float speed;

    private GameObject subtitle;
    private AudioSource enceinte;
    public Subtitle[] allObjects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

        allObjects = GameObject.FindObjectsOfType<Subtitle>(true);
        enceinte = GetComponent<AudioSource>();

        int rand = Random.Range(1,5);
        if(rand == 1 && !checkSon())
        {
            rand = Random.Range(0,11);
            allObjects[rand].transform.parent.gameObject.SetActive(true); 
            enceinte.clip = allObjects[rand].son;
            enceinte.Play();
        }
        
        speed = 3f;
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            float min = 2f;
            float max = 4f;
        
            yield return new WaitForSeconds(Random.Range(min, max));

            Instantiate(ennemyBullet, spawnpoint.position, ennemyBullet.transform.rotation);
        }
    }

    private bool checkSon()
    {
        bool test = false;
        foreach(Subtitle sub in allObjects)
        {
            if(sub.transform.parent.gameObject.activeSelf)
            {
                test = true;
                break;
            }
        }
        return test;
    }
}
