using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class LoadMissiles : MonoBehaviour
{
    private Quaternion q;
    // Start is called before the first frame update
    void Start()
    {
        q.eulerAngles = new Vector3(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Torpille"))
        {
            other.transform.SetParent(GameObject.Find("Chargeur").GetComponent<Transform>());
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.localPosition = new Vector3(3.5f, -1.35f, 0f);
            other.transform.localRotation = q;
        }
    }
}
