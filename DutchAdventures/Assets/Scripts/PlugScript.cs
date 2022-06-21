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
        keyItemsSaver = GameObject.FindGameObjectWithTag("Player").GetComponent<KeyItemsSaver>();
    }

    void updatePosRot()
    {
        Vector2 pos1 = lineRenderer.GetPosition(lineRenderer.positionCount - 1);
        Vector2 pos2 = lineRenderer.GetPosition(lineRenderer.positionCount - 2);
        transform.localPosition = pos1;

        Vector2 diff = pos1 - pos2;

        float theta = Mathf.Atan2(diff.y, diff.x);
        float angle = theta * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 180);

        if (isDragging)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lineRenderer.transform.position;
            pos.z = 0;

            float sqrMag = ((Vector2)pos - pos2).sqrMagnitude;

            if (sqrMag > maxLength * maxLength)
            {
                lineRenderer.positionCount++;
            }

            lineRenderer.SetPosition(lineRenderer.positionCount - 1, pos);
        }
    }

    private void Update()
    {
        bool disable = npc.hasCompletedQuest || !npc.hasAccepted;
        float val = disable ? 0.5f : 1f;

        Color col = GetComponent<SpriteRenderer>().color;
        col.a = val;
        GetComponent<SpriteRenderer>().color = col;

        Gradient grad = transform.parent.GetComponent<LineRenderer>().colorGradient;
        transform.parent.GetComponent<LineRenderer>().colorGradient = (val == 1) ? normalGradient : disabledGradient;

        col = transform.parent.parent.GetComponent<SpriteRenderer>().color;
        col.a = val;
        transform.parent.parent.GetComponent<SpriteRenderer>().color = col;

        canDrag = !npc.hasCompletedQuest && npc.hasAccepted;
    }

    private void OnMouseDown()
    {
        if (canDrag)
        {
            isDragging = true;
        }
    }

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
