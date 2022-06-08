using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SaveGame : MonoBehaviour
{

    public TextAsset jsonFile;
    public JsonHandler jsonHandler;

    private PlayerData playerData;
    public Transform player;
    public PlayerSpawn spawnPos;

    [SerializeField]
    private PlayerPresets playerPresets;

    private void Start()
    {
        playerData = jsonHandler.ReadFromJson<PlayerData>("PlayerData");
    }

    public void SavePlayer()
    {

        playerData = jsonHandler.ReadFromJson<PlayerData>("PlayerData");

        playerData = new PlayerData(playerLocation(), GetCurrentScene(), GetPlayerPreset());

        jsonHandler.WriteToJson(playerData, "PlayerData");

    }

    private float[] playerLocation()
    {
        float[] location = new float[]
        {
            player.transform.position.x,
            player.transform.position.y,
            player.transform.position.z 
        };

        return location;
    }

    private string GetCurrentScene()
    {
        return SceneManager.GetActiveScene().name;
    }

    private string[] GetPlayerPreset()
    {
        string[] preset = new string[]
        {
            "#" + ColorUtility.ToHtmlStringRGBA(GetComponent<SpriteRenderer>().color),
            "#" + ColorUtility.ToHtmlStringRGBA(transform.Find("Hair").GetComponent<SpriteRenderer>().color),
            "#" + ColorUtility.ToHtmlStringRGBA(transform.Find("Shirt").GetComponent<SpriteRenderer>().color),
            "#" + ColorUtility.ToHtmlStringRGBA(transform.Find("Pants").GetComponent<SpriteRenderer>().color),
            "#" + ColorUtility.ToHtmlStringRGBA(transform.Find("Shoes").GetComponent<SpriteRenderer>().color)
        };

        return preset;
    }

    public void LoadSavaData()
    {
        player.position = new Vector2(LoadPlayerLocation()[0], LoadPlayerLocation()[1]);
        spawnPos.spawnPosition = player.position;
        SceneManager.LoadScene(LoadCurrentScene(), LoadSceneMode.Single);

        ColorUtility.TryParseHtmlString(LoadPlayerPreset()[0], out Color Skin);
        ColorUtility.TryParseHtmlString(LoadPlayerPreset()[1], out Color Hair);
        ColorUtility.TryParseHtmlString(LoadPlayerPreset()[2], out Color Shirt);
        ColorUtility.TryParseHtmlString(LoadPlayerPreset()[3], out Color Pants);
        ColorUtility.TryParseHtmlString(LoadPlayerPreset()[4], out Color Shoes);

        GetComponent<SpriteRenderer>().color = Skin;
        transform.Find("Hair").GetComponent<SpriteRenderer>().color = Hair;
        transform.Find("Shirt").GetComponent<SpriteRenderer>().color = Shirt;
        transform.Find("Pants").GetComponent<SpriteRenderer>().color = Pants;
        transform.Find("Shoes").GetComponent<SpriteRenderer>().color = Shoes;
    }

    private float[] LoadPlayerLocation()
    { 
        PlayerData posXYZ = jsonHandler.ReadFromJson<PlayerData>("PlayerData");

        return posXYZ.playerPosition;
    }

    private string LoadCurrentScene()
    {
        PlayerData playerScene = jsonHandler.ReadFromJson<PlayerData>("PlayerData");

        return playerScene.sceneName;
    }

    private string[] LoadPlayerPreset()
    {
        PlayerData currentPreset = jsonHandler.ReadFromJson<PlayerData>("PlayerData");

        return currentPreset.playerPreset;
    }

    // klik op knop continue trigger functie 
    // functie loadSaveData
    //      functie setPlayerLocation
    //      functie setPlayerPreset;
    //      functie setcurruntScene;

}

[System.Serializable]
public class PlayerData
{
    public float[] playerPosition;
    public string sceneName;
    public string[] playerPreset;

    public PlayerData(float[] currentLocation, string currentScene, string[] preset)
    {
        this.sceneName = currentScene;
        this.playerPreset = preset;
        this.playerPosition = currentLocation;
    }
}
