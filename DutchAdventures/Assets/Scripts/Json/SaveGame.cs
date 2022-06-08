using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SaveGame : MonoBehaviour
{

    public TextAsset jsonFile;
    public JsonHandler jsonHandler;

    private PlayerData playerData;
    public Transform player;

    private void Start()
    {
        playerData = jsonHandler.ReadFromJson<PlayerData>("PlayerData");
    }

    public void SavePlayer()
    {

        playerData = jsonHandler.ReadFromJson<PlayerData>("PlayerData");

        playerData = new PlayerData(GetPlayerLocationX(), GetPlayerLocationY(), GetPlayerLocationZ(), GetCurrentScene());

        jsonHandler.WriteToJson(playerData, "PlayerData");

    }

    private float GetPlayerLocationX()
    { 
        return player.transform.position.x;
    }

    private float GetPlayerLocationY()
    {
        return player.transform.position.y;
    }

    private float GetPlayerLocationZ()
    {
        return player.transform.position.z;
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
public class PlayerData
{
    public float posX;
    public float posY;
    public float posZ;
    public string sceneName;

    public PlayerData(float posX, float posY, float posZ, string currentScene)
    {
        this.posX = posX;
        this.posY = posY;
        this.posZ = posZ;
        this.sceneName = currentScene;
    }
}
