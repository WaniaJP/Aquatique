using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvaManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static CanvaManager _instance;

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
