using UnityEngine;

public class JsonReader : MonoBehaviour
{
    public TextAsset jsonFile;
    public KeyItems items = new KeyItems();

    // Read the selected jason file for data
    void Start()
    {
        KeyItems KeyItemsJson = JsonUtility.FromJson<KeyItems>(jsonFile.text);      
    }
    
}
