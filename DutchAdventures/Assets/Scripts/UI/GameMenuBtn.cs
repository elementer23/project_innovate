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
        if (canvasGroup != null && canvasGroup.interactable == true)
        {
            player.gameObject.SetActive(false);
        }
        else
        {
            player.gameObject.SetActive(true);
        }
    }

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
