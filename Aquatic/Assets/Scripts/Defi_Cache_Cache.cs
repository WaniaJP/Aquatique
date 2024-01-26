using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Defi_Cache_Cache : MonoBehaviour
{

    public bool cacheCacheActif;
    public bool cacheCacheGagne;
    public bool cacheCachePerdu;
    public bool enRecherche;

    public float currentTime;
    public float limiteDecompte;
    public List<Esquive> listeCachettes;
    private Player player;
    private GameObject chercheur;

    [SerializeField] private float speed; 

    // Start is called before the first frame update
    void Start()
    {

        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        chercheur = GameObject.FindGameObjectWithTag("Encreva Furtiflimb");

        listeCachettes.Add(GameObject.Find("cachette1").GetComponent<Esquive>());
        listeCachettes.Add(GameObject.Find("cachette2").GetComponent<Esquive>());
        listeCachettes.Add(GameObject.Find("cachette3").GetComponent<Esquive>());
        listeCachettes.Add(GameObject.Find("cachette4").GetComponent<Esquive>());
        listeCachettes.Add(GameObject.Find("cachette5").GetComponent<Esquive>());

        currentTime = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cacheCacheActif) {
            Decompter();
        }

        if (currentTime >= limiteDecompte) {
            cacheCacheGagne = rechercherJoueur();
        }
    }

    public bool rechercherJoueur() {
        /*player.bloquerCachette = true;
        if (!player.estCache) {
            cacheCachePerdu = true;
            player.bloquerCachette = false;
            cacheCacheActif = false;
            currentTime = 0;
            return false;
        }
        else {
            if (!enRecherche) {
                shuffleList(listeCachettes);
                enRecherche = true;
            }
            for (int i = 0; i < 4; ++i) {
                //chercheur.transform.position = Vector3.MoveTowards(transform.position, listeCachettes[i].destination.position, speed*Time.deltaTime);
                //chercheur.transform.position = listeCachettes[i].destination.position;
                if (listeCachettes[i].isNextTo) {
                    cacheCachePerdu = true;
                    player.bloquerCachette = false;
                    cacheCacheActif = false;
                    currentTime = 0;
                    return false;
                }
            }
            player.bloquerCachette = false;
            cacheCacheActif = false;
            currentTime = 0;
            return true;
        }*/

        return true;
    }

    private void Decompter() {
        currentTime += Time.deltaTime;
    }

    private void shuffleList(List<Esquive> liste) {
        var count = liste.Count;
        for (var i = 0; i< count - 1; ++i) {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = liste[i];
            liste[i] = liste[r];
            liste[r] = tmp;
        }
    }
}
