using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusiqueManager : MonoBehaviour
{
    public static MusiqueManager _instance;

    public void Awake()
    {
        if (_instance != null)
            Destroy(gameObject);
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
