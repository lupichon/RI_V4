using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangementArme : MonoBehaviour
{
    public GameObject spawnpoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SCI-FI"))
        {
            other.transform.position = spawnpoint.transform.position;
            other.transform.rotation = spawnpoint.transform.rotation;
        }
    }
}
