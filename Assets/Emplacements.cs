using UnityEngine;

public class Emplacements : MonoBehaviour
{

    private bool occupied;
    //public int numPiece;

    private void Awake()
    {
        occupied = false;
        //numPiece = -1;
    }
    public void Occuper()
    {
        occupied = true;
    }

    public void Desoccuper()
    {
        occupied = false;
    }

    public bool IsOccupied()
    {
        return occupied;
    }
    
}
