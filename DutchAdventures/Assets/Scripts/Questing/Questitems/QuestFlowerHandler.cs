using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestFlowerHandler : QuestItemHandler
{
    public GameObject flowerContainer;

    [SerializeField]
    private FlowerNPCController flowerNPCcontroller;

    protected override void Start()
    {
        base.Start();
        GetComponent<SpriteRenderer>().enabled = true;
        if (flowerNPCcontroller.hasCompletedQuest || !playerQuestHandler.getQuest().title.Equals("Tulips"))
        {
            pointer.SetActive(false);
        }
    }

    protected override void Update()
    {
        if(flowerNPCcontroller.hasCompletedQuest || !playerQuestHandler.getQuest().title.Equals("Tulips"))
        {
            return;
        }
        float dist = Vector2.Distance(player.position, transform.position);
        canObtain = dist < minDist;
        pointer.SetActive(canObtain);
    }

    //Pickups quest item if the player press down and is in range
    protected override void OnMouseDown()
    {
        if (canObtain)
        {
            //KeyItemsSaver keyItemSaver = player.GetComponent<KeyItemsSaver>();
            //keyItemSaver.setItem("holdingFlower-" + keyItem, true);

            flowerContainer.SetActive(true);
            GameObject ChildGameObject1 = flowerContainer.transform.GetChild(0).gameObject;
            ChildGameObject1.GetComponent<Image>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            flowerNPCcontroller.holdingFlower = keyItem;
        }
    }
}
