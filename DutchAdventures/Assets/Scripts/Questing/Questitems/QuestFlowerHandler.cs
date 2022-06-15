using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestFlowerHandler : QuestItemHandler
{


    //Pickups quest item if the player press down and is in range
    protected override void OnMouseDown()
    {
        if (canObtain)
        {
            if (isVisible)
            {
                KeyItemsSaver keyItemSaver = player.GetComponent<KeyItemsSaver>();
                keyItemSaver.setItem(keyItem, true);
                UIFlowerContainer.SetActive(true);
                UIFlowerImage.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
    
            }
        }
    }
}
