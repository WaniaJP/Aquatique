using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class MapFactManager : MonoBehaviour
{
    public static MapFactManager instance;
    public Fact[] facts;
    public ModificationFact[] MapsFacts;

    private void Awake()
    {
        Debug.Log("Here");
        if (instance == null)
        {
            instance = this;
            SceneLoader.OnLevelLoaded += UpdateMapFact;
            Debug.Log("Here2");
        }

        // Initialiser les tableaux s'ils ne sont pas encore d�finis
        if (facts == null)
        {
            facts = new Fact[0];
        }
        if (MapsFacts == null)
        {
            MapsFacts = new ModificationFact[0];
        }
    }

    private void Start()
    {
        UpdateMapFact();
    }

    public Fact GetFactByName(string name)
    {
        Debug.Log("GetFactByName1");
        // Rechercher un fait par son nom
        Fact fact = facts.FirstOrDefault(f => f.name == name);
        Debug.Log(fact);
        Debug.Log("GetFactByName2");
        // Si le fait n'est pas trouv�, en cr�er un nouveau
        if (fact == null)
        {
            fact = new Fact(System.Guid.NewGuid().ToString(), name);

            // Ajouter le nouveau fait � la liste des faits
            facts = facts.Append(fact).ToArray();
            Debug.LogWarning("Nouveau fait cr�� : " + name); // Message de d�bogage

            
            ModificationFact mod = new (fact, ModificationFact.OperationType.Add);
            MapsFacts = MapsFacts.Append(mod).ToArray();
            Debug.LogWarning("Nouvelle modification de fait ajout�e pour : " + name); // Message de d�bogage
        }

        return fact;
    }

    private void UpdateMapFact()
    {
        string path = SceneManager.GetActiveScene().path;

        // Parcourir tous les ModificationFact dans MapsFacts
        foreach (ModificationFact modFact in MapsFacts)
        {
            // V�rifier si le nom du ModificationFact correspond au chemin de la sc�ne
            if (modFact.item.name.Equals(path))
            {
                // Si la correspondance est trouv�e, process la modification
                modFact.Process();
                Debug.LogWarning("Modification de fait appliqu�e pour la sc�ne : " + path); // Message de d�bogage
            }
        }
    }

    private void OnDisable()
    {
        SceneLoader.OnLevelLoaded -= UpdateMapFact;
    }
}
