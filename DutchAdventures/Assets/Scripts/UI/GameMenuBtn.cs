using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuBtn : MonoBehaviour
{

    public CanvasGroup canvasGroup;
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        //set the player object to non active when conditions are met
        if (canvasGroup != null && canvasGroup.interactable == true)
        {
            player.gameObject.SetActive(false);
        }
        else
        {
            player.gameObject.SetActive(true);
        }
    }

    //show the game menu when alpha = 0 or hide it when alpha = 1
    public void ShowGameMenu()
    {
        if (canvasGroup.alpha == 0)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        } 
            
    }
}
