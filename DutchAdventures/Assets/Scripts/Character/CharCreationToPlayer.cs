using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharCreationToPlayer : MonoBehaviour
{
    public CharacterCustHandler CharacterCustHandler;
    public PlayerPresets playerPreset;
    public Image[] images = new Image[5];
    public SpriteRenderer[] srs = new SpriteRenderer[5];
    public JsonHandler jsonHandler;
    public string playerName = "player";
    [SerializeField]
    private PlayerSpawn exit;
    
    public void UpdateValues()
    {
        string[] colors = new string[5];

        for (int i = 0; i < images.Length; i++)
        {
            srs[i].sprite = images[i].sprite;
            colors[i] = "#" + ColorUtility.ToHtmlStringRGB(images[i].color);
        }

        PlayerData playerData = new PlayerData(0, 0, "BigCityScene", colors, CharacterCustHandler.currentHairSprite, false, playerName);
        jsonHandler.WriteToJson(playerData, "PlayerData");
    }
    /// <summary>
    /// Reset the player position exit scritable object
    /// </summary>
    public void resetPlayerPosition()
    {
        exit.spawnPosition = Vector2.zero;
    }
}
