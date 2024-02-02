using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Menu_Game : MonoBehaviour
{
    public BossBehavior _boss;
    string cheminFichier = Application.dataPath + "/Scores.txt";
    public Caract�ristiques _caract�ristiques;
    void Update()
    {
        if(_boss.isDead || PlayerHpBar._playerHealth == 0)
        {
            int[] tableauEntiers = new int[3];
            string[] lignesFichier = File.ReadAllLines(cheminFichier);

            foreach (string ligne in lignesFichier)
            {
                string[] valeurs = ligne.Split(' ');
                for (int i = 0; i < valeurs.Length; i++)
                {
                    if (int.TryParse(valeurs[i], out int entier))
                    {
                        tableauEntiers[i] = entier;
                    }
                }
            }
            int k = 0;
            while(k<3 && _caract�ristiques._argentGagn�e < tableauEntiers[k])
            {
                k++;
            }
            if(k!=3)
            {
                tableauEntiers[k] = _caract�ristiques._argentGagn�e;
                Debug.Log(k);
            }
            Array.Sort(tableauEntiers);
            Array.Reverse(tableauEntiers);

            EcrireTexteDansFichier(cheminFichier, tableauEntiers);
            SceneManager.LoadScene("Menu");
        }
    }
    void EcrireTexteDansFichier(string chemin, int[] tableau)
    {
        // Utiliser StreamWriter pour �crire dans le fichier (avec append: false pour �craser le contenu)
        using (StreamWriter writer = new StreamWriter(chemin, false))
        {
            // �crire chaque valeur du tableau sur une nouvelle ligne
            for (int i = 0; i < tableau.Length; i++)
            {
                writer.WriteLine(tableau[i]);
                Debug.Log(i);
            }
        }
    }
}



