using UnityEngine;
using System.Collections;

//ce script permet à l'astéroïde de tourner sur lui même

public class RandomRotator : MonoBehaviour
{
    
    private float vitesse = 10;

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * vitesse * Time.deltaTime;
    }
}