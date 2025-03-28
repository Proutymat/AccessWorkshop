using UnityEngine;
using System.Collections;

public class Subtitle : MonoBehaviour
{

    public float tempsSousTitre;
    public AudioClip son;
    private GameObject papa;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        Debug.Log(transform.position);
    }

    void Awake()
    {
        StartCoroutine(Soustitre());
    }

    IEnumerator Soustitre()
    {
        yield return new WaitForSeconds(tempsSousTitre);
        papa = transform.parent.gameObject;
        papa.SetActive(false);
        gameObject.SetActive(false);
    }
}
