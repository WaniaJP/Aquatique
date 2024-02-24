using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector3 playerPosition;
    public List<int> objectPossessedId;
    public string currentSceneName;

    //Position du joueur lorsqu'une nouvelle partie est lancée
    public GameData()
    {
        playerPosition = Vector3.zero;
        objectPossessedId = new List<int>();
        currentSceneName = "";
    }

}
