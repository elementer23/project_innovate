using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiHandler : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    // Start is called before the first frame update

    //click this button to close the menu
    public void SignMenuClose()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        Debug.Log("Closing menu");
    }
}
