/*
    Ce script definit la séquence du jeu 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSequence : MonoBehaviour
{
    [SerializeField] SpawnAliens Aliens;
    [SerializeField] instanciateur inst;
    float _alienSpawnTimer = 0, _alienSpawnCD = 45f, bossTimer = 0, bossCD= 120f;
    public bool hasFightStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Toute les 45 secondes on fait apparaitre une vague d'aliens dans le vaisseau si l'on est pas en combat contre le boss 
        _alienSpawnTimer += Time.deltaTime;
        bossTimer += Time.deltaTime;
        if (!hasFightStarted && _alienSpawnCD <  _alienSpawnTimer)
        {
            Aliens.spawnAlien();
            _alienSpawnTimer = 0 ;

        }
        //Apres deux minute on fait spawn le boss 
        if(bossTimer > bossCD)
        {
            inst.FightStarted = true;
        }
    }
}
