using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Laser : MonoBehaviour
{
    private float _distanceParcourue;
    private float _fireSpeed = 20;
    private Transform _spawn;
    private bool _contact = false;
    public Alien _alienici;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        while(_distanceParcourue < 20f && _contact)
        {
            GetComponent<Transform>().Translate(Vector3.right * Time.deltaTime);
        }
        if(_distanceParcourue>=20)
        {
            Destroy(this);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "player")
        {
            _contact = true;
            Destroy(this);
        }

    }
}
