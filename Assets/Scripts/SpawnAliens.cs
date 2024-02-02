using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAliens : MonoBehaviour
{
    private bool _estEnCombat = false;
    private int _nbAliens = 1;
    public GameObject _alien;
    public GameObject _spawnPointAlien;

    public AudioClip AlerteAlien;
    public AudioSource XR;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!_estEnCombat)
        {

            for(int i = 0;i <_nbAliens;i++)
            {
                Instantiate(_alien, _spawnPointAlien.transform.position,Quaternion.identity);
                XR.PlayOneShot(AlerteAlien);
                

            }
            _estEnCombat = true;
        }
          /*
        if (!GameObject.Find("_alien"))
        {
            _estEnCombat = false;
        }
          */
    }
}
