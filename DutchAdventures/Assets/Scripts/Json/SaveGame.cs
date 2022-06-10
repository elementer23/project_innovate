using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SaveGame : MonoBehaviour
{
    private JsonHandler jsonHandler;

    private PlayerData playerData;
    public PlayerSpawn spawnPos;

    [SerializeField]
    private PlayerPresets playerPresets;

    private void Awake()
    {
        jsonHandler = GameObject.FindGameObjectWithTag("JsonHandler").GetComponent<JsonHandler>();
        playerData = jsonHandler.ReadFromJson<PlayerData>("PlayerData");
    }

    public void SavePlayer()
    {
        playerData = new PlayerData(transform.position.x, transform.position.y, GetCurrentScene(), GetPlayerPreset(), true);

        jsonHandler.WriteToJson(playerData, "PlayerData");

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
        transform.position = new Vector2(LoadPlayerLocation()[0], LoadPlayerLocation()[1]);
        spawnPos.spawnPosition = transform.position;
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
        return playerData.playerPosition;
    }

    private string LoadCurrentScene()
    {
        return playerData.sceneName;
    }

    private string[] LoadPlayerPreset()
    {
        return playerData.playerPreset;
    }

}

[System.Serializable]
public class PlayerData
{
    public float[] playerPosition;
    public string sceneName;
    public string[] playerPreset;
    public bool playerSaved;

    public PlayerData(float posX, float posY, string currentScene, string[] preset, bool isPlayerSaved)
    {
        this.sceneName = currentScene;
        this.playerPreset = preset;
        this.playerSaved = isPlayerSaved;

        this.playerPosition = new float[2];
        this.playerPosition[0] = posX;
        this.playerPosition[1] = posY;
    }
}
