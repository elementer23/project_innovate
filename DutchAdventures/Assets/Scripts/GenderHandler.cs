using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenderHandler : MonoBehaviour
{

    //False = Male, True = Female.
    private bool gender = false;

    [SerializeField]
    private Button maleButton;

    [SerializeField]
    private Button femaleButton;

    [SerializeField]
    private Sprite maleHairFront;

    [SerializeField]
    private Sprite maleHairSide;

    [SerializeField]
    private Sprite femaleHairFront;

    [SerializeField]
    private Sprite femaleHairSide;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setGender(bool gender)
    {
        if (gender)
        {
            GameObject.Find("HairFront").GetComponent<Image>().sprite = femaleHairFront;
            GameObject.Find("HairSide").GetComponent<Image>().sprite = femaleHairSide;
            femaleButton.interactable = false;
            maleButton.interactable = true;
        }
        else
        {
            GameObject.Find("HairFront").GetComponent<Image>().sprite = maleHairFront;
            GameObject.Find("HairSide").GetComponent<Image>().sprite = maleHairSide;
            femaleButton.interactable = true;
            maleButton.interactable = false;
        }

        this.gender = gender;
    }
}
