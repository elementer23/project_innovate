using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SaveGame : MonoBehaviour
{

    public TextAsset jsonFile;
    private JsonHandler jsonHandler;

    public PlayerData playerData;
    public Transform player;

    private void Start()
    {
        playerData = jsonHandler.ReadFromJson<PlayerData>("PlayerData");
    }

    public void SavePlayer()
    {
        //playerData = jsonHandler.ReadFromJson<PlayerData>(jsonFile);
        playerData = jsonHandler.ReadFromJson<PlayerData>("PlayerData");

        playerData = new PlayerData(GetPlayerLocation(), GetCurrentScene());

        jsonHandler.WriteToJson(playerData, "PlayerData");

    }

    private Vector3 GetPlayerLocation()
    { 
        return player.transform.position;
    }

    private string GetCurrentScene()
    {
        return SceneManager.GetActiveScene().name;
    }



    // klik op knop save trigger functie 
    // functie saveData
    //      functie getPlayerLocation
    //      functie GetPlayerPreset;
    //      functie getcurruntScene;


    // run functie writeToJsonSaveData()
    // return Player.Postion
    // return playerPreset scriptable object.


    //      

    // klik op knop continue trigger functie 
    // functie loadSaveData
    //      functie setPlayerLocation
    //      functie setPlayerPreset;
    //      functie setcurruntScene;


    // run functie readJson()
    // return Player.Postion
    // return playerPreset scriptable object.


    //      

}

[System.Serializable] 
public class PlayerDatas
{
    public PlayerData[] data;
}

[System.Serializable]
public class PlayerData
{
    public Vector3 position;
    public string sceneName;
    public PlayerData(Vector3 position, string currentScene)
    {
        this.position = position;
        this.sceneName = currentScene;
    }
}
