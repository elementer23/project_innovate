using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustHandler : MonoBehaviour
{
    private Button currentButton;
    public Image currentImage;
    public FlexibleColorPicker fcp;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateCharacterPart(Button button, Image image)
    {
       // GameObject myEventSystem = GameObject.Find("EventSystem");
       // myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        //currentButton.Select();
        this.currentButton = button;
        this.currentImage = image;
        Color color = image.GetComponent<Image>().color;
        fcp.color = color;
    }
}
