//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class KeyItemsHandler : MonoBehaviour
//{
//    private Dictionary<string, bool> items = new Dictionary<string, bool>();
    
//    //Add items to keyItemsHandler
//    void Start()
//    {
//        KeyItems keyItems = GetComponent<KeyItemsSaver>().readKeyItems();
//        foreach (KeyItem item in keyItems.items)
//        {
//            setItem(item.name, item.collected);
//        }

//        //Water Quest
//        items.Add("Jerrycan", false);
//        items.Add("Wrench", false);
//        items.Add("WaterFulled", false);
//        items.Add("Money", false);

//        //Patat Quest
//        items.Add("Pinpas", false);
//        items.Add("Frikandel", false);

//        //Flower Quest
//        items.Add("Heggenschaar", false);
//        items.Add("Tulip", false);

//        //Bike cerctivacate Quest
//        items.Add("FietsCertivicaat", false);

//        //Windmolen Quest
//        items.Add("Bike", false);
//        items.Add("Bezem", false);
//    }

//    public void setItem(string item, bool isInInventory)
//    {
//        items[item] = isInInventory;
//    }

//    public bool hasItem(string item)
//    {
//        if (items.ContainsKey(item))
//        {
//            return items[item];
//        }
//        else
//        {
//            return false;
//        }
//    }

//    public Dictionary<string, bool> getDictionary()
//    {
//        return items;
//    }
//}
