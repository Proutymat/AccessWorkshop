using UnityEngine;

public class Safety : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        if (!transform.GetChild(0).gameObject.activeSelf)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!transform.GetChild(0).gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
}
