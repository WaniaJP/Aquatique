using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.PlayerSettings;

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
        string inventoryData = System.IO.File.ReadAllText(filePath);

        bd = JsonUtility.FromJson<BD>(inventoryData);
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