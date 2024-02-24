using System;
using System.IO;
using UnityEngine;

public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";
    private bool useEncryption = false;
    private string encryptionCodeWord = "catalyseur";

    public FileDataHandler(string dataDirPath, string dataFileName, bool useEncryption)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
        this.useEncryption = useEncryption;
    }

    public GameData Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;
        if(File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";

                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                if(useEncryption)
                {
                    dataToLoad = EncryptDecrypt(dataToLoad);
                }
                //Deserialization de Json a C#
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
                Debug.Log("FileDataHandler : Load triggered, receiving data (loadedData.playerPosition) :  " + loadedData.playerPosition);
            }
            catch (Exception e)
            {
                Debug.LogError("Erreur survenue lors du chargement de donn�e du fichier " + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }

    public void Save(GameData data)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        Debug.Log("FileDataHandler : Save triggered, receiving data (data.playerPosition) :  " + data.playerPosition);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonUtility.ToJson(data, true);

            if(useEncryption)
            {
                dataToStore = EncryptDecrypt(dataToStore);
            }

            using(FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
            Debug.Log("FileDataHandler : Save triggered2, receiving data (data.playerPosition) :  " + dataToStore);
        }
        catch(Exception e)
        {
            Debug.LogError("Erreur survenue lors de la sauvegarde de donn�e dans le fichier " + fullPath + "\n" + e);
        }
    }

    private string EncryptDecrypt(string data)
    {
        string modifiedData = "";
        for(int i = 0; i < data.Length; i++) 
        { 
            modifiedData += (char) (data[i] ^ encryptionCodeWord[i % encryptionCodeWord.Length]);
        }
        return modifiedData;
    }
}
