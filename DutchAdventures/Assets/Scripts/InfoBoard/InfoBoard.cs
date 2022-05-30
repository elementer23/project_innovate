using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoBoard : MonoBehaviour
{
    
    public CanvasGroup canvasGroup;
    public string text;
    private int minDist = 2;
    [SerializeField]
    private GameObject pointer;
    public Transform player;
    public bool canTouch = false;
    public TextMeshProUGUI signText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(player.position, transform.position);
        canTouch = dist < minDist;
        pointer.SetActive(canTouch);
    }

    private void OnMouseDown()
    {
        if (canTouch)
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

    public void SignMenuClose()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
