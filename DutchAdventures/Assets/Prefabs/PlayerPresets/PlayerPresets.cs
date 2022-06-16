using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "playerPreset", menuName = "ScriptableObjects/PlayerPreset", order = 1)]
public class PlayerPresets : ScriptableObject
{
    public Color skin;
    public Color hair;
    public Color shirt;
    public Color pants;
    public Color shoes;
    public int hairStyle;
}
