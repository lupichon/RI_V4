using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moteur : MonoBehaviour
{
    public AudioClip Propu;
    public AudioSource _Moteur;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _Moteur.PlayOneShot(Propu, 0.1f);
        
    }
}
