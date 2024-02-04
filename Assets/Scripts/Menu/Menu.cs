using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

//ce script permet la rotation du vaisseau dans le menu et l'affichage des scores dans la fenêtre Scores

public class Menu : MonoBehaviour
{
    private GameObject _canvas;
    private float _rotationSpeed = 30;
    private float _rotationZ = 7;
    public TextMeshProUGUI _texteMeshPro1, _texteMeshPro2, _texteMeshPro3;
    string cheminFichier = Application.dataPath + "/Scores.txt";

    void Start()        //a chaque fois que la scène est lancée, on lit les valeurs dans le fichier puis on les écrit sur le tableau des scores 
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
        transform.RotateAround(_canvas.transform.position, rotationAxis, Rotation);     //rotation autour du joueur

        transform.Rotate(Vector3.forward,_rotationZ*Time.deltaTime);                    //rotation sur lui même
    }
}

