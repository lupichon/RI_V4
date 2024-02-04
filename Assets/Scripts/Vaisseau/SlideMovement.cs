using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMovement : MonoBehaviour
{
    // Transform du joueur
    public Transform player;

    // Mouvement (fleches directionnelles)
    public float _inputX;
    public float _inputZ;
    public float _speed = 4.0f;

    // GameObject de la camera
    public GameObject _camera;

    // Ne sert pas
    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
        _camera = GameObject.Find("Main Camera");
    }

    // MoveX et MoveZ permettent au joueur de se deplacer d'avant en arriere ou sur les cotes
    public void moveX()
    {
        player.Translate(Vector3.right * (_inputX * _speed * Time.deltaTime), Space.Self);
    }

    public void moveZ()
    {
        player.Translate(Vector3.forward * (_inputZ * _speed * Time.deltaTime), Space.Self);
    }

    void Update()
    {
        // On se deplace en recuperant les entrees des fleches directionnelles
        _inputX = Input.GetAxis("Horizontal");
        _inputZ = Input.GetAxis("Vertical");
            
        moveX();
        moveZ();

        // Si on sort c'est a dire si on tombe en dehors de la map, on est remis au point initial
        if (GetComponent<Transform>().position.y < -2)
        {
            GetComponent<Transform>().position = new Vector3(-0.29f, 1.8f, 0.85f);
        }
    }
}
