using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour 
{
    /// <summary>
    /// Declare private varialbes
    /// </summary>
    private GameObject inventoryPanel;
    private GameObject slotPanel;
    private ItemDatabase database;
    private int slotAmount;
    /// <summary>
    /// Declare public varialbes
    /// </summary>
    public GameObject inventorySlot;
    public GameObject invetoryItem;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();
    /// <summary>
    /// Initialize variables
    /// </summary>
    void Start()
    {
        slotAmount = 20;
        database = GetComponent<ItemDatabase>();
        inventoryPanel = GameObject.Find("InventoryPanel");
        slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;
        for (int i = 0; i < slotAmount; i++)
        {
            slots.Add(Instantiate(inventorySlot));
            slots[i].transform.SetParent(slotPanel.transform);
            items.Add(new Item());
        }
    }
    /// <summary>
    /// A method that adds a slot in the inventory and an item in the slot
    /// </summary>
    /// <param name="id"></param>
    public void AddItem(int id)
    {
        Item itemToAdd = database.FetchItemByID(id);
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == -1)
            {
                items[i] = itemToAdd;
                GameObject itemObject = Instantiate(invetoryItem);
                itemObject.transform.SetParent(slots[i].transform);
                itemObject.transform.position = Vector2.zero; // Add the item in the center of the slot
                itemObject.GetComponent<Image>().sprite = itemToAdd.Sprite;
                itemObject.name = itemToAdd.Title;
                break;
            }
        }
    }
}
