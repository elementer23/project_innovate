using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterCustHandler : MonoBehaviour
{
    [SerializeField]
    private Button currentButton;

    [SerializeField]
    private GameObject arrowContainer;

    public Image frontImage;
    public Image sideImage;

    [SerializeField]
    private FlexibleColorPicker fcp;

    public TMP_InputField nameField;

    private string currentPart = "Skin";

    //Heeft index nummer van de spriteArray.
    public int currentHairSprite = 0;

    [SerializeField]
    private Sprite[] frontHairSprites;

    [SerializeField]
    private Sprite[] sideHairSprites;

    public RectTransform scaler;
    public RectTransform picker;

    void Start()
    {
        currentButton.interactable = false;
        float scale = scaler.rect.width / picker.rect.width;
        picker.localScale = new Vector2(scale, scale);
        startAnimation(this.frontImage);
        startAnimation(this.sideImage);
    }

    private void setCustValues(string type)
    {
        frontImage = GameObject.Find(type + "Front").GetComponent<Image>();
        sideImage = GameObject.Find(type + "Side").GetComponent<Image>();
        currentButton = GameObject.Find(type + "Button").GetComponent<Button>();
        this.currentPart = type;
    }

    public void setCharacterPart(string type)
    {
        stopAnimation(this.frontImage);
        stopAnimation(this.sideImage);
        this.currentButton.interactable = true;
        setCustValues(type);

        this.currentButton.interactable = false;
        var tempColor = frontImage.color;
        tempColor.a = 1f;
        this.frontImage.color = tempColor;
        this.sideImage.color = tempColor;

        Color color = frontImage.GetComponent<Image>().color;
        fcp.color = color;

        startAnimation(this.frontImage);
        startAnimation(this.sideImage);

        arrowContainer.SetActive(type == "Hair");
    }

    public void setColor(Color color)
    {
        this.frontImage.GetComponent<Image>().color = color;
        this.sideImage.GetComponent<Image>().color = color;
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

        if (currentHairSprite == frontHairSprites.Length - 1)
        {
            Color skinCol = GameObject.Find("SkinFront").GetComponent<Image>().color;
            GameObject.Find("HairFront").GetComponent<Image>().color = skinCol;
            GameObject.Find("HairSide").GetComponent<Image>().color = skinCol;
        }
        //{
        //    GameObject.Find("HairFront").GetComponent<Image>().color = skinCol;
        //    GameObject.Find("HairSide").GetComponent<Image>().color = skinCol;
        //}
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

    private void startAnimation(Image image)
    {
        Animator anim = image.GetComponent<Animator>();
        anim.SetBool("Play", true);
    }

    private void stopAnimation(Image image)
    {
        Animator anim = image.GetComponent<Animator>();
        anim.SetBool("Play", false);
    }

    public void nameChange()
    {
        GameObject.Find("ContinueButton").GetComponent<Button>().interactable = (nameField.text.Length > 0);
    }
}
