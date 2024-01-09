using UnityEngine;

public class Object : MonoBehaviour, Iinteraction, IDataPersistence
{
    [SerializeField] private string id;

    [ContextMenu("Generate Guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private bool isActive = true;
    private Inventory inventory;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Action();
    }

    //object -> depop + ajout inventaire
    public void Action()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
        isActive = false;

        for (int i = 0; i <= inventory.slots.Length; i++)
        {
            if (inventory.slots[i] == false)
            {
                // Item can be picked up
                inventory.isFull[i] = true;
                break;

            }
        }
    }

    public void LoadData(GameData data)
    {
        if (data.objectActive.TryGetValue(id, out bool loadedIsActive))
        {
            isActive = loadedIsActive;

            Debug.Log("isActive après le load = " + isActive);

            if (isActive)
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void SaveData(GameData data)
    {
        //Active

        if (data.objectActive.ContainsKey(id))
        {
            data.objectActive.Remove(id);
        }
        Debug.Log("isActive lors de la save = " + isActive);
        data.objectActive.Add(id, isActive);
    }
}