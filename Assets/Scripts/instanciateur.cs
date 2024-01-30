using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanciateur : MonoBehaviour
{
    public GameObject  _prefabPlasmaWeakRock, _prefabIonWeakRock, _prefabEnemy;
    int _nbRock , _nbEnenemy ,_choixRock , _waveNumber =1;
    Quaternion _rotationVide, _rotationEnemy;
    Vector3 _spawnPositionRock , _spawnPositionEnemy;
    float _spawnCooldown = 1f , _spawnTimer = 0 , _waveTempo=3f , _waveTimer=0;
    bool isFightEnded = false , _hasWaveEnded=false;
    
    // Start is called before the first frame update
    void Start()
    {
        //_prefabRock = Resources.Load<GameObject>("Assets/Prefab/Rock.prefab");
        //Debug.Log(_prefabPlasmaWeakRock);
        _nbRock = 0;
        _rotationVide = new Quaternion(0, 0, 0, 0);
        _spawnPositionRock = new Vector3(1f, 5, 5);
        _spawnPositionEnemy = new Vector3(1f, 5, 5);
        _rotationEnemy = new Quaternion(0, 180, 0, 0);
        

    }

    void _trySpawningRock()
    {
        
        _choixRock = Random.Range(0, 2);
        switch (_choixRock)
        {
            case 0:
                Instantiate(_prefabPlasmaWeakRock, _spawnPositionRock * Random.Range(50, 100) / 100, _rotationVide);
                _spawnTimer = 0;
                break;
            case 1:
                Instantiate(_prefabIonWeakRock, _spawnPositionRock * Random.Range(50, 100) / 100, _rotationVide);
                _spawnTimer = 0;
                break;
            
        }
    }
    void _trySpawningEnemy()
    {
        Debug.Log(_spawnPositionEnemy.x += 1 + Random.Range(-5, 4));
        Instantiate(_prefabEnemy ,_spawnPositionEnemy, _rotationEnemy);
        _spawnTimer = 0;
        _spawnPositionEnemy.x = 0;



    }
    void _endWave()
    {
        if (_waveTimer > _waveTempo)
        {
            _nbEnenemy = 0;
            _nbRock = 0;
            _waveNumber++;
            _waveTimer = 0;
            _hasWaveEnded = false;
        }
    }
    void _spawnWave1()
    {
        if (_nbRock < 5)
        {
            if (_spawnTimer > _spawnCooldown)
            {
                _trySpawningRock();
                _nbRock++;
            }

        }
        else
        {
            _hasWaveEnded = true;
            _endWave();
        }
    }
    void _spawnWave2()
    {
        if (_nbEnenemy < 5)
        {
            if (_spawnTimer > _spawnCooldown)
            {
                _trySpawningEnemy();
                _nbEnenemy++;
            }
        }
        else
        {
            _hasWaveEnded = true;
            _endWave();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isFightEnded)
        {
            switch (_waveNumber)
            {
                case 1:
                    _spawnWave1();
                    break;
                case 2:
                    _spawnWave2();
                    break;
                default:
                    Debug.Log("Combat Terminé");
                    isFightEnded = true;
                    break;
            }
            
        }
        if (_hasWaveEnded)
        {
            _waveTimer += Time.deltaTime;
        }
        _spawnTimer += Time.deltaTime;
    }
}