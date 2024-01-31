using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAliens : MonoBehaviour
{
    private bool _estEnCombat = false;
    private int _nbAliens = 4;
    public GameObject _alien; 
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
                Instantiate(_alien, new Vector3(3.959f, -0.7f, 4.518f),Quaternion.identity);
            }
            _estEnCombat = true;
        }
    }
}
