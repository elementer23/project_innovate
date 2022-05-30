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
        StartSleep(10);
    }

    // Update is called once per frame
    void Update()
    {
        ConvertDictoraryToArray(GetComponent<KeyItemsHandler>().getDictionary());        
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

    private void StartSleep(float duration)
    {
        StartCoroutine(HitSleep(duration));
    }

    IEnumerator HitSleep(float duration)
    {
        while (true)
        {
            yield return new WaitForSeconds(duration);
            Debug.Log(JsonUtility.ToJson(keyItems));
            WriteJson();
        }
        
    }
}
