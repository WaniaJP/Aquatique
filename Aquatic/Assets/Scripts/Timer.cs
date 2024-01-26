
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    private Player player;

    [Header("Timer Settings")]
    public float currentTime;

    [Header("Limits Settings")]
    public float timerLimitHeal;
    public float timerLimitDamageAbovePollutionLimit;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= timerLimitHeal && !player.isAboveLimit)
        {
            currentTime = 0;
            SetTimerText();
            //enabled = false;
            player.setHealth(-2f);

        }

        if (currentTime >= timerLimitDamageAbovePollutionLimit && player.isAboveLimit)
        {
            currentTime = 0;
            SetTimerText();
            player.setHealth(10f);
        }
        SetTimerText();
    }

    private void SetTimerText()
    {
    }
}
