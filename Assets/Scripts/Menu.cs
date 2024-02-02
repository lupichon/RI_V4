using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private GameObject _canvas;
    private float _rotationSpeed = 30;
    private float _rotationZ = 7;
    public TextMeshProUGUI _texteMeshPro1, _texteMeshPro2, _texteMeshPro3;
    string cheminFichier = Application.dataPath + "/Scores.txt";

    void Start()
    {
        _canvas = GameObject.Find("Canvas");

        string[] lignesFichier = File.ReadAllLines(cheminFichier);
        _texteMeshPro1.text = "1 - " + lignesFichier[0];
        _texteMeshPro2.text = "2 - " + lignesFichier[1];
        _texteMeshPro3.text = "3 - " + lignesFichier[2];
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

