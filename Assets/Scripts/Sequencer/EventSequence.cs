/*
    Ce script definit la séquence du jeu 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class EventSequence : MonoBehaviour
{
    [Header("Parametres Généraux")]
    [SerializeField] private int _stateAction;//choix de l'action en cours: 0-POV, 1-MinageOn, 2-Attack

    [Header("Parametres Attack")]
    [SerializeField] private GameObject _parentBossCreep;
    [SerializeField] private float _alienSpawnTimer = 0;
    [SerializeField] private float bossTimer = 0;
    [SerializeField] private float _alienSpawnCD = 120f;
    [SerializeField] private float bossCD= 120f;

    [Header("Parametres Minage")]
    [SerializeField] private GameObject _prefabAsterOr;
    [SerializeField] private int _maxRaycastMinageDistance;
    [SerializeField] private int _tempsRecolte;
    [SerializeField] TextMeshProUGUI _textStockGold;
    [SerializeField] private int _stockGold;

    [Header("Boutons")]
    [SerializeField] GameObject _butMinOn;
    [SerializeField] GameObject _butCombatOn;
    [SerializeField] GameObject _butExit;

    [Header("Text Overlay")]
    [SerializeField] TextMeshProUGUI _textOverlay1;
    [SerializeField] TextMeshProUGUI _textOverlay2;
    [SerializeField] TextMeshProUGUI _textOverlay3;

    // Start is called before the first frame update
    void Start()
    {
        _butMinOn.GetComponent<Button>().onClick.AddListener(ButtonMinageOnClicked);
        _butCombatOn.GetComponent<Button>().onClick.AddListener(ButtonCombatOnClicked);
        _butExit.GetComponent<Button>().onClick.AddListener(ButtonExitClicked);
        EventManager.StartListening("StockGoldReçu", UpdateGoldStock);


    }

    // Update is called once per frame
    void Update()
    {
        SpawnMobControl();
        SpawnBossControl();
        UpdateTextOverlay();


    }
     void UpdateTextOverlay()
    {
        _textOverlay1.text = "Temps avant BossFight " + (int)(bossCD - bossTimer);
        _textOverlay2.text = "Temps avant Intrusion " + (int)(_alienSpawnCD - _alienSpawnTimer);
        _textOverlay3.text = "Minez !!!";
    }
    void UpdateGoldStock(EventParam e)
    {
        EventGoldReçu _eventGoldReçu= (EventGoldReçu) e;
        _stockGold = _eventGoldReçu.StockGold;
        _textStockGold.text = _stockGold + "/150";

        
    }
    void ControlEndBossWave()
    {
        if(_parentBossCreep.transform.childCount == 0)
        {
            EventManager.TriggerEvent("EndBossWave");
        }

    }
    void ButtonCombatOnClicked()
    {
        _stateAction = 2;
        EventManager.TriggerEvent("BossFightOn");
    }
    void ButtonExitClicked()
    {
        _stateAction = 0;
        EventManager.TriggerEvent("PlayerView");
    }
    void ButtonMinageOnClicked()
    {
        _stateAction = 1;
        EventManager.TriggerEvent("MinageOn",new EventMinageOn(_prefabAsterOr,_maxRaycastMinageDistance,_tempsRecolte,_stateAction));
    }
  
    void SpawnMobControl()
    {
        // Toute les 120 secondes on fait apparaitre une vague d'aliens dans le vaisseau si l'on est pas en combat contre le boss 

        _alienSpawnTimer += Time.deltaTime;
        if (_alienSpawnTimer > _alienSpawnCD )
        {
            EventManager.TriggerEvent("SpawnMob");
            _alienSpawnTimer = 0;
        }
    }
    /*
     
    void ShootBossBullet()
    {
        if(true)//mettre la condition du clique déclecnhé par l'appuie d'une touche
        {
            GameObject spawnedBullet = Instantiate(_bullet, _spawnPoint.position, _rotationBullet);
            AudioSource.PlayOneShot(Tir);
            spawnedBullet.transform.position = _spawnPoint.position;
            spawnedBullet.GetComponent<Rigidbody>().velocity = -_spawnPoint.up * _fireSpeed;
            Destroy(spawnedBullet, 5);
        }   
    }
    */
    void SpawnBossControl()
    {
        bossTimer += Time.deltaTime;
        //Apres deux minutes on fait spawn le boss 
        if (bossTimer > bossCD)
        {
            EventManager.TriggerEvent("SpawnBoss");
        }
    }
}
