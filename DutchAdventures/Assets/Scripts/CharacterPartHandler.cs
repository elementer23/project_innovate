using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPartHandler : MonoBehaviour
{

    //Heeft index nummer van de spriteArray.
    private int currentHairSprite = 0;

    [SerializeField]
    private Sprite[] frontHairSprites;

    [SerializeField]
    private Sprite[] sideHairSprites;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void nextPart()
    {
        if (currentHairSprite >= frontHairSprites.Length - 1)
        {
            return;
        }
        currentHairSprite++;
        Sprite newFrontSprite = frontHairSprites[currentHairSprite];
        Sprite newSideSprite = sideHairSprites[currentHairSprite];
        GameObject.Find("HairLeftArrow").GetComponent<Button>().interactable = true;
        if (currentHairSprite == frontHairSprites.Length - 1)
        {
            //Disable button
            GameObject.Find("HairRightArrow").GetComponent<Button>().interactable = false;
        }
        GameObject.Find("HairFront").GetComponent<Image>().sprite = newFrontSprite;
        GameObject.Find("HairSide").GetComponent<Image>().sprite = newSideSprite;
    }

    public void previousPart()
    {
        if (currentHairSprite <= 0)
        {
            return;
        }
        currentHairSprite--;
        Sprite newFrontSprite = frontHairSprites[currentHairSprite];
        Sprite newSideSprite = sideHairSprites[currentHairSprite];
        GameObject.Find("HairRightArrow").GetComponent<Button>().interactable = true;
        if (currentHairSprite == 0)
        {
            //Disable button
            GameObject.Find("HairLeftArrow").GetComponent<Button>().interactable = false;
        }
        GameObject.Find("HairFront").GetComponent<Image>().sprite = newFrontSprite;
        GameObject.Find("HairSide").GetComponent<Image>().sprite = newSideSprite;
    }
}
