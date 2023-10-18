using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class status : MonoBehaviour
{
    public Text LifeUI;
    public int LifeStatus =100;
    
    public GameObject UiDeath; // Referência ao objeto pai da janela do inventário
    // Start is called before the first frame update
    void Start()
    {
        LifeStatus = 100;
    }

    // Update is called once per frame
    void Update()
    {

        if (LifeStatus < 1)
        {
           // UiDeath.SetActive(true);
            
        }
   
        LifeUI.text = "" + LifeStatus;
        
    }
    public void OnResetGame()
    {   
       SceneManager.LoadScene("teste");
    }
}
