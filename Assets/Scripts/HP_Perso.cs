using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Perso : MonoBehaviour
{
    public int _hpPerso;
    // Start is called before the first frame update
    void Start()
    {
        _hpPerso = 100;
        
    }

    // Update is called once per frame
    void Update()
    {   

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("munitionsennemi"))
        {

        }
    }

}
