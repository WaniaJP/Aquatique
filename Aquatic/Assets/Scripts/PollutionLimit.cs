using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollutionLimit : MonoBehaviour
{

    private Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D entree) 
    {
           if(entree.CompareTag("Player")) {
            player.isAboveLimit = true;
           }
    }
    
    private void OnTriggerExit2D(Collider2D sortie) 
    {
           if(sortie.CompareTag("Player")) {
            player.isAboveLimit = false;
           }
    } 
}
