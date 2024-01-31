using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Perso : MonoBehaviour
{
    public int _hpPerso;
    public Alien alien;
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
            _hpPerso = _hpPerso - alien.degats;
            Destroy(collision.gameObject);

            


        }
    }

    void FadingHealth()
    {

    }
    void Mort()
    {

    }

}
