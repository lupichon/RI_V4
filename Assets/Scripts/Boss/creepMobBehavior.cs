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
    [SerializeField] float disttest = 0.3f;
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
        disttest = 1;
    }
 /*   private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered");
        if (other.gameObject.name == "CibleMOB")
        {
            HealthUpdateE(_damageE);
            XR.PlayOneShot(Hitnous);

            Destroy(_tfEnemy.gameObject);
        }
    }*/
    // Update is called once per frame
    void Update()
    {
        // On trouve la direction vers la cible 
        _directionEnemy = _tfEnemy.position - cible.position;
        //Si il est n'est pas mort il se déplace et cherche a attaqué
        if (!isDead)
        {
            //On s'y déplace
            _ageE += Time.deltaTime;
            _tfEnemy.Translate(_directionEnemy * -_speedE * Time.deltaTime);
            //Sécurité 
            if (_ageE > _lifeSpanE)
            {
                XR.PlayOneShot(mortmob);
                Destroy(_tfEnemy.gameObject);
            }
            //On test si il est pas a distance de la cible 
            if ((_tfEnemy.position - cible.position).magnitude < disttest)
            {
                Debug.Log("Destroy");
                HealthUpdateE(_damageE);
                XR.PlayOneShot(Hitnous);

                Destroy(_tfEnemy.gameObject);
            }
        }
        // Si il est mort alors il lance son animation de mort et attend la fin de celle ci pour se détruire
        else
        {
            _deathTimer += Time.deltaTime;
            if(_deathTimer > _deathCooldown)
            {
                XR.PlayOneShot(mortmob);
                Destroy(_tfEnemy.gameObject);
            }
        }
       
    }
    
    private void HealthUpdateE(int damage)
    {
        if (PlayerHpBar._playerHealth >= 1) PlayerHpBar._playerHealth -= damage;
    }
}

