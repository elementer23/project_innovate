using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPartHandler : MonoBehaviour
{

    //False = Male, True = Female.
    // private bool gender = false;

    /*    [SerializeField]
        private Button maleButton;

        [SerializeField]
        private Button femaleButton;*/

    private int[] currentSprites = new int[4];

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
        //Check if there is a next part in the array.
        //If there is, get that part.
        //Also check if there is a part after this.
        //Disable out button if there is not.
    }

    public void previousPart()
    {

    }

    public void selectPart()
    {

    }

   /* public void setGender(bool gender)
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
    }*/
}
