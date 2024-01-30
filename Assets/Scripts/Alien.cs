using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    private Vector3 _posJoueur;
    private Vector3 _posAlien;
    private Vector3 _translationX, _translationZ;
    private Quaternion _rotBalles;
    private GameObject _Joueur;
    public float _distance;
    public Animator _animAlien;
    public GameObject _laser;
    void Start()
    {
        _Joueur = GameObject.Find("XR Origin (XR Rig)");
        _translationX = new Vector3(1, 0, 0);
        _translationZ = new Vector3(0, 0, 1);
        _rotBalles = new Quaternion(90, 0, 0,0);
    }

    // Update is called once per frame
    void Update()
    {
        _posJoueur = _Joueur.GetComponent<Transform>().position;
        _posAlien = GetComponent<Transform>().position;
        deplacement();
        shot();
    }
    void deplacement()
    {
        _distance = Mathf.Pow(_posAlien[0] - _posJoueur[0], 2) + Mathf.Pow(_posAlien[2] - _posJoueur[2], 2);
        if (_distance > 10)
        {
            if (_posAlien[0] - _posJoueur[0] > 0.1 || _posAlien[0] - _posJoueur[0] < -0.1)
            {
                if (_posAlien[0] - _posJoueur[0] > 0)
                {
                    GetComponent<Transform>().position -= _translationX * Time.deltaTime;
                }
                else if (_posAlien[0] - _posJoueur[0] < 0)
                {
                    GetComponent<Transform>().position += _translationX * Time.deltaTime;
                }
            }
            if (_posAlien[2] - _posJoueur[2] > 0.1 || _posAlien[2] - _posJoueur[2] < -0.1)
            {
                if (_posAlien[2] - _posJoueur[2] > 0)
                {
                    GetComponent<Transform>().position -= _translationZ * Time.deltaTime;
                }
                else if (_posAlien[2] - _posJoueur[2] < 0)
                {
                    GetComponent<Transform>().position += _translationZ * Time.deltaTime;
                }
            }
            _animAlien.SetBool("isAtDistance", false);
        }
        else
        {
            _animAlien.SetBool("isAtDistance", true);
        }
        Vector3 directionVersJoueur = _posJoueur - _posAlien;
        directionVersJoueur.y = 0f;
        Quaternion rotationVersJoueur = Quaternion.LookRotation(directionVersJoueur);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationVersJoueur, Time.deltaTime);
    }

    void shot()
    {
        if (_distance <= 10 && _animAlien.GetCurrentAnimatorStateInfo(0).IsName("shot"))
        {
            GameObject rifle = GameObject.Find("Box001");
            Instantiate(_laser, rifle.transform.position, Quaternion.identity );
        }
    }
}
/*
_spawnTimer += Time.deltaTime;
if (_nbRock < 25 && _spawnTimer >= _spawnCooldown)
{
    _choixRock = Random.Range(0, 2);
    switch (_choixRock)
    {
        case 0:
            Instantiate(_prefabPlasmaWeakRock, _spawnPosition * Random.Range(50, 100) / 100, _rotationVide);
            _spawnTimer = 0;
            break;
        case 1:
            Instantiate(_prefabIonWeakRock, _spawnPosition * Random.Range(50, 100) / 100, _rotationVide);
            _spawnTimer = 0;
            break;
    }
}*/

