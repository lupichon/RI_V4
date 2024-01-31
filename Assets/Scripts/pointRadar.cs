using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointRadar : MonoBehaviour
{
    public List<GameObject> objListe;
    // Start is called before the first frame update
    void Start()
    {
        objListe = GameObject.Find("Radar").GetComponent<_detectionRadar>().objList;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
