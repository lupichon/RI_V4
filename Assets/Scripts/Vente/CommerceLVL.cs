using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommerceLVL : MonoBehaviour
{
    public int _currentLVL;
    public int _compteur;

    public Caractéristiques carac;
    // Start is called before the first frame update
    void Start()
    {
        _currentLVL = carac._niveauCommerce;


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CompteurPlus() {
        _compteur ++;
        }
    public void CompteurMoins()
    {
        _compteur--;
    }
}
