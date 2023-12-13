using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static string playerPath = Application.persistentDataPath + "/player.save";
    private static string objectMedusePath = Application.persistentDataPath + "/objectMeduse.save";

    public static void SavePlayer (Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(playerPath, FileMode.Create);

        PlayerDataSave dataSave = new PlayerDataSave(player);

        formatter.Serialize(stream, dataSave);
        stream.Close();
    }

    /*public static void SaveObjectMeduse(ObjectMeduse objectMeduse)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(objectMedusePath, FileMode.Create);

        ObjectMeduseDataSave dataSave = new ObjectMeduseDataSave(objectMeduse);

        formatter.Serialize(stream, dataSave);
        stream.Close();
    }*/


    public static PlayerDataSave LoadPlayer() 
    {
        if(File.Exists(playerPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(playerPath, FileMode.Open);

            PlayerDataSave dataSave = formatter.Deserialize(stream) as PlayerDataSave;
            stream.Close();

            return dataSave;
        }
        else
        {
            Debug.LogError("Aucun fichier de sauvegarde dans " + playerPath);
            return null;
        }
    }

    /*public static ObjectMeduseDataSave LoadObjectMeduse()
    {
        if (File.Exists(objectMedusePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(objectMedusePath, FileMode.Open);

            ObjectMeduseDataSave dataSave = formatter.Deserialize(stream) as ObjectMeduseDataSave;
            stream.Close();

            return dataSave;
        }
        else
        {
            Debug.LogError("Aucun fichier de sauvegarde dans " + objectMedusePath);
            return null;
        }
    }*/

}