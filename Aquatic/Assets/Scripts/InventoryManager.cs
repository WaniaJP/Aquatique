using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static Item;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour, IDataPersistence
{

    public int maxStackedItems = 4;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemprefab;
    public DemoScript demoScript;

    int selectedSlot = -1;

    private void Start()
    {
        ChangeSelectedSlot(0);
    }

    // Clavier 1-8 pour changer le slot
    private void Update()
    {
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number < 6)
            {
                ChangeSelectedSlot(number - 1);
            }
        }
    }

    public void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].Deselect();
        }
        inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }

    public bool AddItem(Item item)
    {
        // Check if same item has count lower than max
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null &&
                itemInSlot.item == item &&
                itemInSlot.count < maxStackedItems &&
                itemInSlot.item.stackable == true)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }

        // Find any empty slot
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }
        return false;
    }

    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemprefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    public Item GetSelectedItem(bool use)
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null)
        {
            Item item = itemInSlot.item;
            if (use == true) {
                itemInSlot.count--;

                if(itemInSlot.count <= 0)
                {
                    Destroy(itemInSlot.gameObject);
                }
                else
                {
                    itemInSlot.RefreshCount();
                }
            }
            return item;
        }
        return null;
    }

    public void LoadData(GameData data)
    {
        demoScript = FindObjectOfType<DemoScript>();
        if (demoScript != null && data.objectPossessedId.Count()>0)
        {
            for(int i = 0; i < inventorySlots.Length; i++)
            {
                InventorySlot slot = inventorySlots[i];
                InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                if (itemInSlot != null)
                {
                    Destroy(itemInSlot.gameObject);
                }

                if(i < data.objectPossessedId.Count())
                {
                    int idValue = data.objectPossessedId[i];
                    Item item = demoScript.itemsToPickup[idValue];

                    for (int j = 0; j < demoScript.itemsToPickup.Length; j++)
                    {
                        if (item == demoScript.itemsToPickup[j])
                        {
                            SpawnNewItem(item, slot);
                        }
                    }
                }
            }
        }
        else
        {
            Debug.LogError("Il n'existe aucun objet avec le type DemoScript OU il n'y a pas de sauvegarde existante");
        }
    }

    public void SaveData(GameData data)
    {
        data.objectPossessedId.Clear();

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null)
            {
                Item item = itemInSlot.item;
                int itemId = -1;
                for (int j = 0; j < demoScript.itemsToPickup.Length; j++)
                {
                    if (item == demoScript.itemsToPickup[j])
                    {
                        itemId = j;
                    }
                }
               
                if(itemId != -1)
                {
                    if (data.objectPossessedId.Contains(itemId))
                    {
                        data.objectPossessedId.Remove(itemId);
                    }
                    data.objectPossessedId.Add(itemId);
                }
                else
                {
                    Debug.LogError("Item non existant");
                }

            }
        }
    }
}
