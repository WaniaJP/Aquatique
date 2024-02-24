using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Menu Buttons")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueGameButton;
    [SerializeField] private Button coinButton;

    private void Start()
    {
        Debug.Log("MainMenu called Start, Start called FindAllDataPersistenceObjects");
        DataPersistenceManager.instance.dataPersistenceObjects = DataPersistenceManager.instance.FindAllDataPersistenceObjects();
        
        DataPersistenceManager.instance.LoadGame();

        Debug.Log("MainMenu called Start, HASGAMEDATA FROM DataPersistanceManager : " + DataPersistenceManager.instance.HasGameData());
        if(!DataPersistenceManager.instance.HasGameData())
        {
            continueGameButton.interactable = false;
        }
    }

    public void OnNewGameClicked()
    {
        DisableMenuButtons();

        // create a new game - which will initialize our game data
        DataPersistenceManager.instance.NewGame();
        Debug.Log("NEWGAME CLICKED ON MAIN MENU");
        // Load the gameplay scene - which will in turn save the game because of
        // OnSceneUnLoaded() in the DataPersistenceManager
        SceneManager.LoadSceneAsync("Enchanteresse");
    }
    public void OnContinueGameClicked()
    {
        DisableMenuButtons();

        Debug.Log("MainMenu Script, clicking on the continu button");

        Debug.Log("MainMenu Script, SaveGame Triggered");
        DataPersistenceManager.instance.SaveGame();
        DataPersistenceManager.instance.LoadGame();

        // Load the next scene - which will in turn Load the game because of
        // OnSceneLoaded() in the DataPersistenceManager
        SceneManager.LoadSceneAsync("Enchanteresse");
    }

    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        continueGameButton.interactable = false;
    }
}
