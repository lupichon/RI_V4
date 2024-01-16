using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoToTarget : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform torpedo;
    private Transform target;
    public float speed;
    private bool shoot;
    void Start()
    {
        target = GameObject.Find("Saturne").transform;
        shoot = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Chargeur").transform.childCount > 1 && shoot == false)
        {
            torpedo = GameObject.Find("Chargeur").transform.GetChild(1);
            torpedo.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            torpedo.position = new Vector3(0, 0, 0);
            shoot = true;
        }

        if (shoot == true)
        {
            torpedo.position = Vector3.MoveTowards(torpedo.position, target.position, speed * Time.deltaTime);
            torpedo.LookAt(target);
        }
    }
}