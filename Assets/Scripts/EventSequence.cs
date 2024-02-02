using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSequence : MonoBehaviour
{
    [SerializeField] SpawnAliens Aliens;
    [SerializeField] instanciateur inst;
    float _alienSpawnTimer = 0, _alienSpawnCD = 120f, bossTimer = 0, bossCD= 20f;
    public bool hasFightStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _alienSpawnTimer += Time.deltaTime;
        bossTimer += Time.deltaTime;
        if (!hasFightStarted && _alienSpawnCD <  _alienSpawnTimer)
        {
            Aliens.spawnAlien();
            _alienSpawnTimer = 0 ;

        }
        if(bossTimer > bossCD)
        {
            inst.FightStarted = true;
        }
    }
}
