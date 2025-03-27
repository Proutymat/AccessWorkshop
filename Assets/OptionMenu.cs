using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class OptionMenu :  MonoBehaviour
{
    public TMP_Text gauche;
    public TMP_Text droite;
    public TMP_Text haut;
    public TMP_Text bas;
    public TMP_Text shoot;

    private string waitingForKey = "";
    
    private void Start()
    {
        UpdateText();
    }
    
    private void UpdateText()
    {
        gauche.text = Settings.moveLeft.ToString();
        droite.text = Settings.moveRight.ToString();
        haut.text = Settings.moveUp.ToString();
        bas.text = Settings.moveDown.ToString();
        shoot.text = Settings.shoot.ToString();
        Debug.Log("j'update les touches");
        Debug.Log("gauche " + Settings.moveLeft);
        
    }
    
    public void BindGauche()
    {
        StartCoroutine(WaitForKeyPress("MoveLeft"));
    }
   
    public void BindDroite()
    {
        StartCoroutine(WaitForKeyPress("MoveRight"));
    }
   
    public void BindHaut()
    {
        StartCoroutine(WaitForKeyPress("MoveUp"));
    }
   
    public void BindBas()
    {
        StartCoroutine(WaitForKeyPress("MoveDown"));
    }
   
    public void BindShoot()
    {
        StartCoroutine(WaitForKeyPress("Shoot"));
    }
   
   
   
    IEnumerator WaitForKeyPress(string keyName)
    {
        Debug.Log("jsuis dans coroutine");
        waitingForKey = keyName;
        while (!Input.anyKeyDown)
        {
            yield return null;
        }

        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                Settings.SetKey(keyName, key);
                UpdateText();
                break;
            }
        }

        waitingForKey = "";
    }

}
