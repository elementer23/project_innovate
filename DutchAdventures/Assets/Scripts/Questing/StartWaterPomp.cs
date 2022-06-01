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
    public string minigameName;
    [SerializeField]
    private GameObject pointer;
    public string neededKeyItem1;
    public string neededKeyItem2;
    private KeyItemsSaver keyItemsSaver;

    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = true;
        keyItemsSaver = player.GetComponent<KeyItemsSaver>();
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
        if (keyItemsSaver.hasItem(neededKeyItem1) && keyItemsSaver.hasItem(neededKeyItem2) && canStart)
        {
            GameObject.Find("World").SetActive(false);
            GameObject.Find(minigameName).SetActive(true);
        }
    }
}
