using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour, IDataPersistence
{

    public int maxStackedItems = 4;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemprefab;

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

    /*public void LoadData(GameData gameData)
    {
        throw new System.NotImplementedException();
    }*/

    public void LoadData(GameData data)
    {
        if (data.objectActive.TryGetValue(id, out bool loadedIsActive))
        {
            isActive = loadedIsActive;

            Debug.Log("isActive après le load = " + isActive);

            if (isActive)
            {
                //gameObject.SetActive(true);
            }
            else
            {
                //gameObject.SetActive(false);
            }
        }

        foreach (string itemId in data.objectPossessed.Keys)
        {
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                InventorySlot slot = inventorySlots[i];
                InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                if (itemInSlot != null)
                {
                    string itemId = itemInSlot.id;
                    int itemCount = itemInSlot.count;

                    if (data.objectPossessed.ContainsKey(itemId))
                    {
                        data.objectPossessed.Remove(itemId);
                    }
                    Debug.Log("itemCount lors de la save = " + itemCount);
                    data.objectPossessed.Add(itemId, itemCount);
                }
            }
        }
    }

    public void SaveData(GameData data)
    {
        data.objectPossessed.Clear();

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null)
            {
                string itemId = itemInSlot.id;
                int itemCount = itemInSlot.count;

                if (data.objectPossessed.ContainsKey(itemId))
                {
                    data.objectPossessed.Remove(itemId);
                }
                Debug.Log("itemCount lors de la save = " + itemCount);
                data.objectPossessed.Add(itemId, itemCount);
            }
        }
    }
}
