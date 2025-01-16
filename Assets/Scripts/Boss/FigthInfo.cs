
/*
    Ce script récupère les informations de combat pour les affichés dans l'ui 
*/
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
        EventManager.StartListening("EndBossWave",null);
        Text = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        //On affiche l'état du combat dans un TextMeshPro
        if (!inst.FightStarted)
        {
            Text.text = "Combat Pas commenc�";
        }
       
    }
}
