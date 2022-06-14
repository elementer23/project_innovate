using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStyleHandler : MonoBehaviour
{
    [SerializeField]
    private PlayerPresets playerColors;

    [SerializeField]
    private Sprite[] hairStyles;

    void Start()
    {
        GetComponent<SpriteRenderer>().color = playerColors.skin;
        //transform.Find("Hair").GetComponent<SpriteRenderer>().sprite = hairStyles[playerColors.hairStyle];
        transform.Find("Hair").GetComponent<SpriteRenderer>().color = playerColors.hair;
        transform.Find("Shirt").GetComponent<SpriteRenderer>().color = playerColors.shirt;
        transform.Find("Pants").GetComponent<SpriteRenderer>().color = playerColors.pants;
        transform.Find("Shoes").GetComponent<SpriteRenderer>().color = playerColors.shoes;
    }
}
