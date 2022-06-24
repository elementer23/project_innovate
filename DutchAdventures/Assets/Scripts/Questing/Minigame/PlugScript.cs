using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugScript : MonoBehaviour
{
    [SerializeField]
    private LineRenderer lineRenderer;

    private KeyItemsSaver keyItemsSaver;

    private bool isDragging = false;

    public float maxLength = 1;
    public string reward;

    public NPCController npc;

    [SerializeField]
    private Animator questComplete;

    [SerializeField]
    private Gradient normalGradient;
    [SerializeField]
    private Gradient disabledGradient;

    private bool canDrag;

    private void Start()
    {
        //Zoek de key items saver
        keyItemsSaver = GameObject.FindGameObjectWithTag("Player").GetComponent<KeyItemsSaver>();
    }
    /// <summary>
    /// This function calculates the position and rotation of the end of the plug
    /// </summary>
    void updatePosRot()
    {
        //Get the last 2 positions form the lineRenderer
        Vector2 pos1 = lineRenderer.GetPosition(lineRenderer.positionCount - 1);
        Vector2 pos2 = lineRenderer.GetPosition(lineRenderer.positionCount - 2);

        //Update the plugs position
        transform.localPosition = pos1;

        //Calculate the difference between the 2 positions
        Vector2 diff = pos1 - pos2;
        //Calculate the angle from the difference of the 2 positions (in radians)
        float theta = Mathf.Atan2(diff.y, diff.x);
        //Convert radians to degreed
        float angle = theta * Mathf.Rad2Deg;
        //Set the angle of the plug to the calculated angle
        transform.rotation = Quaternion.Euler(0, 0, angle + 180);

        if (isDragging)
        {
            //Get the finger/mouse position relative to the lineRenderer
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lineRenderer.transform.position;
            pos.z = 0;

            //Calculate the distance
            //Using square magnitude in onder to safe processing power
            //(normal magnitude and distance use a square root, which is intensive to repeat often).
            float sqrMag = ((Vector2)pos - pos2).sqrMagnitude;

            //Compare sqrMag (afstand²) with maxLength²
            if (sqrMag > maxLength * maxLength)
            {
                //Add a vertex to the lineRenderer
                lineRenderer.positionCount++;
            }

            //Update the lineRenderers end to the finger/mouse position
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, pos);
        }
    }

    private void Update()
    {
        //Change the alpha of the cable components when the quest is completed or not
        bool disable = npc.hasCompletedQuest || !npc.hasAccepted;
        float val = disable ? 0.5f : 1f;

        Color col = GetComponent<SpriteRenderer>().color;
        col.a = val;
        GetComponent<SpriteRenderer>().color = col;

        transform.parent.GetComponent<LineRenderer>().colorGradient = (val == 1) ? normalGradient : disabledGradient;

        col = transform.parent.parent.GetComponent<SpriteRenderer>().color;
        col.a = val;
        transform.parent.parent.GetComponent<SpriteRenderer>().color = col;

        //Look if the player can drag the plug according to if the quest is done / accepted or not
        canDrag = !npc.hasCompletedQuest && npc.hasAccepted;
    }

    private void OnMouseDown()
    {
        if (canDrag)
        {
            isDragging = true;
        }
    }
    /// <summary>
    /// Update the pos / rot when dragging
    /// </summary>
    private void OnMouseDrag()
    {
        if (canDrag)
        {
            updatePosRot();
        }
    }

    private void OnMouseUp()
    {
        if (canDrag)
        {
            isDragging = false;
        }
    }

    /// <summary>
    /// This function completes the quest when the plug is touching the electricity box
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "ElectricityBox")
        {
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, collision.transform.position - lineRenderer.transform.position - new Vector3(0, 0.5f, 0));
            isDragging = false;
            keyItemsSaver.setItem(reward, true);
            GetComponent<BoxCollider2D>().enabled = false;
            questComplete.SetTrigger("Play");
        }
    }
}
