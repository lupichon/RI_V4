using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class _creepMobBehavior : MonoBehaviour
{
    Animator _ani;
    public bool isDead=false;
    int _damageE = 1;
    Transform _tfEnemy;
    Vector3 _directionEnemy;
    float _speedE = 0.75f, _lifeSpanE = 10f, _ageE = 0,_deathTimer=0,_deathCooldown=2.5f;
    Vector3 _shipPositionE;

    // Start is called before the first frame update
    void Start()
    {
        _tfEnemy = GetComponent<Transform>();
        _directionEnemy = new Vector3(0, 0, -1);
        _shipPositionE = new Vector3(0, 0, 0);
        _ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!isDead)
        {
            _ageE += Time.deltaTime;
            _tfEnemy.Translate(_directionEnemy * -_speedE * Time.deltaTime);

            if (_ageE > _lifeSpanE)
            {
                Destroy(_tfEnemy.gameObject);
            }
            if (_tfEnemy.position.z < _shipPositionE.y)
            {
                //Debug.Log("Destroy");
                HealthUpdateE(_damageE);
                Destroy(_tfEnemy.gameObject);
            }
        }
        else
        {
            _deathTimer += Time.deltaTime;
            if(_deathTimer > _deathCooldown)
            {
                Destroy(this);
            }
        }
       
    }
    
    private void HealthUpdateE(int damage)
    {
        if (PlayerHpBar._playerHealth >= 1) PlayerHpBar._playerHealth -= damage;
    }
}

