using Cinemachine;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public GameObject playerObject;
    public static SceneLoader _instance;
    private string lastTrigger;

    private void Awake()
    {
        if (_instance != null)
            Destroy(gameObject);
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void OnEnteredExitTrigger(string triggerName, string levelToLoad)
    {
       lastTrigger = triggerName;
       Application.LoadLevel(levelToLoad);
    }

    public void OnLevelWasLoaded()
    {
        ExitTrigger[] allExits = FindObjectsOfType<ExitTrigger>();
        foreach (ExitTrigger exit in allExits)
        {
            Debug.Log(exit.triggerName);
            if (exit.triggerName == lastTrigger)
            {
                playerObject.transform.position = exit.spawnPoint.position;
                break;
            }
        }
        CinemachineVirtualCamera camera = GameObject.Find("CenterCamera").GetComponent<CinemachineVirtualCamera>();
        camera.Follow = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
    }
}