using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class _bossThrownRock : MonoBehaviour
{

    int _damage = 20;
    Transform _tfRock;
    Vector3 _direction;
    float _speed = 0.2f;
    float _lifeSpan = 10000f;
    float _age = 0;
    Vector3 _shipPosition;
    float disttest = 0.3f;

    public AudioClip mortmob;
    public AudioClip Hitnous;
    Transform cible;
    public AudioSource XR;

    // Start is called before the first frame update
    void Start()
    {

        _tfRock = GetComponent<Transform>();
        _direction = new Vector3(0, 0, 1);
        _shipPosition = new Vector3(0, 0, -12);
        XR = GameObject.Find("Ambiance").GetComponent<AudioSource>();
        cible = GameObject.Find("CibleMOB").GetComponent<Transform>();
        _tfRock.LookAt(cible);
    }

    // Update is called once per frame
    void Update()
    {
        _direction = _tfRock.position - cible.position;

        _age += Time.deltaTime;
        _tfRock.Translate(_direction * -_speed * Time.deltaTime);
        
        if(_age>_lifeSpan)
        {
            XR.PlayOneShot(mortmob);
            Destroy(_tfRock.gameObject);
        }
        if((_tfRock.position - cible.position).magnitude < disttest)
        {
            
            Debug.Log("DestroyRock");
            HealthUpdate(_damage);
            XR.PlayOneShot(Hitnous);

            Destroy(_tfRock.gameObject);
        }
    }
    private void HealthUpdate(int damage)
    {
        if(PlayerHpBar._playerHealth>=1) PlayerHpBar._playerHealth -= damage;    
    }
}

