using UnityEngine;

public class OpenCloseDoor : MonoBehaviour
{
    public Animator doorAnimator;
    public AudioClip audioPorte;
    public AudioSource Porte_AudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("bbbb");
            doorAnimator.SetBool("character_nearby", true);
            //la porte s'ouvre

            Porte_AudioSource.PlayOneShot(audioPorte);
        }
        if (other.CompareTag("Alien"))
        {
            Debug.Log("bbbb");
            doorAnimator.SetBool("character_nearby", true);
            //la porte s'ouvre

            Porte_AudioSource.PlayOneShot(audioPorte);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Alien"))

        {

            Debug.Log("aaaa");
            doorAnimator.SetBool("character_nearby", false);
            Porte_AudioSource.PlayOneShot(audioPorte);
        }
    }
     void Update()
    {
        
    }
}