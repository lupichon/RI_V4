using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatOFF : MonoBehaviour
{
    public CombatON combaton;
    public bool combatOFF;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonClicked);
        combatOFF = true;

    }

    // Update is called once per frame
    void Update()
    {
       
        


    }
    void ButtonClicked()
    {
        combatOFF = true;
        combaton.isCombatON = false;
    }

    
}
