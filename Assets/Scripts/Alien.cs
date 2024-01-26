using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    private Transform _posJoueur;
    private GameObject _Joueur;
    void Start()
    {
        _Joueur = GameObject.Find("XR Origin (Xr Rig)");
    }

    // Update is called once per frame
    void Update()
    {
        _posJoueur = _Joueur.GetComponent<Transform>();
    }
}
