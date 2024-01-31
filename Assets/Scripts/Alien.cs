using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alien : MonoBehaviour
{
    private Vector3 _posJoueur;
    private Vector3 _posAlien;
    private Vector3 _translationX;
    private float _translationZ = 1;
    private Quaternion _rotBalles;
    private GameObject _Joueur;
    private Transform _rifle;
    public float _distance;
    public Animator _animAlien;
    public GameObject _laser;
    private float temps = 0;
    private int PV = 100;
    public int degats = 20;
    public FireBullet _arme1;
    public FireBullet _arme2;
    public FireBullet _arme3;
    public FireBullet _arme4;
    public FireBullet _arme5;
    Scrollbar _alienHpBar;

    void Start()
    {
        _Joueur = GameObject.Find("XR Origin (XR Rig)");
        _rifle = transform.GetChild(1).transform.GetChild(0);
        if(_rifle == null)
        {
            Debug.Log("aaa");
        }
        else
        {
            Debug.Log("bbb");
        }
        //_rifle = childTransform.gameObject;
        _translationX = new Vector3(1, 0, 0);
        //_translationZ = new Vector3(0, 0, 1);
        _rotBalles = new Quaternion(90, 0, 0,0);

        FireBullet[] armesTrouvees = FindObjectsOfType<FireBullet>();
        _arme1 = armesTrouvees[0];
        _arme2 = armesTrouvees[1];
        _arme3 = armesTrouvees[2];
        _arme4 = armesTrouvees[3];
        _arme5 = armesTrouvees[4];

        _alienHpBar = GetComponentInChildren<Scrollbar>();
        _alienHpBar.size = 1;

    }

    // Update is called once per frame
    void Update()
    {
        float temps_avant = Time.time;
        _posJoueur = _Joueur.GetComponent<Transform>().position;
        _posAlien = GetComponent<Transform>().position;
        deplacement();
        if (Time.time-temps>1)
        {
            shot();
          
        }
        if (_animAlien.GetCurrentAnimatorStateInfo(0).IsName("Detruit"))
        {
           

            Destroy(this.gameObject);
        }
    }

    void deplacement()
    {
        _distance = Vector3.Distance(_posAlien, _posJoueur);

        Vector3 directionVersJoueur = (_posJoueur - _posAlien).normalized;
        directionVersJoueur.y = 0f;

        Quaternion rotationVersJoueur = Quaternion.LookRotation(directionVersJoueur);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, rotationVersJoueur, Time.deltaTime);

        if(_distance>7 && PV>0)
        {
            transform.Translate(Vector3.forward * _translationZ * Time.deltaTime);
        }

        _animAlien.SetBool("isAtDistance", _distance <= 7);
    }

    void shot()
    {
        if(_rifle ==  null)
        {
            Debug.Log("ccc");
        }
        Vector3 pos = _rifle.transform.position;
        if (_distance <= 10 && _animAlien.GetCurrentAnimatorStateInfo(0).IsName("shot"))
        {
            GameObject _laserInst = Instantiate(_laser, pos,new Quaternion(90,0,0,90 ));
            _laserInst.GetComponent<Rigidbody>().velocity = -_rifle.transform.up * 4;
            temps = Time.time;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("munitions"))
        {
            if (PV - _arme1._degats>0)
            {
                PV = PV - _arme1._degats;
                _alienHpBar.size = PV / 100f;
                Debug.Log(PV/100);
                _animAlien.Play("get a hit (L)");
            }
            else
            {
                PV = 0;
                _alienHpBar.gameObject.SetActive(false);
                _animAlien.Play("dead");

            }
            Destroy(collision.gameObject);
            
            
        }
    }
}


