using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatON : MonoBehaviour
{
    public GameObject xr_ori;
    public GameObject siege;
    private GameObject Ship;
    private GameObject canonDroit;
    private GameObject canonGauche;
    public GameObject mainDroite;
    public GameObject mainGauche;
    public GameObject canonspawn;

    public CombatOFF comboff;

    public bool isCombatON;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonClicked);
        canonGauche = GameObject.Find("ArmeGauche");
        canonDroit = GameObject.Find("ArmeDroit");
        isCombatON = false;
        Ship = GameObject.Find("Vaisseau Spatial");
        
    }

    // Update is called once per frame
    void Update()
    {
        ifCombatOn(isCombatON);
        
    }
    void ButtonClicked()
    {
        comboff.combatOFF = false;
        isCombatON = true;
    }

    void ifCombatOn(bool test)
    {
        if(test==true)
        {
            //on set le continuous Move Provider a false
            //On sort les cannons
            xr_ori.transform.position=siege.transform.position;
            xr_ori.transform.rotation=siege.transform.rotation;
            canonDroit.transform.parent = mainDroite.transform;
            canonDroit.transform.rotation = canonspawn.transform.rotation;
            canonGauche.transform.parent = mainGauche.transform;
            canonGauche.transform.rotation = canonspawn.transform.rotation;
            Ship.GetComponent<followLevier>().enabled = true;

            // On active les scripts
            GameObject.Find("BossFigthUI").SetActive(true);
            if (GetComponent<RightRayCastShooter>() != null) GetComponent<RightRayCastShooter>().enabled = true;
            if (GetComponent<LeftRayCastShooter>() != null) GetComponent<LeftRayCastShooter>().enabled = true;

        }
        else
        {
            //On range les cannons
            canonDroit.transform.parent = canonspawn.transform;
            canonDroit.transform.position=canonspawn.transform.position;
            canonDroit.transform.rotation=canonspawn.transform.rotation;
            canonGauche.transform.parent = canonspawn.transform;
            canonGauche.transform.position = canonspawn.transform.position;
            canonGauche.transform.rotation = canonspawn.transform.rotation;
            Ship.GetComponent<followLevier>().enabled = false;

            //On desactive les scripts 
            GameObject.Find("BossFigthUI").SetActive(true);

            if (GetComponent<RightRayCastShooter>()!=null) GetComponent<RightRayCastShooter>().enabled = false;
            if(GetComponent<LeftRayCastShooter>()!=null) GetComponent<LeftRayCastShooter>().enabled = false;
        }

    }
}
