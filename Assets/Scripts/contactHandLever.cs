using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contactHandLever : MonoBehaviour
{

    private GameObject Hand;
    public bool contact;

    // Start is called before the first frame update
    void Start()
    {
        Hand = GameObject.Find("Right Controller");
        contact = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)

    {
        if(other.name == Hand.GetComponent<Collider>().name)
        {
            contact = true;
            Debug.Log("RHIUJSPOIEFSUP");
        }      
            Debug.Log("RHIUJSPOIEFSUP");
        
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.name == Hand.GetComponent<Collider>().name)
        {
            contact = false;
        }
    }
}
