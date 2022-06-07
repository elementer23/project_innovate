using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class KeyItemsSaver : MonoBehaviour
{
    [Header("Save Data")]
    [SerializeField]
    private TextAsset jsonFile;
    private JsonHandler jsonHandler;

    private Dictionary<string, bool> itemsDic = new Dictionary<string, bool>();

    [SerializeField]
    private KeyItems keyItems = new KeyItems();

    void Start()
    {
        jsonHandler = FindObjectOfType<JsonHandler>();
        keyItems = readItems();

        //Start the auto saver
        //StartCoroutine(HitSleep(10));

        foreach (KeyItem item in keyItems.items)
        {
            setItem(item.name, item.collected);
        }
    }

    public void SaveItems()
    {
        //Save the items to the JSON file
        Debug.Log(JsonUtility.ToJson(keyItems));
        jsonHandler.WriteToJson(keyItems, "KeyItems");

    }

    public KeyItems readItems()
    {
        //Read the items from the JSON file
        return jsonHandler.ReadFromJson<KeyItems>("KeyItems");
    }

    public void setItem(string itemName, bool isInInventory)
    {
        //Set the item in the dictionary
        itemsDic[itemName] = isInInventory;
        //Update the keyItem array
        DicToKeyItem();
    }

    public bool hasItem(string item)
    {
        //Check if the dictionary contains the item, then return if the player has it
        if (itemsDic.ContainsKey(item))
        {
            return itemsDic[item];
        }
        else
        {
            return false;
        }
    }

    private void DicToKeyItem()
    {
        //Set the array length to the dictionary length
        keyItems.items = new KeyItem[itemsDic.Count];

        //Put the dictionary values in the array
        int i = 0;
        foreach (KeyValuePair<string, bool> item in itemsDic)
        {
            keyItems.items[i] = new KeyItem(item.Key, item.Value);
            i++;
        }
    }

    //Autosave coroutine
    IEnumerator HitSleep(float duration)
    {
        while (true)
        {
            yield return new WaitForSeconds(duration);
            jsonHandler.WriteToJson(keyItems, "KeyItems");
        }
    }
}

//////////////////////
// Key item classes //
//////////////////////

[System.Serializable]
public class KeyItems
{
    public KeyItem[] items;
}

[System.Serializable]
public class KeyItem
{
    public string name;
    public bool collected;

    public KeyItem(string name, bool collected)
    {
        this.name = name;
        this.collected = collected;
    }
}