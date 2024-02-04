using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Vente : MonoBehaviour
{
    public Scrollbar sellScrollbar;
    public TextMeshProUGUI sellQuantityText;
    public Minage minage;
    public int sellQuantity;
    // Start is called before the first frame update
    void Start()
    {
        sellScrollbar.onValueChanged.AddListener(UpdateSellQuantity);
        sellQuantityText.text = "Quantit� de vente : 0 ";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateSellQuantity(float value)
    {
        sellQuantity = Mathf.RoundToInt(value *minage._score); // maxSellQuantity est la quantit� maximale que le joueur peut vendre
        sellQuantityText.text = "Quantit� de vente : " + sellQuantity;

        
    }
}
