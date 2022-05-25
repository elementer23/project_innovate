using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoBoard : MonoBehaviour
{
    
    public CanvasGroup canvasGroup;
    public string text;
    public TextMeshProUGUI signText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void SignMenuClose()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
