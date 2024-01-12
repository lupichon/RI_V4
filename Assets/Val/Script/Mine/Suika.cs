using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suika : MonoBehaviour
{

    public GameObject prefabToSpawn; // Le prefab que vous souhaitez instancier
    public Transform  pointOfSpawn;   // Le point de spawn o� vous souhaitez instancier le prefab
    public Transform  parentObject;   // L'objet existant auquel vous souhaitez attacher le nouveau prefab
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPrefabAtPoint();
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnPrefabAtPoint()
    {
        // V�rifiez si le prefab et le point de spawn sont d�finis
        if (prefabToSpawn != null && pointOfSpawn != null)
        {
            // Instancier le prefab au point de spawn
            GameObject newPrefabInstance = Instantiate(prefabToSpawn, pointOfSpawn.position, pointOfSpawn.rotation);

            // V�rifiez si l'objet parent est d�fini
            if (parentObject != null)
            {
                // Rendre le nouvel objet instanci� enfant de l'objet parent
                newPrefabInstance.transform.parent = parentObject;
            }
            //newPrefabInstance.tag = "BalleBleu";
        }
        else
        {
            Debug.LogError("Prefab ou point de spawn non d�fini !");
        }
    }
}
