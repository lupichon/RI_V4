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
    public GameObject mainDroite;
    public GameObject mainGauche;
    public GameObject canonspawn;
    GameObject UI;
    GameObject volant;
    GameObject canon;
    public CombatOFF comboff;
    [SerializeField] ButMinON _butMinON;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening("BossFightOn", CombatOn);
        canon = GameObject.Find("Canon");
        Ship = GameObject.Find("Vaisseau Spatial");
        UI= GameObject.Find("BossFigthUI");
        volant = GameObject.Find("Wheel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   

    void CombatOn(EventParam e)
    {
        //on set le continuous Move Provider a false
        //On sort les cannons
        xr_ori.transform.position=siege.transform.position;
        xr_ori.transform.rotation = siege.transform.rotation;
        canonDroit.transform.parent = mainDroite.transform;
        Ship.GetComponent<followLevier>().enabled = true;
        // On active les scripts
        UI.SetActive(true);
        canonDroit.GetComponent<RightRayCastShooter>().enabled = true;
        volant.SetActive(false);
    }
}
