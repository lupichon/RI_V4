using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkMovement : MonoBehaviour
{
    // Rotations en X et en Y correspondant au regard de la souris
    float _rotationX = 0.0f;
    float _rotationY = 0.0f;

    // On definit la sensibilite du regard
    public float sensivity = 3f;

    // La capsule est le joueur
    public GameObject _player;

    void Start()
    {
        // On supprime le curseur de l'ecran (on le verouille)
        Cursor.lockState = CursorLockMode.Locked;

        // La capsule est le joueur
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        // On recupere les entrees de la souris et on multiplie par la sensibilite
        _rotationX += Input.GetAxis("Mouse X") * sensivity;
        _rotationY += Input.GetAxis("Mouse Y") * sensivity;

        // On empeche la tete de pouvoir basculer trop en arriere ou en avant
        _rotationY = Mathf.Clamp(_rotationY, -90, 90);

        // On fait les mouvements correspondant aux entrees de la souris
        _player.GetComponent<Transform>().localRotation = Quaternion.Euler(0, _rotationX, 0);
        GetComponent<Transform>().localRotation = Quaternion.Euler(-_rotationY, 0, 0);
    }
}
