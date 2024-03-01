using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SaveData : MonoBehaviour
{

    public static BD bd;
    public static void SaveToJson()
    {

        string inventoryData = JsonUtility.ToJson(bd);
        Debug.LogWarning(inventoryData);
        string filePath = Application.persistentDataPath + "/Facts.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, inventoryData);
        Debug.Log("Sauvegarde effectuée");

    }

    public static void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/Facts.json";

        try
        {
            string inventoryData = System.IO.File.ReadAllText(filePath);
            bd = JsonUtility.FromJson<BD>(inventoryData);
            Debug.Log("Chargement réussi");
        }
        catch (System.IO.FileNotFoundException)
        {
            // File not found, create a new database
            bd = new BD();
            Debug.LogWarning("Fichier non trouvé. Une nouvelle base de données a été créée.");
            SaveToJson(); // Save the newly created database to the file
        }
        catch (Exception e)
        {
            // Handle other exceptions
            Debug.LogError("Erreur de chargement : " + e.Message);
        }
    }

    void Update()
    {
    }
}


[Serializable]
public class BD
{
    public Fact[] factMap;
    public ModificationFact[] factMapMod;

    public DialogueFact[] dialogueFacts;
    public CriteriaFact[] criteriaFacts;

}