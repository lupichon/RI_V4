using UnityEngine;

public class OpenCloseDoor : MonoBehaviour
{
    // Animator de la porte a activer ou desactiver
    public Animator doorAnimator;

    // Son de la porte a jouer
    public AudioClip audioPorte;
    public AudioSource Porte_AudioSource;

    // Quand le joueur ou un alien entre dans le collider de la porte, le son est joue est l'animation declenchee
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnimator.SetBool("character_nearby", true);
            Porte_AudioSource.PlayOneShot(audioPorte);
        }
        if (other.CompareTag("Alien"))
        {

            doorAnimator.SetBool("character_nearby", true);
            //Porte_AudioSource.PlayOneShot(audioPorte);
        }
    }

    // Quand le joueur ou un alien quitte le collider, on joue le son et la porte se ferme
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Alien"))
        {
            doorAnimator.SetBool("character_nearby", false);
            Porte_AudioSource.PlayOneShot(audioPorte);
        }
    }
    
    void Update()
    {
        // Rien ici
    }
}