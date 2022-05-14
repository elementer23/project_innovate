using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Sprite defaultSprite;
    public Sprite pressedSprite;

    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {

    }

    public void ChangeOnPressed()
    {
        if (image.sprite != pressedSprite)
        {
            image.sprite = pressedSprite;
        }
        else
        {
            image.sprite = defaultSprite;
        }
    }
}
