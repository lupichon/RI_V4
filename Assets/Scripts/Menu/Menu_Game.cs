using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

//ce script permet la transition entre la fin de la partie et le menu du jeu 

public class Menu_Game : MonoBehaviour
{
    public BossBehavior _boss;
    string cheminFichier = Application.dataPath + "/Scores.txt";
    public Caractéristiques _caractéristiques;
    void Update()
    {
        if(_boss.isDead || PlayerHpBar._playerHealth == 0)                  //si le boss meurt ou que le vaisseau est détruit alors la partie est finie
        {
            int[] tableauEntiers = new int[3];
            string[] lignesFichier = File.ReadAllLines(cheminFichier);      //lecture des lignes de score dans le fichier des parties précédentes

            foreach (string ligne in lignesFichier)
            {
                string[] valeurs = ligne.Split(' ');
                for (int i = 0; i < valeurs.Length; i++)
                {
                    if (int.TryParse(valeurs[i], out int entier))
                    {
                        tableauEntiers[i] = entier;                         //on recupere ces valeurs
                    }
                }
            }
            int k = 0;
            while(k<3 && _caractéristiques._argentGagnée < tableauEntiers[k])   //on cherche la place du score dans le tableau
            {
                k++;
            }
            if(k!=3)                                                                //le score obtenue par le joueur est supérieur aux trois meilleurs scores
            {
                tableauEntiers[k] = _caractéristiques._argentGagnée;                //mise à jour du tableau
                Debug.Log(k);
            }
            Array.Sort(tableauEntiers);
            Array.Reverse(tableauEntiers);

            EcrireTexteDansFichier(cheminFichier, tableauEntiers);                    //ecriture dans le fichier texte
            SceneManager.LoadScene("Menu");                                           //on charge le menu  
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



