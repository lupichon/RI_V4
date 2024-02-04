using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FigthInfo : MonoBehaviour
{
    TextMeshPro Text;
    [SerializeField] instanciateur inst;
    // Start is called before the first frame update
    void Start()
    {
        Text = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!inst.FightStarted) Text.text = "Combat Pas commencé";
        else
        {

            if (!inst.isFightEnded)
            {
                Text.text = "vague #" + inst.getWaveNumber().ToString() + "/" + inst.getTotalWave().ToString();
            }
            else
            {

                Text.text = "Vagues anéanties \n c'est l'heure de \nla TORPILLE !!!";
            }
        }
    }
}
