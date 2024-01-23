using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    private Player player;
    [Header("Component")]
    //public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public float currentTimeCacheCache;

    [Header("Limits Settings")]
    public float timerLimit;
    public float timerLimitCacheCache;

    private DataPersistenceManager dataPersistenceManager;
    private Defi_Cache_Cache dcc;

    private bool resetCacheCacheTimer;

    // Start is called before the first frame update
    void Start()
    {
        //dataPersistenceManager = FindObjectOfType<DataPersistenceManager>();
        resetCacheCacheTimer = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        currentTimeCacheCache += Time.deltaTime;

        if(currentTime >= timerLimit)
        {
            currentTime = 0;
            SetTimerText();
            //enabled = false;
            //dataPersistenceManager.SaveGame();
        }

        if(dcc.cacheCacheActif && resetCacheCacheTimer) {
            resetCacheCacheTimer = false;
            currentTimeCacheCache = 0;
        }

        if(dcc.cacheCacheActif && currentTimeCacheCache>=timerLimitCacheCache) {

        }

        SetTimerText();
    }

    private void SetTimerText()
    {
        //timerText.text = currentTime.ToString("0.0");
    }
}
