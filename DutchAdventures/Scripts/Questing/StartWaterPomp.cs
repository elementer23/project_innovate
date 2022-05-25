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
    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = true;
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
        if (HasNeededKeyItems(neededKeyItem1) && HasNeededKeyItems(neededKeyItem2) && canStart)
        {
            SceneManager.LoadScene(2);
        }
    }

    private bool HasNeededKeyItems(string item)
    {
        return player.GetComponent<KeyItemsHandler>().items[item] == true;
    }

}
