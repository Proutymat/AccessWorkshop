using UnityEngine;

public class ProjectileEnnemy : MonoBehaviour
{
    
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
}



