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
    //Minimum distance between the bush and the player to start showing the pointer and allowing interaction.
    private int minDist = 7;

    //The pointer sprites.
    [SerializeField]
    private Sprite cutterSprite;
    [SerializeField]
    private Sprite pointerSprite;

    [SerializeField]
    private string requiredItem;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pointer = transform.GetChild(0).gameObject;
        canvas = GameObject.FindGameObjectWithTag("Canvas").transform;
    }


    void Update()
    {
        //Check if the player is close enough to the bush.
        float dist = Vector2.Distance(player.transform.position, transform.position);
        if (dist < minDist)
        {
            //If the player has the Hedge Trimmer, update the pointer sprite.
            if(player.GetComponent<KeyItemsSaver>().hasItem(requiredItem))
            {
                pointer.GetComponent<SpriteRenderer>().sprite = cutterSprite;
            } 
            else
            {
                pointer.GetComponent<SpriteRenderer>().sprite = pointerSprite;
            }
        }
        pointer.SetActive(dist < minDist);
    }

    //When the player presses on the NPC,
    private void OnMouseDown()
    {
        //Check if the player is close enough to the bush.
        float dist = Vector2.Distance(player.transform.position, transform.position);
        if (dist > minDist)
        {
            return;
        }

        //If the player does not have the Hedge Trimmer, show dialogue.
        if (!player.GetComponent<KeyItemsSaver>().hasItem(requiredItem))
        {
            addDialog(dialogPrefab, "Questbox(Clone)", "You need a Hedge Trimmer to get through here.");
            return;
        } 
        else
        {
            //If the player does not have the Hedge Trimmer, destroy the bush.
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Generates the dialogue.
    /// </summary>
    /// <param name="prefab">The dialogue box prefab.</param>
    /// <param name="objName">The name of the dialogue box for reuse.</param>
    /// <param name="dialog">The dialogue.</param>
    /// <returns>The dialogue box.</returns>
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
