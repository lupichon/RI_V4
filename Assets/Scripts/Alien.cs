using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    private Vector3 _posJoueur;
    private Vector3 _posAlien;
    private Vector3 _translationX, _translationZ;
    private Quaternion _rotBalles;
    private GameObject _Joueur,_rifle;
    public float _distance;
    public Animator _animAlien;
    public GameObject _laser;
    void Start()
    {
        _Joueur = GameObject.Find("XR Origin (XR Rig)");
        _rifle = GameObject.Find("spawnlaser");
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
        Vector3 pos = _rifle.transform.position;
        //pos.y = pos.y + 1.5f;
        //pos.z = pos.z + 0.9f;
        //pos.x = pos.x + 0.1f;
        if (_distance <= 10 && _animAlien.GetCurrentAnimatorStateInfo(0).IsName("shot"))
        {
       
            Instantiate(_laser, pos,new Quaternion(90,0,0,90 ));
        }
    }
}


