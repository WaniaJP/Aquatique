using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector3 playerPosition;
    public SerializableDictionnary<string, bool> objectActive;

    //Position du joueur lorsqu'une nouvelle partie est lancée
    public GameData()
    {
        playerPosition = Vector3.zero;
        objectActive = new SerializableDictionnary<string, bool>();
    }

}
