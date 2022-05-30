using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemsHandler : MonoBehaviour
{
    // Start is called before the first frame 
    private Dictionary<string, bool> items = new Dictionary<string, bool>();
    
    //Add items to keyItemsHandler
    void Start()
    {
        items.Add("Jerrycan", false);
        items.Add("Wrench", false);
        items.Add("WaterFulled", false);
        items.Add("Money", false);

    }

    public void setItem(string item, bool isInInventory)
    {
        items[item] = isInInventory;
    }

    public bool hasItem(string item)
    {
        if (items.ContainsKey(item))
        {
            return items[item];
        } else
        {
            return false;
        }
    }

    public Dictionary<string ,bool> getDictionary()
    {
        return items;
    }
}
