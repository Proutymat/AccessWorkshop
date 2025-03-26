using UnityEngine;

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
    
    private float _puissance; //float est nombre decimal 
    private float _pressedTimer = 0;
    private bool _launch = false; //bool is true or false
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    

    // Update is called once per frame
    void Update()
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
