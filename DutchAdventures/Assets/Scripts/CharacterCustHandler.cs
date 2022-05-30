using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustHandler : MonoBehaviour
{
    [SerializeField]
    private Button currentButton;

    public Image currentImage;

    public AnimationClip walk;

    private Animator anim;

    [SerializeField]
    private FlexibleColorPicker fcp;

    // Start is called before the first frame update
    void Start()
    {
        currentButton.interactable = false;
    }

    // Update is called once per frame
    void Update() 
    {
        
    }

    public void setCurrentButton(Button button)
    {
        currentButton.interactable = true;
        this.currentButton = button;
        currentButton.interactable = false;
    }

    public void setCharacterPart(Image image)
    {

        anim = currentImage.GetComponent<Animator>();
        anim.enabled = false;
        var tempColor = currentImage.color;
        tempColor.a = 1f;
        currentImage.color = tempColor;

        this.currentImage = image;
        Color color = image.GetComponent<Image>().color;
        fcp.color = color;

        anim = image.GetComponent<Animator>();
        anim.enabled = true;

        anim.Play("Base Layer.partSelectAnimation", -1, 0f);
    }
}
