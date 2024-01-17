using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piloter : MonoBehaviour
{
    public GameObject xr_ori;
    public GameObject siege;
    public GameObject Ship;

    public Lacher butoff;

    public bool piloteON;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonClicked);
        piloteON = false;

    }

    // Update is called once per frame
    void Update()
    {
        ifMinageON(piloteON);

    }
    void ButtonClicked()
    {
        butoff.piloteOff = false;
        piloteON = true;
    }
    void ifMinageON(bool test)
    {
        if (test == true)
        {
            //on set le continuous Move Provider a false
            xr_ori.transform.position = siege.transform.position;
            xr_ori.transform.rotation = siege.transform.rotation;
            Ship.GetComponent<followLevier>().enabled = true;
            Debug.Log("IEULHFOEUFBIOEGUBOEIUPFBOUIENVIDRUOOUNIUPER");

        }
        /*
        else
        {
            canon.transform.parent = canonspawn.transform;
            canon.transform.position = canonspawn.transform.position;
            canon.transform.rotation = canonspawn.transform.rotation;
        }
        */

    }
}
