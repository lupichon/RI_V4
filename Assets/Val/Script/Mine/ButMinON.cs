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
    Arme _minage;
    public ButMineOFF butoff;
    public ParticleSystem part;
    [SerializeField] CombatON _combatON;
    public bool MinageON;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonClicked);
        canon = GameObject.Find("Canon");
        MinageON = false;
        Ship = GameObject.Find("Vaisseau Spatial");
       _minage = canon.GetComponentInChildren<Arme>();

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
        _combatON.isCombatON = false;

    }
    void ifMinageON(bool test)
    {
        if(test==true )
        {
            //on set le continuous Move Provider a false
            xr_ori.transform.position=siege.transform.position;
            xr_ori.transform.rotation=siege.transform.rotation;
            canon.transform.parent = mainDroite.transform;
            Ship.GetComponent<followLevier>().enabled = true;
            _minage.enabled = true;
            part.Play();
            

        }
        else
        {
            if (!_combatON.isCombatON)
            {
                canon.transform.parent = canonspawn.transform;
                canon.transform.position = canonspawn.transform.position;
                canon.transform.rotation = canonspawn.transform.rotation;
                Ship.GetComponent<followLevier>().enabled = false;
                _minage.enabled = false;
                part.Stop();
                

            }
        }

    }
}
