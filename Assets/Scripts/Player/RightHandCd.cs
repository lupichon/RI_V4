using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RightHandCdBar : MonoBehaviour
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
        _leftHandCdBar.size = RightRayCastShooter._shootTimer / RightRayCastShooter._shootCooldown; 
    }
}
