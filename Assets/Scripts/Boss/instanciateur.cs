/*
    Ce script definit l'instanciateur des vagues du boss 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanciateur : MonoBehaviour
{
    public GameObject  _prefabPlasmaWeakRock, _prefabIonWeakRock, _prefabEnemy;
    int _nbRock, _nbEnenemy, _choixRock, _waveNumber = 1, _totalWaves = 2;
    Quaternion _rotationVide, _rotationEnemy;
    Vector3 _spawnPositionRock , _spawnPositionEnemy;
    float _spawnCooldown = 1f , _spawnTimer = 0 , _waveTempo=3f , _waveTimer=0;
    public bool isFightEnded = false, _hasWaveEnded = false, FightStarted = true, isinit = false;
    [SerializeField] GameObject boss; 
    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening("SpawnBoss", null);
        EventManager.StartListening("BossFightStart", SpawningCreep);
        //_prefabRock = Resources.Load<GameObject>("Assets/Prefab/Rock.prefab");
        //Debug.Log(_prefabPlasmaWeakRock);
        _nbRock = 0;
        _rotationVide = new Quaternion(0, 0, 0, 0);
        _rotationEnemy = new Quaternion(0, 0, 0, 0);
        FightStarted = false;

    }
  
    // On instancie un alien
    void SpawningCreep(EventParam e)
    {
        //Debug.Log(_spawnPositionEnemy.x += 1 + Random.Range(-5, 4));
        Instantiate(_prefabEnemy ,_spawnPositionEnemy, _rotationEnemy);

    }
 
    // Update is called once per frame
    void Update()
    {
  
    }
    

}
