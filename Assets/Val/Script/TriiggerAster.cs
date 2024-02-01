using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriiggerAster : MonoBehaviour
{
    public Minage Minage;

    public AudioClip Audio;
    public AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        {
            if (other != null)
            {
                if (other.CompareTag("AsterOR"))
                {
                    Minage._score += 1 ;

                    AudioSource.PlayOneShot(Audio);
                    Debug.Log("ahhhhhhhh");


                    Destroy(other.gameObject);
                    //Debug.Log("Destruction aster or");
                }
            }
        }
    }


}
