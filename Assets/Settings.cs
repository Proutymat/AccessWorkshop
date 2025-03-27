using UnityEngine;

public class Settings : MonoBehaviour
{
    
    public static KeyCode moveLeft = KeyCode.Q;
    public static KeyCode moveRight = KeyCode.D;
    public static KeyCode moveUp = KeyCode.Z;
    public static KeyCode moveDown = KeyCode.S;
    public static KeyCode shoot = KeyCode.Space;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public static void SetKey(string keyName, KeyCode newKey)
    {
        Debug.Log("jsuis dans les options j'ai recu la lettre " + newKey);
        if (keyName == "MoveLeft") moveLeft = newKey;
        if (keyName == "MoveRight") moveRight = newKey;
        if (keyName == "MoveUp") moveUp = newKey;
        if (keyName == "MoveDown") moveDown = newKey;
        if (keyName == "Shoot") shoot = newKey;
        
    }
}
