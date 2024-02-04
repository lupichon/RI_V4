/*
    Ce script definit le comportement du bouton combatON
*/
using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    GameObject UI;
    GameObject volant;
    GameObject canon;
    public CombatOFF comboff;
    [SerializeField] ButMinON _butMinON;
    public bool isCombatON;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonClicked);
        canon = GameObject.Find("Canon");

        canonGauche = GameObject.Find("ArmeGauche");
        canonDroit = GameObject.Find("ArmeDroit");
        isCombatON = false;
        Ship = GameObject.Find("Vaisseau Spatial");
        UI= GameObject.Find("BossFigthUI");

        volant = GameObject.Find("Wheel");
    }

    // Update is called once per frame
    void Update()
    {
        ifCombatOn(isCombatON);
        
    }
    // lorqu'on clique il passe le combat ON a true 
    void ButtonClicked()
    {
        comboff.combatOFF = false;
        isCombatON = true;
        _butMinON.MinageON = false;
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
            canonGauche.transform.parent = mainGauche.transform;
            Ship.GetComponent<followLevier>().enabled = true;

            // On active les scripts
            UI.SetActive(true);
            canonDroit.GetComponent<RightRayCastShooter>().enabled = true;
            canonGauche.GetComponent<LeftRayCastShooter>().enabled = true;
            volant.SetActive(false);

        }
        else
        {
            if (!_butMinON.MinageON)
            {
                //On range les cannons
                canonDroit.transform.parent = canonspawn.transform;
                canonDroit.transform.position = canonspawn.transform.position;
                canonGauche.transform.parent = canon.transform;
                canonGauche.transform.position = canon.transform.position;
                Ship.GetComponent<followLevier>().enabled = false;

                //On desactive les scripts 
                UI.SetActive(false);
                volant.SetActive(true);
                canonDroit.GetComponent<RightRayCastShooter>().enabled = false;
                canonGauche.GetComponent<LeftRayCastShooter>().enabled = false;
            }
        }

    }
}
