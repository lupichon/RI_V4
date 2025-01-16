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
    public RecolteMinage _recolteMinage;
    public ButMineOFF butoff;
    public ParticleSystem _particuleMinage;
    [SerializeField] CombatON _combatON;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening("MinageOn", MinageOn);
        
        canon = GameObject.Find("Canon");

        Ship = GameObject.Find("Vaisseau Spatial");
        _recolteMinage = canon.GetComponent<RecolteMinage>();

    }

    // Update is called once per frame
    void Update()
    {

        
    }
   
    void MinageOn(EventParam e)
    {
        //on set le continuous Move Provider a false
        xr_ori.transform.position=siege.transform.position;
        xr_ori.transform.rotation=siege.transform.rotation;
        canon.transform.parent = mainDroite.transform;
        _recolteMinage.enabled = true;
        _particuleMinage.Play();
    }
}
