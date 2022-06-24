using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SaveGame : MonoBehaviour
{
    [SerializeField]
    private JsonHandler jsonHandler;

    private PlayerData playerData;
    public PlayerSpawn spawnPos;

    [SerializeField]
    private PlayerPresets playerPresets;

    private float _interval = 100f;
    private float _time;

    private void Awake()
    {
        //get the gameobject JsonHandler through a tag
        jsonHandler = GameObject.FindGameObjectWithTag("JsonHandler").GetComponent<JsonHandler>();
        playerData = jsonHandler.ReadFromJson<PlayerData>("PlayerData");
    }

    private void Start()
    {
        _time = 0f;
    }

    private void Update()
    {
        //save the player data with an interval of a minute
        _time += Time.deltaTime;
        while (_time >= _interval)
        {
            SavePlayer();
            _time -= _interval;
        }
    }

    /// <summary>
    /// Save currunt player data
    /// </summary>
    public void SavePlayer()
    {
        //read the json of playerdata
        PlayerData pd = jsonHandler.ReadFromJson<PlayerData>("PlayerData");
        //make a new player data
        playerData = new PlayerData(transform.position.x, transform.position.y, GetCurrentScene(), GetPlayerPreset(), pd.hairStyle, true, GetPlayerName());
        //write the player data to the json file
        jsonHandler.WriteToJson(playerData, "PlayerData");
        Debug.Log("Saved!");
    }

    /// <summary>
    /// gets scene name
    /// </summary>
    /// <returns>Returns string with scene name</returns>
    private string GetCurrentScene()
    {
        //get the current scene name
        return SceneManager.GetActiveScene().name;
    }

    /// <summary>
    /// get player preset
    /// </summary>
    /// <returns></returns>
    private string[] GetPlayerPreset()
    {
        //put all the body presets inside an array
        string[] preset = new string[]
        {
            //get color from the sprite renderer component and set the rgba color to an html color by adding # before it
            "#" + ColorUtility.ToHtmlStringRGBA(GetComponent<SpriteRenderer>().color),
            "#" + ColorUtility.ToHtmlStringRGBA(transform.Find("Hair").GetComponent<SpriteRenderer>().color),
            "#" + ColorUtility.ToHtmlStringRGBA(transform.Find("Shirt").GetComponent<SpriteRenderer>().color),
            "#" + ColorUtility.ToHtmlStringRGBA(transform.Find("Pants").GetComponent<SpriteRenderer>().color),
            "#" + ColorUtility.ToHtmlStringRGBA(transform.Find("Shoes").GetComponent<SpriteRenderer>().color)
        };

        return preset;
    }
    /// <summary>
    /// get the playername from the playerdata json file
    /// </summary>
    /// <returns>Returns string with playername</returns>
    private string GetPlayerName()
    {    
        return playerData.playerName;
    }

    /// <summary>
    /// Load save data from Json
    /// </summary>
    public void LoadSavaData()
    {
        //set the spawn scene to the last saved scene where the player was located
        SceneManager.LoadScene(LoadCurrentScene(), LoadSceneMode.Single);

        //set the spawn position to the last saved player location
        transform.position = new Vector2(LoadPlayerLocation()[0], LoadPlayerLocation()[1]);
        spawnPos.spawnPosition = transform.position;
        

        //get the color from the playerdata and revert the html color to the rgba color
        ColorUtility.TryParseHtmlString(LoadPlayerPreset()[0], out Color Skin);
        ColorUtility.TryParseHtmlString(LoadPlayerPreset()[1], out Color Hair);
        ColorUtility.TryParseHtmlString(LoadPlayerPreset()[2], out Color Shirt);
        ColorUtility.TryParseHtmlString(LoadPlayerPreset()[3], out Color Pants);
        ColorUtility.TryParseHtmlString(LoadPlayerPreset()[4], out Color Shoes);

        //set the body preset colors the player data colors
        GetComponent<SpriteRenderer>().color = Skin;
        transform.Find("Hair").GetComponent<SpriteRenderer>().color = Hair;
        transform.Find("Shirt").GetComponent<SpriteRenderer>().color = Shirt;
        transform.Find("Pants").GetComponent<SpriteRenderer>().color = Pants;
        transform.Find("Shoes").GetComponent<SpriteRenderer>().color = Shoes;

        Debug.Log("Loaded Player");
    }

    /// <summary>
    /// return the player position
    /// </summary>
    /// <returns>Returns player x and y cordinate</returns>
    private float[] LoadPlayerLocation()
    {
        return playerData.playerPosition;
    }

    /// <summary>
    /// Loads right scene
    /// </summary>
    /// <returns>Retruns player scene name</returns>
    private string LoadCurrentScene()
    {
        return playerData.sceneName;
    }

    /// <summary>
    /// return the body preset of the player
    /// </summary>
    /// <returns>Returns body preset</returns>
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
    public int hairStyle;
    public bool playerSaved;
    public string playerName;

    public PlayerData(float posX, float posY, string currentScene, string[] preset, int hairStyle, bool isPlayerSaved, string getPlayerName)
    {
        //set all the player data that needs to be imported into the json
        this.sceneName = currentScene;
        this.playerPreset = preset;
        this.playerSaved = isPlayerSaved;
        this.hairStyle = hairStyle;

        this.playerPosition = new float[2];
        this.playerPosition[0] = posX;
        this.playerPosition[1] = posY;

        this.playerName = getPlayerName;
    }
}
