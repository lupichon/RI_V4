/*
    Ce script definit la séquence du jeu 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class EventSequence : MonoBehaviour
{
    [SerializeField] SpawnAliens Aliens;
    [SerializeField] instanciateur inst;
    [SerializeField] float _alienSpawnTimer = 0, _alienSpawnCD = 120f, bossTimer = 0, bossCD= 120f;
    [SerializeField] GameObject _butMinOn;
    [SerializeField] GameObject _butMinOff;
    [SerializeField] GameObject _butCombatOn;
    [SerializeField] GameObject _butCombatOff;
    [SerializeField] GameObject _parentBossCreep;

    // Start is called before the first frame update
    void Start()
    {
        _butMinOn.GetComponent<Button>().onClick.AddListener(ButtonMinageOnClicked);
        _butMinOff.GetComponent<Button>().onClick.AddListener(ButtonMinageOffClicked);
        _butCombatOn.GetComponent<Button>().onClick.AddListener(ButtonCombatOnClicked);
        _butCombatOff.GetComponent<Button>().onClick.AddListener(ButtonCombatOffClicked);


    }

    // Update is called once per frame
    void Update()
    {
        SpawnMobControl();
        SpawnBossControl();



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
        EventManager.TriggerEvent("BossFightOn");
    }
    void ButtonCombatOffClicked()
    {
        EventManager.TriggerEvent("BossFightOff");
    }
    void ButtonMinageOnClicked()
    {
        EventManager.TriggerEvent("MinageOn");
    }
    void ButtonMinageOffClicked()
    {
        EventManager.TriggerEvent("MinageOff");
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
