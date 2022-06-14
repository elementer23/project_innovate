using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorsLoader : MonoBehaviour
{
    public JsonHandler jsonHandler;
    public PlayerData playerData;
    public SpriteRenderer[] srs;

    void Start()
    {
        jsonHandler = GameObject.FindGameObjectWithTag("JsonHandler").GetComponent<JsonHandler>();
        playerData = jsonHandler.ReadFromJson<PlayerData>("PlayerData");
        Debug.Log("read from json /\\ ");

        for (int i = 0; i < playerData.playerPreset.Length; i++)
        {
            Color newCol;
            ColorUtility.TryParseHtmlString(playerData.playerPreset[i], out newCol);
            srs[i].color = newCol;
        }
    }

    void Update()
    {
        
    }
}
