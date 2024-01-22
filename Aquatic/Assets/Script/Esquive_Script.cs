using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esquive_Script : MonoBehaviour

{                   // PAS ICI !!!!!!!!!
    private bool isNextTo;
    private Test_player_esquive player;
    //private SpriteRenderer sr;
    [SerializeField] private Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Test_player_esquive>();
        //sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        // LE JOUEUR SE CACHE
        if (!player.estCache && isNextTo && Input.GetKeyDown(KeyCode.E)) {
            player.seCacher(destination);
            //sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);
        }

        // LE JOUEUR QUITTE LA CACHETTE
        if (player.estCache && Input.GetKeyDown(KeyCode.F)) {
            player.quitterCachette();
            //sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D entree) 
    {
           if(entree.CompareTag("Player")) {
            isNextTo = true;
           }
    }
    
    private void OnTriggerExit2D(Collider2D sortie) 
    {
           if(sortie.CompareTag("Player")) {
            isNextTo = false;
           }
    } 
}
