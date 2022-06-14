using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharCreationToPlayer : MonoBehaviour
{
    public CharacterCustHandler CharacterCustHandler;
    public PlayerPresets playerPreset;
    public Image skin;
    public Image hair;
    public Image shirt;
    public Image pants;
    public Image shoes;

    public void UpdateValues()
    {
        playerPreset.skin = skin.color;
        playerPreset.hair = hair.color;
        playerPreset.shirt = shirt.color;
        playerPreset.pants = pants.color;
        playerPreset.shoes = shoes.color;
        playerPreset.hairStyle = CharacterCustHandler.currentHairSprite;
    }
}
