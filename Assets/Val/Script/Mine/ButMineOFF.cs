using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButMineOFF : MonoBehaviour
{
    public ButMinON minon;
    public bool MinOFF;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonClicked);
        MinOFF = true;

    }

    // Update is called once per frame
    void Update()
    {
       
        


    }
    void ButtonClicked()
    {
        MinOFF = true;
        minon.MinageON = false;
    }

    
}
