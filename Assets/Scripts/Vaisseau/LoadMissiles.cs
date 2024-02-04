using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class LoadMissiles : MonoBehaviour
{
    // On definit l'orientation de la torpille une fois placee dans le chargeur
    private Quaternion q;

    void Start()
    {
        // Voici l'orientation
        q.eulerAngles = new Vector3(0, 90, 0);

    }

    void Update()
    {
        // Il n'y a rien ici
    }

    // Si la torpille est mise au niveau du chargeur, elle est donc chargee et deplacee comme enfant du chargeur et placee a sa position de tir et orientee comme il faut
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Torpille"))
        {
            // Debug.Log("Dans torpille");
            other.transform.SetParent(GameObject.Find("Chargeur").GetComponent<Transform>());
            other.transform.localPosition = new Vector3(10f, 10f, 10f);
            other.transform.localRotation = q;
        }
    }
}
