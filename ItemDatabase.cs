using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class ItemDatabase : MonoBehaviour 
{
    /// <summary>
    /// Declaration of private variables
    /// </summary>
    private List<Item> database = new List<Item>();
    private JsonData itemData;
    /// <summary>
    /// Initialization of variables
    /// </summary>
    void Start()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
    }

    /// <summary>
    /// A method that runs the item list and finds the item with the wanted id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Item FetchItemByID(int id)
    {
        for (int i = 0; i < database.Count; i++)
        {
            if (database[i].ID == id)
            {
                return database[i];
            }
        }
        return null;
    }
    /// <summary>
    /// Add item data in the database
    /// </summary>
    void ConstructItemDatabase()
    {
        for (int i = 0; i < itemData.Count; i++)
        {
            database.Add(new Item((int)itemData[i]["id"] , itemData[i]["title"].ToString() , (int)itemData[i]["value"],
                        (int)itemData[i]["stats"]["power"], (int)itemData[i]["stats"]["defence"], (int)itemData[i]["stats"]["vitality"],
                        itemData[i]["stats"]["description"].ToString(), (bool)itemData[i]["stats"]["stackalbe"], (int)itemData[i]["stats"]["rapidity"]));
        }
    }
}
/// <summary>
///Class Item
/// </summary>
public class Item
{
    public int ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
    public int Power { get; set; }
    public int Defence { get; set; }
    public int Vitality { get; set; }
    public string Description { get; set; }
    public bool Stackable { get; set; }
    public int Rapidity { get; set; }
    public Sprite Sprite { get; set; }

    /// <summary>
    /// If item not empty
    /// </summary>
    /// <param name="id"></param>
    /// <param name="title"></param>
    /// <param name="value"></param>
    /// <param name="power"></param>
    /// <param name="defence"></param>
    /// <param name="vitality"></param>
    /// <param name="description"></param>
    /// <param name="stackable"></param>
    /// <param name="rapidity"></param>
    public Item(int id , string title, int value ,int power, int defence, int vitality , string description, 
                bool stackable , int rapidity) 
    {
        this.ID = id;
        this.Title = title;
        this.Value = value;
        this.Power = power;
        this.Defence = defence;
        this.Vitality = vitality;
        this.Description = description;
        this.Stackable = stackable;
        this.Rapidity = rapidity;
        this.Sprite = Resources.Load<Sprite>("Sprites/Sword");
    }

    /// <summary>
    /// If the item is empty 
    /// </summary>
    public Item()
    {
        this.ID = -1;
    }
}