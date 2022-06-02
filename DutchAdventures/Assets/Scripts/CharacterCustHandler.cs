using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustHandler : MonoBehaviour
{
    [SerializeField]
    private Button currentButton;

    public Image frontImage;
    public Image sideImage;

    [SerializeField]
    private FlexibleColorPicker fcp;

    private string currentPart = "Skin";

    void Start()
    {
        currentButton.interactable = false;
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
        frontImage.color = tempColor;
        sideImage.color = tempColor;

        Color color = frontImage.GetComponent<Image>().color;
        fcp.color = color;

        startAnimation(frontImage);
        startAnimation(sideImage);
    }

    public void setColor(Color color)
    {
        this.frontImage.GetComponent<Image>().color = color;
        this.sideImage.GetComponent<Image>().color = color;
    }

    private void startAnimation(Image image)
    {
        Animator anim = image.GetComponent<Animator>();
        anim.enabled = true;
        anim.Play("Base Layer.partSelectAnimation", -1, 0f);
    }

    private void stopAnimation(Image image)
    {
        Animator anim = image.GetComponent<Animator>();
        anim.enabled = false;
    }
}
