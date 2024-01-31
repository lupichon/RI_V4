using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Perso : MonoBehaviour
{
    public int _hpPerso;
    public Alien alien;
    public GameObject _mainGauche;
    public Caractéristiques car;
    public GameObject _respawn;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        _hpPerso = 100;
        
    }

    // Update is called once per frame
    void Update()
    {
        HandHealth();
            Mort();

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("munitionsennemi"))
        {
            _hpPerso = _hpPerso - alien.degats;
            Destroy(collision.gameObject);

            


        }
    }

    void HandHealth()
    {
        if (_hpPerso > 50)
        {
            //main en vert
            _mainGauche.GetComponent<Material>().SetColor("_Color",Color.green);
        }
        if (50>_hpPerso&& _hpPerso>30)
        {
            //main orange
            _mainGauche.GetComponent<Material>().SetColor("_Color", Color.yellow);

        }
        if (_hpPerso<30)
        {
            //main rouge
            _mainGauche.GetComponent<Material>().SetColor("_Color", Color.red);


        }

    }
    void Mort()
    {
        if (_hpPerso == 0)
        {
            car._monnaie = 0;
            player.transform.position = _respawn.transform.position;
            player.transform.rotation = _respawn.transform.rotation;




        }

    }

}
