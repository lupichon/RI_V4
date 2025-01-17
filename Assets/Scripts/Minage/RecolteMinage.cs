using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolteMinage : MonoBehaviour
{

    private float _timerRecolte;

    private RaycastHit hit;
    private Vector3 raycastDirection;
    private float _tempsRecolte;
    private int _maxRaycastMinageDistance;
    private int _minageLvl;
    private GameObject _prefabAsterOr;
    private EventMinageOn _eventMinageOn;
    private int _stateAction; //choix de l'action en cours: 0-POV, 1-MinageOn, 2-Attack
    private int _stockGold;


    public Transform _parentAsterOr;
    public GameObject _cible;

    public AudioClip Audio;
    public AudioSource AudioSource;

    //public Minage Minage;


    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening("MinageOn", RecuperationGold);
        EventManager.StartListening("MinageLvlUp", UpdateLvl);
        _minageLvl = 1;
        raycastDirection = -transform.up;
        _stockGold = 0;



    }

    // Update is called once per frame
    void Update()
    {
        if(_stateAction==1)
        {
            Ray();
            updateScore();
        }
    }

    void Ray()
    {
      
        raycastDirection = -transform.up;
        // D�finir la direction du raycast vers l'avant (en utilisant la direction du transform.forward)


        // Effectuer le raycast
        if (Physics.Raycast(transform.position, raycastDirection, out hit, _maxRaycastMinageDistance))
        {
            // Si le raycast frappe quelque chose, imprimer le tag de l'objet touch� dans la console
            //Debug.Log("Objet touch� : " + hit.transform.tag);
        }

        // Dessiner une ligne rouge repr�sentant le raycast dans l'�diteur Unity
        Debug.DrawRay(transform.position, raycastDirection * _maxRaycastMinageDistance, Color.red);
    }
    void RecuperationGold(EventParam e)
    {
        _eventMinageOn = (EventMinageOn)e;
        _maxRaycastMinageDistance = _eventMinageOn.MaxRaycastMinageDistance;
        _tempsRecolte = _eventMinageOn.TempsRecolte;
        _stateAction = _eventMinageOn.StateAction;
        _prefabAsterOr = _eventMinageOn.PrefabAsterOr;
    }

    void UpdateLvl(EventParam e)
    {

    }
    void updateScore()
    {
        if (!Physics.Raycast(transform.position, raycastDirection, out hit, _maxRaycastMinageDistance))
        {
            return;
        }

        if (hit.collider.CompareTag("gold"))
        {
            AudioSource.PlayOneShot(Audio,0.1f);
            if (hit.distance < _maxRaycastMinageDistance)
            {

                _timerRecolte += Time.deltaTime;
                if (_timerRecolte > _tempsRecolte)
                {
                    Debug.Log("CH");
                    _timerRecolte = 0;
                    GameObject x= Instantiate(_prefabAsterOr, hit.transform.position, Quaternion.identity,_parentAsterOr);
                    x.layer = 2;       
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="AsterOR")
        {
            _stockGold = _stockGold + 1;// * _minageLvl;
            Debug.Log(_stockGold);
            Destroy(other.gameObject);
            EventManager.TriggerEvent("StockGoldReçu", new EventGoldReçu(_stockGold));

        }
    }
}
