using UnityEngine;
using System;

public class ExitTrigger : MonoBehaviour
{
    public string triggerName; //this should match on both ends
    public string levelToLoad; //what level this trigger leads to
    public Transform spawnPoint; //where the player should spawn. IMPORTANT: not inside this trigger



    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneLoader._instance.OnEnteredExitTrigger(triggerName, levelToLoad);

        
    }
}
