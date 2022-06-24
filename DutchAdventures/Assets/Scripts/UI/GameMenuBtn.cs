using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuBtn : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public Transform player;

    /// <summary>
    /// Set the player object to non active when conditions are met
    /// </summary>
    void Update()
    {
        
        if (canvasGroup != null && canvasGroup.interactable == true)
        {
            player.gameObject.SetActive(false);
        }
        else
        {
            player.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// show the game menu when alpha = 0 or hide it when alpha = 1
    /// </summary>
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
