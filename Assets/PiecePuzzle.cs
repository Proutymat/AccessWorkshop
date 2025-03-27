using UnityEngine;

public class PiecePuzzle : MonoBehaviour
{

    public int numEmplacement;

    public int placeFinale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        numEmplacement = -1;
        transform.position = new Vector3(50, 50, 50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
