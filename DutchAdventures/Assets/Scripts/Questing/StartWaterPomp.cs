using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWaterPomp : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    protected float minDist = 2;
    private bool canObtain = false;
    [SerializeField]
    private GameObject pointer;
    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(player.position, transform.position);
        canObtain = dist < minDist;
        pointer.SetActive(canObtain);
    }

    //Start quest if parameters are true
    private void OnMouseDown()
    {
        if (CanWaterPompGame(canObtain, GetComponent<KeyItemsHandler>().items))
        {
            //player.GetComponent<KeyItemsHandler>().items[keyItem] = true;
            //gameObject.SetActive(false);
        }
    }

    private bool CanWaterPompGame(bool canObtain, Dictionary<string, bool> keyItems)
    {
        if (canObtain)
        {
            int index = 0; 
            foreach (var item in keyItems)
            { 
                Debug.Log(item.Key);
                index++;
            }
        }
        return false;
    }
}
