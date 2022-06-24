using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterCustHandler : MonoBehaviour
{
    //The current body part button.
    //Used for coloring the button.
    [SerializeField]
    private Button currentButton;

    [SerializeField]
    private GameObject arrowContainer;

    //The front and side images of the character.
    public Image frontImage;
    public Image sideImage;

    //The Color picker object.
    [SerializeField]
    private FlexibleColorPicker fcp;

    //The name input field.
    public TMP_InputField nameField;

    //The currently selected part.
    private string currentPart = "SkinButton";

    //The current index number of the sprite array..
    public int currentHairSprite = 0;

    //All the front hair sprites.
    [SerializeField]
    private Sprite[] frontHairSprites;

    //All the side hair sprites.
    [SerializeField]
    private Sprite[] sideHairSprites;

    public RectTransform scaler;
    public RectTransform picker;
    public Color normalColor;
    public Color highlightColor;

    void Start()
    {
        currentButton.interactable = false;
        float scale = scaler.rect.width / picker.rect.width;
        picker.localScale = new Vector2(scale, scale);
        //Start the highlight animation.
        startAnimation(this.frontImage);
        startAnimation(this.sideImage);
        nameChange(GameObject.Find("ContinueButton").transform.GetChild(0).GetComponent<Image>());
    }

    private void Update()
    {
        foreach (Transform btn in transform)
        {
            Image img = btn.GetChild(0).GetComponent<Image>();
            if (btn.name == currentPart)
            {
                img.color = highlightColor;
            }
            else
            {
                img.color = normalColor;
            }
        }
    }

    /// <summary>
    /// Sets the customizer values to the current part.
    /// </summary>
    /// <param name="type">The body part</param>
    private void setCustValues(string type)
    {
        frontImage = GameObject.Find(type + "Front").GetComponent<Image>();
        sideImage = GameObject.Find(type + "Side").GetComponent<Image>();
        currentButton = GameObject.Find(type + "Button").GetComponent<Button>();
    }

    /// <summary>
    /// Change the selected body part.
    /// </summary>
    /// <param name="type">The new body part.</param>
    public void setCharacterPart(string type)
    {
        this.currentPart = type + "Button";
        stopAnimation(this.frontImage);
        stopAnimation(this.sideImage);
        this.currentButton.interactable = true;
        setCustValues(type);

        this.currentButton.interactable = false;
        var tempColor = frontImage.color;
        tempColor.a = 1f;
        this.frontImage.color = tempColor;
        this.sideImage.color = tempColor;

        //Get the current color of the body part and set the colorpicker value to it.
        Color color = frontImage.GetComponent<Image>().color;
        fcp.color = color;

        startAnimation(this.frontImage);
        startAnimation(this.sideImage);

        //If the current part is the hair, show the selection arrows.
        arrowContainer.SetActive(type == "Hair");
    }

    /// <summary>
    /// Update the color of the sprites.
    /// </summary>
    /// <param name="color">The new color.</param>
    public void setColor(Color color)
    {
        this.frontImage.GetComponent<Image>().color = color;
        this.sideImage.GetComponent<Image>().color = color;
    }

    /// <summary>
    /// Change the hair to the next hair sprite.
    /// </summary>
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

    /// <summary>
    /// Change the hair to the previous hair sprite.
    /// </summary>
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

    /// <summary>
    /// Start the hightlight animation.
    /// </summary>
    /// <param name="image">The image that should have the highlight effect.</param>
    private void startAnimation(Image image)
    {
        Animator anim = image.GetComponent<Animator>();
        anim.SetBool("Play", true);
    }

    /// <summary>
    /// Stops the hightlight animation.
    /// </summary>
    /// <param name="image">The image that has the highlight effect.</param>
    private void stopAnimation(Image image)
    {
        Animator anim = image.GetComponent<Animator>();
        anim.SetBool("Play", false);
    }

    /// <summary>
    /// Enables the continue button if a name is entered in the name field.
    /// </summary>
    /// <param name="img">The continue button.</param>
    public void nameChange(Image img)
    {
        img.transform.parent.GetComponent<Button>().interactable = nameField.text.Length > 0;
        Color col = nameField.text.Length > 0 ? normalColor : highlightColor;
        img.color = col;
    }
}
