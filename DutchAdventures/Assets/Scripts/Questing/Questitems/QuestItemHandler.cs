using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItemHandler : MonoBehaviour
{
    public Transform player;
    protected float minDist = 2;
    private bool canObtain = false;
    [SerializeField]
    private GameObject pointer;
    public string keyItem;

    private void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    void Update()
    {
        float dist = Vector2.Distance(player.position, transform.position);
        canObtain = dist < minDist;
        pointer.SetActive(canObtain);
    }

    //Pickups quest item if the player press down and is in range
    private void OnMouseDown()
    {
        if (canObtain)
        {
            //StartCoroutine(Testcor());
            KeyItemsSaver keyItemSaver = player.GetComponent<KeyItemsSaver>();
            keyItemSaver.setItem(keyItem, true);
            keyItemSaver.SaveItems();

            gameObject.SetActive(false);
            //player.GetComponent<KeyItemsHandler>().setItem(keyItem, true);
            //player.GetComponent<JsonWriter>().WriteJson();
            //gameObject.SetActive(false);
        }
    }

    //IEnumerator Testcor()
    //{
    //    player.GetComponent<KeyItemsHandler>().setItem(keyItem, true);
    //    yield return new WaitForSeconds(0.1f);
    //    player.GetComponent<keyItemsSaver>().WriteJson();
    //    gameObject.SetActive(false);
    //}
}
