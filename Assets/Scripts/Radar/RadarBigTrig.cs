using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarBigTrig : MonoBehaviour
{

    public List<GameObject> objListe;
    public List<GameObject> listeOut;
    public List<GameObject> listeIn;


    // Start is called before the first frame update
    void Start()
    {
        objListe = GameObject.Find("Radar").GetComponent<_detectionRadar>().objList;
        listeOut = GameObject.Find("noCol").GetComponent<RadarSmallTrig>().listeOut;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject obj in listeIn) 
        {
            bool test = true;
            foreach(GameObject obj2 in listeOut)
            {
                if (GameObject.ReferenceEquals(obj, obj2))
                {
                    test = false;
                }
            }
            if(test)
            {
                bool t2 = true;
                foreach(GameObject obj3 in objListe)
                {
                    if (GameObject.ReferenceEquals(obj, obj3))
                    {
                        t2 = false;
                    }
                }
                if (t2)
                {
                    objListe.Add(obj);
                   // Debug.Log(obj + " rentre dans le radar");
                }
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        bool test = true;

        foreach (GameObject obj in listeIn) 
        {
            if (GameObject.ReferenceEquals(obj, other.gameObject))
            {
                test = false;
            }
        }
        if (test)
        {
            listeIn.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        objListe.Remove(other.gameObject);
        listeIn.Remove(other.gameObject);
       // Debug.Log(other.gameObject + "sort du radar");
    }
}
