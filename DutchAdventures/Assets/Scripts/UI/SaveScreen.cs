using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveScreen : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public Transform player;
    // Start is called before the first frame update
    private void Update()
    {
        //check if there is a canvasgroup and if the interactable of the canvasgroup is true
        if (canvasGroup != null && canvasGroup.interactable == true)
        {
            //if true set the player gameobject to false
            player.gameObject.SetActive(false);
        }
        else
        {
            //if true set the player gameobject to true
            player.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Show savescreen object
    /// </summary>
    public void ShowSaveScreen()
    {
        if (canvasGroup.alpha == 0)
        {
            //show the saveScreen property if the alpha is 0 and the button has been clicked
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            //hide the saveScreen property if the alpha is 1 and the button has been clicked
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }
}
