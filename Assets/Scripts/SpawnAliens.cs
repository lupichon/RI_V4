using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAliens : MonoBehaviour
{
    private bool _estEnCombat = false;
    private int _nbAliens = 3;
    public GameObject _alien;
    public GameObject _spawnPointAlien;

    public AudioClip AlerteAlien;
    public AudioSource XR;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void spawnAlien()
    {
        for(int i =0; i< _nbAliens; i++) Instantiate(_alien, _spawnPointAlien.transform.position, Quaternion.identity);
        XR.PlayOneShot(AlerteAlien);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
