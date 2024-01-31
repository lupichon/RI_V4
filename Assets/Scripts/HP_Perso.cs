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

    public Material MaterialGreen;
    public Material MaterialYellow;
    public Material MaterialRed;

    public SkinnedMeshRenderer tamere;
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
        

        
            // Changez le mat�riau
            //renderer.material = newMaterial;
            if (_hpPerso > 50)
            {
                //main en vert
                tamere.material = MaterialGreen;
                Debug.Log("ahhhhhhhh");
            }
            if (_hpPerso < 50 && _hpPerso > 30)
            {
                //main orange
                Debug.Log("ahhhhhhhh1");

                tamere.material = MaterialYellow;

            }
            if (_hpPerso < 30)
            {
                //main rouge
                Debug.Log("ahhhhhhh2");

                tamere.material= MaterialRed;


           }
      
        

    }
    void Mort()
    {
        if (_hpPerso == 0)
        {
            car._monnaie = 0;
            player.transform.position = _respawn.transform.position;
            player.transform.rotation = _respawn.transform.rotation;
            _hpPerso = 100;




        }

    }

}
