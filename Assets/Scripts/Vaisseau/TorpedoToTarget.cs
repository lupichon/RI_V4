using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoToTarget : MonoBehaviour
{
    // Transforms de la torpille et de la cible (le boss)
    private Transform torpedo;
    private Transform target;

    // Vitesse de la torpille
    public float speed;

    // Autorisation de tir
    private bool shoot;

    // Fonction appelee lorsque le bouton est presse
    public void isShooting()
    {
        // Debug.Log("is shooting");
        shoot = true;
    }

    // On cherche le boss
    void Start()
    {
        target = GameObject.Find("targetboss").transform;
        shoot = false;
    }

    void Update()
    {
        // Si la torpille est chargee et que le tir est autorise, alors on definit attribue le transform de la torpille et on tire
        if (GameObject.Find("Chargeur").transform.childCount > 0 && shoot == false)
        {
            torpedo = GameObject.Find("Chargeur").transform.GetChild(0);
        }

        if (GameObject.Find("Chargeur").transform.childCount > 0 && shoot == true)
        {   
            // On desactive la gravite sur la torpille
            torpedo.GetComponent<Rigidbody>().useGravity = false;

            // La torpille va vers la cible (le boss)
            torpedo.position = Vector3.MoveTowards(torpedo.position, target.position, speed * Time.deltaTime);

            // La torpille regarde vers le boss
            torpedo.LookAt(target);

            // Quand la torpille arrive au boss, on remet le boolean shoot a l'etat initial
            if (Mathf.Abs(torpedo.position.magnitude - target.position.magnitude) < 0.1)
            {
                shoot = false;
            }
        }
    }
}
