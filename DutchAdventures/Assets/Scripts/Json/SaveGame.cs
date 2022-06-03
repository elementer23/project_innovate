using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveGame : MonoBehaviour 
{

    public TextAsset jsonFile;
    private JsonHandler jsonHandler;

    private PlayerData playerData;
    public Transform player;

    public void SavePlayer()
    {
        //GameObject player = GameObject.FindWithTag("Player");

        playerData = new PlayerData(player.transform.position, SceneManager.GetActiveScene().name);

        //jsonHandler.WriteToJson(playerData, "PlayerData");
    }

    //public static PlayerData LoadPlayer()
    //{
    //    string path = Application.dataPath + "/Resources/Player.Data";
    //    if (File.Exists(path))
    //    {
    //        BinaryFormatter formatter = new BinaryFormatter();
    //        FileStream stream = new FileStream(path, FileMode.Open);

    //        PlayerData data = formatter.Deserialize(stream) as PlayerData;
    //        stream.Close();

    //        return data;
    //    }
    //    else
    //    {
    //        Debug.LogError("Save file not found in" + path);
    //        return null;
    //    }
    //}

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
    public Vector3 position;
    public string sceneName;
    public PlayerData(Vector3 position, string currentScene)
    {
        this.position = position;
        this.sceneName = currentScene;
    }
}
