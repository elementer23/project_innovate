using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushHandler : MonoBehaviour
{

    [SerializeField]
    private GameObject dialogPrefab;
    private Transform canvas;
    private GameObject pointer;
    [SerializeField]
    private Transform player;
    private int minDist = 7;

    [SerializeField]
    private Sprite cutterSprite;
    [SerializeField]
    private Sprite pointerSprite;

    [SerializeField]
    private string requiredItem;

    public bool hasRequiredItem;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pointer = transform.GetChild(0).gameObject;
        canvas = GameObject.FindGameObjectWithTag("Canvas").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(player.position, transform.position);
        if(dist < minDist)
        {
            if(player.GetComponent<KeyItemsSaver>().hasItem(requiredItem))
            {
                pointer.GetComponent<SpriteRenderer>().sprite = cutterSprite;
            } else
            {
                pointer.GetComponent<SpriteRenderer>().sprite = pointerSprite;
            }
        }
        pointer.SetActive(dist < minDist);
    }

    //When the player presses on the NPC,
    private void OnMouseDown()
    {
        float dist = Vector2.Distance(player.transform.position, transform.position);
        if (dist > minDist)
        {
            return;
        }

        if (!player.GetComponent<KeyItemsSaver>().hasItem(requiredItem))
        {
            addDialog(dialogPrefab, "Questbox(Clone)", "You need a Hedge Trimmer to get through here.");
            return;
        } else
        {
            //Has cutter.
            Destroy(gameObject);
        }
    }

    protected GameObject addDialog(GameObject prefab, string objName, string dialog)
    {
        if (!canvas.Find(objName))
        {
            GameObject obj = Instantiate(prefab, canvas);
            DialogHandler dhandler = obj.GetComponent<DialogHandler>();

            dhandler.dialog = dialog;
            return obj;
        }
        return null;
    }

}
