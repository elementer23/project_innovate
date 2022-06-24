using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public Button[] btns;
    public Image[] btnImgs;
    public Color normalColor;
    public Color selectedColor;

    //set the buttons interactable when conditions are met
    void Update()
    {
        for (int i = 0; i < btns.Length; i++)
        {
            if (btns[i].interactable)
            {
                btnImgs[i].color = normalColor;
            } else
            {
                btnImgs[i].color = selectedColor;
            }
        }
    }
}
