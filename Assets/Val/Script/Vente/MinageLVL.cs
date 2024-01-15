using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinageLVL : MonoBehaviour
{
    public int _currentLVL;
    public int _compteur;

    public Caractéristiques carac;
    // Start is called before the first frame update
    void Start()
    {
        _currentLVL = carac._niveauMinage;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CompteurPlus()
    {
        _compteur++;
    }
    public void CompteurMoins()
    {
        _compteur--;
    }
}
