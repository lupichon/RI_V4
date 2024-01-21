using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private GameObject _canvas;
    private float _rotationSpeed = 30;
    private float _rotationZ = 7;
    void Start()
    {
        _canvas = GameObject.Find("Canvas");
        
    }

    void Update()
    {
        float deltaT = Time.deltaTime;
        Vector3 rotationAxis = Vector3.up;
        float Rotation = _rotationSpeed * deltaT;
        transform.RotateAround(_canvas.transform.position, rotationAxis, Rotation);

        transform.Rotate(Vector3.forward,_rotationZ*Time.deltaTime);
    }
}
