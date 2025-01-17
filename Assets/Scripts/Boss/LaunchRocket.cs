using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchRocket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening("PushButtonRocketPressed", PushBoutonPressed);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PushBoutonPressed(EventParam e)
    {
        //on regarde si il y a un fils (rocket) dans le launcher
        //si c'est pas le cas on envoie un text qui le dit
        //sinon on tire le missile !
        

    }

}
