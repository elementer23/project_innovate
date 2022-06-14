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

    public void SavePlayerName()
    {
        playerData = jsonHandler.ReadFromJson<PlayerData>("PlayerData");
        playerData = new PlayerData(playerData.playerPosition[0], playerData.playerPosition[1], playerData.sceneName, playerData.playerPreset, false, characterCustHandler.nameField.text);
        jsonHandler.WriteToJson(playerData, "PlayerData");
    }


}
