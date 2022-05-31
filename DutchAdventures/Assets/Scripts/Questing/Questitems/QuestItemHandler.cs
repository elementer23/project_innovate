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

    // Check if player is in distance of object to pick it up
    void Update()
    {
        float dist = Vector2.Distance(player.position, transform.position);
        canObtain = dist < minDist;
        pointer.SetActive(canObtain);
    }

    // unity bugg where the boxcolider needs reset
    private void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    //Pickups quest item if the player press down and is in range
    private void OnMouseDown()
    {
        if (canObtain)
        {
            StartCoroutine(Testcor());
            //player.GetComponent<KeyItemsHandler>().setItem(keyItem, true);
            //player.GetComponent<JsonWriter>().WriteJson();
            //Debug.Log("Updated JSON file");
            //gameObject.SetActive(false);
        }
    }

    IEnumerator Testcor()
    {
        player.GetComponent<KeyItemsHandler>().setItem(keyItem, true);
        yield return new WaitForSeconds(0.1f);
        player.GetComponent<JsonWriter>().WriteJson();
        Debug.Log("Updated item JSON: " + keyItem + " = true");
        gameObject.SetActive(false);
    }
}
