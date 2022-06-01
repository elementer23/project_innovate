using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonHandler : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void WriteToJson<T>(T dataToWrite, string fileName)
    {
        Debug.Log("Write to JSON: " + dataToWrite);
        File.WriteAllText(Application.dataPath + "/Resources/" + fileName + ".json", JsonUtility.ToJson(dataToWrite));
    }

    public T ReadFromJson<T>(TextAsset jsonFile)
    {
        Debug.Log("Read from JSON: " + jsonFile.name);
        UnityEditor.AssetDatabase.Refresh();
        return JsonUtility.FromJson<T>(jsonFile.text);
    }
}
