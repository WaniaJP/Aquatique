using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Esquive : MonoBehaviour
{

    public bool isNextTo;

    private Player player;

    private Tilemap tm;
    private TilemapRenderer tmRenderer;

    private const int ORDER_IN_LAYER_VALUE_HIDDEN = 3;
    private const int ORDER_IN_LAYER_VALUE_NOT_HIDDEN = 0;
    [SerializeField] public Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        
        tm = GetComponent<Tilemap>();
        tmRenderer = GetComponent<TilemapRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {

        // LE JOUEUR SE CACHE
        if (!player.estCache && !player.bloquerCachette && isNextTo && Input.GetKeyDown(KeyCode.E)) {
            player.seCacher(destination);
            tm.color = new Color(tm.color.r, tm.color.g, tm.color.b, 0.5f);
            tmRenderer.sortingOrder = ORDER_IN_LAYER_VALUE_HIDDEN;
        }

        // LE JOUEUR QUITTE LA CACHETTE
        if (player.estCache && !player.bloquerCachette && Input.GetKeyDown(KeyCode.F)) {
            player.quitterCachette();
            tm.color = new Color(tm.color.r, tm.color.g, tm.color.b, 1);
            tmRenderer.sortingOrder = ORDER_IN_LAYER_VALUE_NOT_HIDDEN;
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
