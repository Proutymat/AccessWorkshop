using UnityEngine;
using System.Collections;
public class managerPuzzle : MonoBehaviour
{
    
    public GameObject[] puzzlePieces = new GameObject[8];
    public Emplacements[] emplacements = new Emplacements[9];
    
    [SerializeField] GameManager gameManager;
    
    int emplacementAChanger;
    private GameObject pieceABouger;

    private bool enMouvement;
    private float speed = 2f;
    private float timer;
    private AudioSource enceinte;
    public AudioClip[] sons;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enceinte = GetComponent<AudioSource>();
        StartCoroutine(Melanger());
        enMouvement = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           teest();
        }
        if (Input.GetMouseButtonDown(0) && !enMouvement)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
               Vector3 distance = hit.transform.position - emplacements[GetGap()].transform.position;

               if (distance.magnitude >= 3.29f && distance.magnitude <= 3.32f)
               {
                   
                   for (int i = 0; i < 8; i++)
                   {
                       if (emplacements[i].transform.position == hit.transform.position)
                       {
                           emplacementAChanger = i;
                       }
                   }
                   int rand = Random.Range(0,19);
                   enceinte.clip = sons[rand];
                   enceinte.Play();
                   enMouvement = true;
                   timer += Time.deltaTime;
               }
            }
        }

        if (enMouvement)
        {
            if (pieceABouger == null)
            {
                foreach (GameObject piece in puzzlePieces)
                {
                    if (emplacements[emplacementAChanger].transform.position == piece.transform.position)
                    {
                        pieceABouger = piece;
                        break;
                    }
                }
            }
            else if (pieceABouger.transform.position == emplacements[GetGap()].transform.position)
            {
                enMouvement = false;
                timer = 0;
                pieceABouger = null;
                emplacements[GetGap()].Occuper();
                emplacements[emplacementAChanger].Desoccuper();
                if (CheckVictory())
                {
                    Debug.Log("Victory");
                    gameManager.AddScore(200);
                }
            }
            else
            {
                pieceABouger.transform.position = Vector3.MoveTowards(pieceABouger.transform.position, emplacements[GetGap()].transform.position, speed * Time.deltaTime );
            }

            
            if(timer != 0)
            {
                if(timer > 3f)
                {
                    timer = 0;
                    enMouvement = false;
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }
            
            
        }
    }
    
    private IEnumerator Melanger()
    {
        int i = 0;
        while (i < 8)
        {
                int rand = Random.Range(0, 8);
                while (emplacements[rand].IsOccupied())
                {
                    rand = Random.Range(0, 8);
                }
                puzzlePieces[i].transform.position = emplacements[rand].transform.position;
                emplacements[rand].Occuper();
                //teest();
                yield return new WaitForSeconds(0.2f);
                i++;
        }
        yield return null;
    }

    private bool CheckVictory()
    {
        bool victory = true;

        foreach (GameObject piece in puzzlePieces)
        {
            if (emplacements[piece.GetComponent<PiecePuzzle>().placeFinale].transform.position !=
                piece.transform.position)
            {
                victory = false;
            }
        }
        
        return victory;
    }

    public int GetGap()
    {
        int x = -1;
        for (int i = 0; i < 9; i++)
        {
            if (!emplacements[i].IsOccupied())
            {
                x = i;
            }
        }
        Debug.Log(x);
        return x;
    }

    private void teest()
    {
        foreach (Emplacements empl in emplacements)
        {
            Debug.Log(empl.IsOccupied());
        }
    }
}
