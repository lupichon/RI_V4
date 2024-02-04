using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LeftHandCdBar : MonoBehaviour
{
    Scrollbar _leftHandCdBar;
    // Start is called before the first frame update
    void Start()
    {
        _leftHandCdBar = GetComponent<Scrollbar>();
    }

    // Update is called once per frame
    void Update()
    {
        _leftHandCdBar.size = LeftRayCastShooter._shootTimer / LeftRayCastShooter._shootCooldown; 
    }
}
