using UnityEngine;

public class JsonReader : MonoBehaviour
{
    public TextAsset jsonFile;
    public KeyItems items = new KeyItems(); 

    public KeyItems readKeyItems()
    {
        Debug.Log("Load key items");
        UnityEditor.AssetDatabase.Refresh();
        return JsonUtility.FromJson<KeyItems>(jsonFile.text);
    }
}
