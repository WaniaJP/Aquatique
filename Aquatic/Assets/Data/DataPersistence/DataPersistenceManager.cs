using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("Debugging")]
    [SerializeField] private bool initializeDataIfNull = false;

    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] private bool useEncryption;

    private GameData gameData;
    public List<IDataPersistence> dataPersistenceObjects = new List<IDataPersistence>();
    private FileDataHandler dataHandler;

    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one Data Persistence Manager in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        Debug.Log("DataPersistanceManager called AWAKE, gameData != null : " + (gameData != null));
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);

        Debug.Log("DataPersistenceManager called Start, Start called FindAllDataPersistenceObjects");
    }

    /*private void OnEnable()
    {
        Debug.Log("DataPersistanceManager called ONENABLE, gameData != null : " + (gameData != null));
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        Debug.Log("DataPersistanceManager called ONDISABLE, gameData != null : " + (gameData != null));
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }*/

    /*public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("DataPersistanceManager called ONSCENELOADED, gameData != null : " + (gameData != null));
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }*/

    public void OnLevelWasLoaded()
    {
        Player player = FindObjectOfType<Player>();
        
        if (player != null)
        {
            player.SaveData(gameData);
        }
    }
        public void NewGame()
    {
        Debug.Log("DataPersistanceManager called NEWGAME, gameData != null : " + (gameData != null));
        this.gameData = new GameData();
        SaveGame();
    }

    public void LoadGame()
    {
        Debug.Log("DataPersistanceManager called LOADGAME, before dataHandler.load, gameData != null : " + (gameData != null));

        // load any saved data from a file using the data handler
        this.gameData = dataHandler.Load();

        Debug.Log("DataPersistanceManager called LOADGAME, after dataHandler.load, gameData != null : " + (gameData != null));
        if (gameData != null)
        {
            Debug.Log("DataPersistanceManager called LOADGAME, after dataHandler.load, gameData.playerPosition : " + gameData.playerPosition.ToString());
        }

        // start a new game if the data is null and we're configured to initialize data for debugging purposes
        if (this.gameData == null && initializeDataIfNull)
        {
            NewGame();
        }

        // if no data can be loaded, don't continue
        if (this.gameData == null)
        {
            Debug.Log("No data was found. A New Game needs to be started before data can be loaded.");
            return;
        }

        //SceneManager.LoadSceneAsync(GetSavedSceneName());

        // push the loaded data to all other scripts that need it
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            Debug.Log("datapersistence loading : " + dataPersistenceObj.ToString());
            dataPersistenceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        Debug.Log("DataPersistanceManager called SAVEGAME, gameData != null : " + (gameData != null));
        if(gameData != null)
        {
        Debug.Log("DataPersistanceManager called SAVEGAME, gameData.playerPosition : " + gameData.playerPosition.ToString());
        }

        // if we don't have any data to save, log a warning here
        if (this.gameData == null)
        {
            Debug.LogWarning("No data was found. A New Game needs to be started before data can be saved.");
            //return;
            NewGame();
        }
        dataPersistenceObjects = FindAllDataPersistenceObjects();
        Debug.Log("DataPersistenceManager called SAVEGAME, Count of dataPersistenceObjects : " + dataPersistenceObjects.Count());
        // pass the data to other scripts so they can update it
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            Debug.Log("datapersistence saving : " + dataPersistenceObj.ToString());
            dataPersistenceObj.SaveData(gameData);
        }
        Debug.Log("DataPersistenceManager called SAVEGAME, gameData.PlayerPosition : " + gameData.playerPosition.ToString());

        Scene scene = SceneManager.GetActiveScene();
        // DON'T save this for certain scenes, like our main menu scene
        if (!scene.name.Equals("Main Menu"))
        {
            gameData.currentSceneName = scene.name;
        }

        // save that data to a file using the data handler
        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        Debug.Log("DataPersistanceManager called ONAPPLICATIONQUIT, gameData != null : " + (gameData != null));
        SaveGame();
    }

    public List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();
        Debug.Log("FINDING DATAPERSISTENCEOBJECTS");
        Debug.Log("DataPersistanceManager, FindAllDataPersistenceObjects triggered, number of dataPersistenceObjects : " + dataPersistenceObjects.Count());

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public bool HasGameData()
    {
        Debug.Log("DataPersistanceManager called HASGAMEDATA, gameData != null : " + (gameData != null));
        return gameData != null;
    }

    public string GetSavedSceneName()
    {
        // error out and return null if we don't have any game data yet
        if (gameData == null)
        {
            Debug.LogError("Tried to get scene name but data was null.");
            return null;
        }

        // otherwise, return that value from our data
        return gameData.currentSceneName;
    }

    public void Update()
    {
        if(Input.GetKeyUp(KeyCode.H))
        {
            SaveGame();
        }
        if(Input.GetKeyUp(KeyCode.J))
        {
            LoadGame();
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            SceneManager.LoadSceneAsync("Enchanteresse haut");
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            SceneManager.LoadSceneAsync("Enchanteresse_Right");
        }
    }
}