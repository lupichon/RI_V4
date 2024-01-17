using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lacher : MonoBehaviour
{
    public Piloter Pilote;
    public bool piloteOff;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonClicked);
        piloteOff = true;

    }

    // Update is called once per frame
    void Update()
    {




    }
    void ButtonClicked()
    {
        piloteOff = true;
        Pilote.piloteON = false;
    }


}
