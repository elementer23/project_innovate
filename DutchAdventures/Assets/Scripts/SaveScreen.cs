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
        if (canvasGroup != null && canvasGroup.interactable == true)
        {
            player.gameObject.SetActive(false);
        }
        else
        {
            player.gameObject.SetActive(true);
        }
    }

    public void ShowSaveScreen()
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
