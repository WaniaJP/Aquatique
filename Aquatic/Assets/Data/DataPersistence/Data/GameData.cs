using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector3 playerPosition;
    public SerializableDictionnary<string, int> objectPossessed;

    //Position du joueur lorsqu'une nouvelle partie est lanc�e
    public GameData()
    {
        playerPosition = Vector3.zero;
        objectPossessed = new SerializableDictionnary<string, int>();
    }

}
