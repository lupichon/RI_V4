using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ce script permet la creation de la ceinture d'astéroïde

public class InstanciationAsteroide : MonoBehaviour
{
    // Start is called before the first frame update
    private int _nombreAsteroides = 40;                         //nombre de point autour de saturne où seront instanciés les astéroïdes
    private Transform _transformSaturne;
    public GameObject Asteroide1, Asteroide2, Asteroide3;
    private Vector3 Pos;                                        //position des points instanciateurs
    private int aleatoireX, aleatoireY, aleatoireZ;
    public Material gold, iron, charcoal;
   
    void Start()
    {
        _transformSaturne = GetComponent<Transform>();      
        Anneau();
    }

    void genereAlea()       //fonction qui génère aléatoirement 3 nombres proche de la position d'un point
    {
        aleatoireX = Random.Range((int)Pos[0] - 3, (int)Pos[0] + 3);    
        aleatoireY = Random.Range((int)Pos[1] - 3, (int)Pos[1] + 3);
        aleatoireZ = Random.Range((int)Pos[2] - 3, (int)Pos[2] + 3);

        Pos[0] = aleatoireX;
        Pos[1] = aleatoireY;
        Pos[2] = aleatoireZ;
    }

    void Instanciation(GameObject Ast)          //fonction qui instancie les astéroïdes
    {
        genereAlea();                                                                       //calcul de la position aléatoire
        GameObject asteroid =Instantiate(Ast, Pos, Quaternion.identity) ;                   //instanciation de l'astéroïde
        GameObject Child = asteroid.transform.GetChild(0).gameObject;

        float randomFloat = Random.value;                                                   //generation d'un nombre aléatoire qui permet de déterminer la nature de l'astéroïde
        if (randomFloat < 0.05)       //or, le plus rare                                                      
        {
            Child.transform.GetChild(0).GetComponent<MeshRenderer>().material = gold;
            Child.transform.GetChild(1).GetComponent<MeshRenderer>().material = gold;
            Child.transform.GetChild(2).GetComponent<MeshRenderer>().material = gold;

            Child.transform.GetChild(0).tag = "gold";
            Child.transform.GetChild(1).tag = "gold";
            Child.transform.GetChild(2).tag = "gold";


        }
        else
        {
            if (randomFloat>=0.05 && randomFloat<0.2)    //fer
            {
                Child.transform.GetChild(0).GetComponent<MeshRenderer>().material = iron;
                Child.transform.GetChild(1).GetComponent<MeshRenderer>().material = iron;
                Child.transform.GetChild(2).GetComponent<MeshRenderer>().material = iron; ;
                Child.transform.GetChild(0).tag = "iron";
                Child.transform.GetChild(1).tag = "iron";
                Child.transform.GetChild(2).tag = "iron";
            }
            else if(randomFloat >= 0.2 && randomFloat < 0.4)    //charbon
            {
                Child.transform.GetChild(0).GetComponent<MeshRenderer>().material = charcoal;
                Child.transform.GetChild(1).GetComponent<MeshRenderer>().material = charcoal;
                Child.transform.GetChild(2).GetComponent<MeshRenderer>().material = charcoal;
                Child.transform.GetChild(0).tag = "charcoal"; 
                Child.transform.GetChild(1).tag = "charcoal"; 
                Child.transform.GetChild(2).tag = "charcoal";
            }
        }
        //l'astéroïde peut aussi rester comme il était de base
    }


    void Anneau()  //Fonction qui instancie la ceinture d'astéroïdes
    {
       
        float rayon = 60;                                       //angle permettant de tracer le cercle autour de Saturne 
        float angle = 0;
        for (int j = 0; j < 2; j++)                             //on fait le tour de la planète deux fois en modifiant le rayon d'une fois à l'autre pour augmenter l'épaisseur de la ceinture
        {
            for (int i = 0; i < _nombreAsteroides; i++)     
            {
                Pos = _transformSaturne.position;               //recuperation du centre de Saturne
                Pos[0] = Pos[0] + rayon * Mathf.Cos(angle);     //calcul des positions X, Y et Z (Y ne varie pas car on reste dans un plan)
                Pos[2] = Pos[2] + rayon * Mathf.Sin(angle);
                Instanciation(Asteroide1);
                Instanciation(Asteroide2);
                Instanciation(Asteroide3);
                angle = angle + (2 * Mathf.PI) / _nombreAsteroides;     //mise à jour de l'angle
            }
            rayon = rayon + 5;
        }
    }
}


