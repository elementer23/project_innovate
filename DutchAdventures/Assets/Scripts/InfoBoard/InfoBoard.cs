using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoBoard : MonoBehaviour
{
    
    public CanvasGroup canvasGroup;
    public string text;
    public TextMeshProUGUI signText;
    public Transform player;
    // Start is called before the first frame update
    private void Update()
    {
        if (canvasGroup != null && canvasGroup.interactable == true)
        {
            player.gameObject.SetActive(false);
        }
        else { 
            player.gameObject.SetActive(true);
        }
    }
    private void OnMouseDown()
    {
        if (canvasGroup.alpha == 0)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            signText.text = text;
        }
        else
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }
}
