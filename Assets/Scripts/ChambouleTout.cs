using UnityEngine;

public class ChambouleTout : MonoBehaviour
{
    
    [SerializeField] private GameObject throwable;
    [SerializeField] private Transform hand;
    [Tooltip("Adapt the weight of the throwable force")]public int weight; //int est un nombre
    
    private float _puissance; //float est nombre decimal 
    private float _pressedTimer = 0;
    private bool _launch = false; //bool is true or false
    

    // Update is called once per frame
    void Update()
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
