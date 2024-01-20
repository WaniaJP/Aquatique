using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;

    [Header("Limits Settings")]
    public float timerLimit;

    private DataPersistenceManager dataPersistenceManager;

    // Start is called before the first frame update
    void Start()
    {
        dataPersistenceManager = FindObjectOfType<DataPersistenceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= timerLimit)
        {
            currentTime = 0;
            SetTimerText();
            //enabled = false;
            dataPersistenceManager.SaveGame();
        }
        SetTimerText();
    }

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0.0");
    }
}
