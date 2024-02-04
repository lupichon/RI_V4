using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ce script permet de gérer le comportement des aliens

public class Alien : MonoBehaviour
{
    private Vector3 _posJoueur;
    private Vector3 _posAlien;
    private float _translationZ = 3;
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

    public AudioClip Tir;
    public AudioClip Hit1;
    public AudioClip Hit2;
    public AudioClip Mort;



    public AudioSource AudioSource;

    Scrollbar _alienHpBar;

    void Start()
    {
        _Joueur = GameObject.Find("XR Origin (XR Rig)");
        _rifle = transform.GetChild(1).transform.GetChild(0);
        
        _rotBalles = new Quaternion(90, 0, 0,0);

        FireBullet[] armesTrouvees = FindObjectsOfType<FireBullet>();       //récuperation des armes de la scene
        _arme1 = armesTrouvees[0];
        _arme2 = armesTrouvees[1];
        _arme3 = armesTrouvees[2];
        _arme4 = armesTrouvees[3];
        _arme5 = armesTrouvees[4];

        _alienHpBar = GetComponentInChildren<Scrollbar>();                  //recuperation de la barre d'HP de l'alien
        _alienHpBar.size = 1;                                               //au depart, il a toute sa vie

    }

    // Update is called once per frame
    void Update()
    {
        float temps_avant = Time.time;          
        _posJoueur = _Joueur.GetComponent<Transform>().position;            //recuperation de la position du joueur
        _posAlien = GetComponent<Transform>().position;                     //idem pour l'alien 
        deplacement();                                                      //l'alien se deplace 
        if (Time.time-temps>1)                                              
        {
            shot();                                                         //on attend toujours au moins une seconde entre chaque tire
        }
        if (_animAlien.GetCurrentAnimatorStateInfo(0).IsName("Detruit"))
        {
            Destroy(this.gameObject);                                       //si l'alien est dans l'etat detruit alors on l'enleve de la scene
        }
    }

    void deplacement()  //fonction qui gere le deplacement de l'alien
    {
        _distance = Vector3.Distance(_posAlien, _posJoueur);                                                            //calcul de la distance entre le joueur et l'alien 

        Vector3 directionVersJoueur = (_posJoueur - _posAlien).normalized;                                              //calcul de la direction vers le joueur
        directionVersJoueur.y = 0f;                                                                                     //on n'a pas besoin du y

        Quaternion rotationVersJoueur = Quaternion.LookRotation(directionVersJoueur);                                   //calcul de la rotation à effectuer en fonction de la direction 
        transform.localRotation = Quaternion.Slerp(transform.localRotation, rotationVersJoueur, 3*Time.deltaTime);      //réalisation de la rotation

        if(_distance>7 && PV>0)
        {
            transform.Translate(Vector3.forward * _translationZ * Time.deltaTime);      //si la distance est plus grande que 7, l'alien avance
        }

        _animAlien.SetBool("isAtDistance", _distance <= 7);                             //permet de gerer les transitions dans l'animator 
    }

    void shot()     //fonction qui gere le tire de l'alien
    {
        Vector3 pos = _rifle.transform.position;                                            //on recuperer la postion du canon
        if (_distance <= 7 && _animAlien.GetCurrentAnimatorStateInfo(0).IsName("shot"))     //si la distance est petite et que l'alien est bien dans l'etat de tirer alors
        {
            GameObject _laserInst = Instantiate(_laser, pos,new Quaternion(90,0,0,90 ));    //on instancie la balle
            _laserInst.GetComponent<Rigidbody>().velocity = -_rifle.transform.up * 4;       //on tire la balle 

            AudioSource.PlayOneShot(Tir);
            Destroy(_laserInst, 5);                                                         //puis on la détruit au bout d'un certain temps si elle est encore présente dans la scène 

            temps = Time.time;                                                              //calcul du temps pour le délai dattente d'une seconde entre deux tirs
        }
    }

    void OnCollisionEnter(Collision collision)      
    {
        if(collision.gameObject.CompareTag("munitions"))    //si l'alien est touché par une balle alors 
        {
            if (PV - _arme1._degats>0)                      //si il a encore des PV
            {
                AudioSource.PlayOneShot(Hit1);

                PV = PV - _arme1._degats;                   //on lui enleve les PV correspondant
                _alienHpBar.size = PV / 100f;               //on met à jour la barre d'HP
                _animAlien.Play("get a hit (L)");           //on joue l'animation correspondante à la situation
            }
            else                                            //si l'alien n'a plus de PV
            {   
                PV = 0;                                     
                _alienHpBar.gameObject.SetActive(false);    //on desactive la barre d'HP
                _animAlien.Play("dead");                    //on joue l'animation de la mort 
                AudioSource.PlayOneShot(Mort);              


            }
            Destroy(collision.gameObject);                  //on detruit la balle qui a touché l'alien    
        }
    }
}


