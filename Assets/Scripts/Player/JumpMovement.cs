using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMovement : MonoBehaviour
{
    public Rigidbody _rigidBodyPlayer;

    // "Hauteur" du saut
    public float _jumpAmount = 10;

    void Start()
    {
        // On recupere le rigidbody du joueur
        _rigidBodyPlayer = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // Si on presse espace, une force de poussee vers le haut fait monter le joueur
            _rigidBodyPlayer.AddForce(Vector3.up * _jumpAmount, ForceMode.Impulse);
        }
    }
}