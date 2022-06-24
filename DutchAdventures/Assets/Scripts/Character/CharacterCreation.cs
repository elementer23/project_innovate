using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreation : MonoBehaviour
{
    public PlayerData playerData;
    public CharacterCustHandler characterCustHandler;
    private JsonHandler jsonHandler;

    private void Awake()
    {
        jsonHandler = GameObject.FindGameObjectWithTag("JsonHandler").GetComponent<JsonHandler>();
    }

    /// <summary>
    /// save the typed in player name to the json and update the json with the same data
    /// </summary>
    public void SavePlayerName()
    {
        playerData = jsonHandler.ReadFromJson<PlayerData>("PlayerData");
        PlayerData pd = new PlayerData(playerData.playerPosition[0], playerData.playerPosition[1], playerData.sceneName, playerData.playerPreset, playerData.hairStyle, false, characterCustHandler.nameField.text);
        jsonHandler.WriteToJson(pd, "PlayerData");
    }


}
