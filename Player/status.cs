using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class status : MonoBehaviour
{
    public Text LifeUI;
    public int LifeStatus =100;
    // Start is called before the first frame update
    void Start()
    {
        LifeStatus = 100;
    }

    // Update is called once per frame
    void Update()
    {
        LifeUI.text = "" + LifeStatus;
    }
}
