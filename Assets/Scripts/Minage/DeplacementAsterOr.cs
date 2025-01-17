using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeplacementAsterOr : MonoBehaviour
{
   // public Transform _trigger;
    private Transform _AsterOr;
    private Transform _cible;
    private int _speed;
    // Start is called before the first frame update
    void Start()
    {
        _speed = 5;
        _AsterOr=GetComponent<Transform>();
        _cible = GameObject.Find("cible").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()

    {
        _AsterOr.position = Vector3.MoveTowards(_AsterOr.position, _cible.position, _speed * Time.deltaTime);

        
    }
}
