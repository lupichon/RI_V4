using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButMinON : MonoBehaviour
{
    public GameObject xr_ori;
    public GameObject siege;
    private GameObject Ship;
    private GameObject canon;
    public GameObject mainDroite;
    public GameObject canonspawn;

    public ButMineOFF butoff;

    public bool MinageON;
    // Start is called before the first frame update
    void Start()
    {
    GetComponent<Button>().onClick.AddListener(ButtonClicked);
    canon = GameObject.Find("Canon");
        MinageON = false;
        Ship = GameObject.Find("Vaisseau Spatial");
        
    }

    // Update is called once per frame
    void Update()
    {
        ifMinageON(MinageON);
        
    }
    void ButtonClicked()
    {
        butoff.MinOFF = false;
        MinageON = true;
    }
    void ifMinageON(bool test)
    {
        if(test==true)
        {
            //on set le continuous Move Provider a false
            xr_ori.transform.position=siege.transform.position;
            xr_ori.transform.rotation=siege.transform.rotation;
            canon.transform.parent = mainDroite.transform;
            Ship.GetComponent<followLevier>().enabled = true;

        }
        else
        {
            canon.transform.parent = canonspawn.transform;
            canon.transform.position=canonspawn.transform.position;
            canon.transform.rotation=canonspawn.transform.rotation;
            Ship.GetComponent<followLevier>().enabled = false;
        }

    }
}
