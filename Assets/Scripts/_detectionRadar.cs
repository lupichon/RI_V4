using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _detectionRadar : MonoBehaviour
{
    public List<GameObject> objList;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach(var i in objList)
        {
            Debug.Log(i + "est dans le radar !\n");
        }

    }



}
