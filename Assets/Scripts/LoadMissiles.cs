using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class LoadMissiles : MonoBehaviour
{
    private Quaternion q;
    //ivate ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        q.eulerAngles = new Vector3(0, 90, 0);

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Torpille"))
        {
            Debug.Log("Dans torpille");
            other.transform.SetParent(GameObject.Find("Chargeur").GetComponent<Transform>());

            //other.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.localPosition = new Vector3(10f, 10f, 10f);
            other.transform.localRotation = q;
        }
    }
}
