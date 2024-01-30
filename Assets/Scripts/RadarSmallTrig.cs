using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarSmallTrig : MonoBehaviour
{
    public List<GameObject> listeOut;

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
        listeOut.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        listeOut.Remove(other.gameObject);
        Debug.Log(other.gameObject + "sort du radar");
    }
}
