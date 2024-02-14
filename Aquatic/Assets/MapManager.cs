using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject prefab; // Prefab à instancier
    public MapItem[] MapItems; // Tableau pour stocker les MapItems

    private static MapManager instance; // Instance unique de MapManager

    // Méthode pour obtenir l'instance unique de MapManager
    public static MapManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            MapItems = Resources.LoadAll<MapItem>(""); // Charger tous les MapItems
            SpawnMapObjects();
        }
    }

    public void SpawnMapObjects()
    {
        // Itérer sur tous les MapItems
        foreach (MapItem mapItem in MapItems)
        {
            // Instancier le prefab avec l'objet actuel comme parent
            GameObject newMapItemObject = Instantiate(prefab, transform);

            // Obtenir une référence au script MapItem de l'objet instancié
            MapObject mapItemScript = newMapItemObject.GetComponent<MapObject>();

            if (mapItemScript != null)
            {
                // Attribuer le MapItem actuel à l'objet instancié
                mapItemScript.map = mapItem;
            }
            else
            {
                Debug.LogError("Le prefab ne contient pas le script MapObject.");
            }
        }
    }
}
