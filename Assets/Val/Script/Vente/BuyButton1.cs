using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BuyButton1 : MonoBehaviour
{
    public TextMeshProUGUI _textCommerce;
    public TextMeshProUGUI _textMinage;
    public TextMeshProUGUI _textPrixAchat;

    public CommerceLVL comLVL;
    public MinageLVL minLVL;

    private int _prixAchat;

    public Caractéristiques carac;

    // Start is called before the first frame update
    void Start()
    {
       GetComponent<Button>().onClick.AddListener(SellButtonClicked);


    }

    // Update is called once per frame
    void Update()
    {
        _textCommerce.text = "Commerce : " + carac._niveauCommerce + " (+" + comLVL._compteur + ")";
        _textMinage.text = "Minage : "+ carac._niveauMinage + " (+"+ minLVL._compteur+")";
        _prixAchat = carac._prixLVLMinage * minLVL._compteur + carac._prixLVLCommerce * comLVL._compteur;//(prix amélioration pour un lvl de minage*le nombre de LVL + prix amélioration pour un lvl de commerce * le nombre de LVL)
        _textPrixAchat.text = "Prix : "+_prixAchat +" $";


    }
    public void SellButtonClicked()
    {

        if (carac._monnaie >= 0 )//"prix d'achat")
        {
            carac._monnaie -= _prixAchat;
            carac._niveauCommerce += comLVL._compteur; 
            carac._niveauMinage += minLVL._compteur;
            carac.prixUnit = carac.prixUnit * carac._niveauCommerce;
        }

        // Mettez � jour le texte du score
        // scoreText.Text.text = minage._score + "/150";
        

    }
}

