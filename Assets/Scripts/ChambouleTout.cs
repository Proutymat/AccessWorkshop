using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector; // Importer Odin

public class ChambouleTout : MonoBehaviour
{
    // Rotation Settings
    [SerializeField] private float _lookSpeed = 2f;
    [SerializeField] private float _lookXTopLimit = 55f;
    [SerializeField] private float _lookXBotLimit = 55f;
    private float rotationX = 0f;
    private float rotationY = 0f;
    [SerializeField] private Camera _playerCamera;
    
    
    
    [SerializeField] private GameObject throwable;
    [SerializeField] private Transform hand;
    [Tooltip("Adapt the weight of the throwable force")]public int weight; //int est un nombre

    [SerializeField] private GameObject _chambouleTout;
    [SerializeField] private GameObject _config1;
    [SerializeField] private GameObject _config2;
    [SerializeField] private GameObject _config3;
    [SerializeField] private GameObject _config4;
    [SerializeField] private GameObject _config5;
    [SerializeField] private List<Material> _materials;
    
    private float _puissance; //float est nombre decimal 
    private float _pressedTimer = 0;
    private bool _launch = false; //bool is true or false
    
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void DestroyAllChildren(GameObject parent)
    {
        for (int i = parent.transform.childCount - 1; i >= 0; i--)
        {
            GameObject.DestroyImmediate(parent.transform.GetChild(i).gameObject);
        }
    }

    [Button]
    void GenerateChambouleTout(int config)
    {
        DestroyAllChildren(_chambouleTout);
        
        GameObject selectedConfig = (config == 1) ? _config1 : (config == 2) ? _config2 : (config == 3) ? _config3 : (config == 4) ? _config4 : null;
        
        if (selectedConfig == null)
        {
            Debug.LogWarning("Configuration invalide ou non assignée !");
            return;
        }
        
        // Copier chaque enfant de la configuration sélectionnée
        foreach (Transform child in selectedConfig.transform)
        {
            GameObject newChild = Instantiate(child.gameObject, _chambouleTout.transform);
            newChild.transform.localPosition = child.localPosition;
            newChild.transform.localRotation = child.localRotation;
            newChild.transform.localScale = child.localScale;
        }
        
        RandomizeMaterials();
    }

    [Button]
    void RandomizeMaterials()
    {
        if (_chambouleTout == null || _materials == null || _materials.Count == 0)
        {
            Debug.LogWarning("ChambouleTout ou la liste des matériaux est vide !");
            return;
        }

        List<Material> availableMaterials = new List<Material>(_materials); // Copie pour éviter les doublons
        List<Transform> children = new List<Transform>();

        // Récupérer tous les enfants
        foreach (Transform child in _chambouleTout.transform)
        {
            children.Add(child);
        }

        if (children.Count > availableMaterials.Count)
        {
            Debug.LogWarning("Il y a plus d'objets que de matériaux disponibles !");
            return;
        }

        // Mélanger la liste des enfants pour éviter un ordre fixe
        System.Random rng = new System.Random();
        children.Sort((a, b) => rng.Next(-1, 2));

        // Appliquer les matériaux de manière unique
        for (int i = 0; i < children.Count; i++)
        {
            Renderer renderer = children[i].GetComponent<Renderer>();
            if (renderer != null && availableMaterials.Count > 0)
            {
                int index = rng.Next(availableMaterials.Count);
                renderer.material = availableMaterials[index];
                availableMaterials.RemoveAt(index);
            }
        }
    }

    void UpdateCamera()
    {
        // Rotation verticale (X)
        rotationX += -Input.GetAxis("Mouse Y") * _lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -_lookXBotLimit, _lookXTopLimit);

        // Rotation horizontale (Y)
        rotationY += Input.GetAxis("Mouse X") * _lookSpeed;
        rotationY = Mathf.Clamp(rotationY, -_lookXBotLimit, _lookXTopLimit);

        // Appliquer la rotation sur la caméra et le joueur
        _playerCamera.transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
        transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }

    void ThrowBall()
    {
        //incrémenter une puissance quand j'appuie sur le boutton de la souris
        if (Input.GetMouseButton(0))
        {
            _pressedTimer = _pressedTimer + Time.deltaTime;
            
        }
        
        //quand je relache, lancer le cailloux
        if(Input.GetMouseButtonUp(0)) // I release the mouse button
        {

            _puissance = _pressedTimer * weight;
            _pressedTimer = 0;
            _launch = true;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        UpdateCamera();
        ThrowBall();

        if (_chambouleTout.transform.childCount == 0)
        {
            int config = Random.Range(1, 5);
            GenerateChambouleTout(config);
            Debug.Log("CONFIG = " + config);
            
        }

    }
    
    //better to use this when you use Physics
    void FixedUpdate()
    {
        if(_launch)
        {
            GameObject goToThrow = Instantiate(throwable, hand.position,
                hand.rotation);//instantiate the rock

            Debug.Log("PUISSANCE = " +  _puissance);
            Rigidbody rbGoToThrow = goToThrow.GetComponent<Rigidbody>(); //get the rigidbody
            rbGoToThrow.AddForce(hand.forward * _puissance);

            _launch = false;
            _puissance = 0;
        }
    }   
}
