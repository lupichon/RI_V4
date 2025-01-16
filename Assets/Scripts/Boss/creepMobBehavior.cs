/*
    Ce script definit le comportement de l'alien  avec la même sécurité que pour les rochers 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class _creepMobBehavior : MonoBehaviour
{
    Animator _ani;
    public bool isDead=false;
    int _damageE = 2;
    Transform _tfEnemy;
    Vector3 _directionEnemy;
    float _speedE = 0.2f, _lifeSpanE = 10000f, _ageE = 0,_deathTimer=0,_deathCooldown=2.5f;
    Vector3 _shipPositionE;
    Transform cible;
    [SerializeField] float _distanceCible = 0.3f;
    public AudioClip mortmob;
    public AudioClip Hitnous;

    public AudioSource XR;

    // Start is called before the first frame update
    void Start()
    {
        _tfEnemy = GetComponent<Transform>();
        _directionEnemy = new Vector3(0, 0, -1);
        _shipPositionE = new Vector3(0, 0, -12);
        _ani = GetComponent<Animator>();
        cible = GameObject.Find("CibleMOB").GetComponent<Transform>();
        _tfEnemy.LookAt(cible);
        XR = GameObject.Find("Ambiance").GetComponent<AudioSource>();
        _distanceCible = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // On trouve la direction vers la cible 
        _directionEnemy = _tfEnemy.position - cible.position;
      
       
            //On test le Creep est a distance de la cible 
            if (_directionEnemy.magnitude < _distanceCible)
            {
            //Si il l'est :
                HealthUpdateE(_damageE);
                XR.PlayOneShot(Hitnous);
                Destroy(_tfEnemy.gameObject);
            //lancer une coroutine toutes les secondes on prend des degats +lancer l'animation d'attaque
            }
    } 

    
    
    void HealthUpdateE(int damage)
    {
        if (PlayerHpBar._playerHealth >= 1)
        {
            PlayerHpBar._playerHealth -= damage;
        }
        else
        {
            //on est mort donc fin de partie ?
        }
    }
}

