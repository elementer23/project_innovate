using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonWriter : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyItems keyItems = new KeyItems();
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ConvertDictoraryToArray(GetComponent<KeyItemsHandler>().getDictionary());
        WriteJson();        
    }

    private void ConvertDictoraryToArray(Dictionary<string, bool> dic)
    {
        keyItems.items = new KeyItem[dic.Count];
        int index = 0;
        foreach (KeyValuePair<string, bool> kvp in dic)
        {
            keyItems.items[index] = new KeyItem(kvp.Key, kvp.Value); 
            index++;
        }
    }

    private void WriteJson()
    {
        File.WriteAllText(Application.dataPath + "/Resources/KeyItems.json", JsonUtility.ToJson(keyItems));
    }
}
