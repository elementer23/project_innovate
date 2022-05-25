using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartWaterPomp : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    protected float minDist = 2;
    private bool canStart = false;
    public int buildIndex;
    [SerializeField]
    private GameObject pointer;
    public string neededKeyItem1;
    public string neededKeyItem2;
    private KeyItemsHandler keyItemsHandler;

    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = true;
        keyItemsHandler = player.GetComponent<KeyItemsHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(player.position, transform.position);
        canStart = dist < minDist;
        pointer.SetActive(canStart);
    }

    //Start quest if parameters are true
    private void OnMouseDown()
    {
        if (keyItemsHandler.hasItem(neededKeyItem1) && keyItemsHandler.hasItem(neededKeyItem2) && canStart)
        {
            SceneManager.LoadScene(2);
        }
    }
}
