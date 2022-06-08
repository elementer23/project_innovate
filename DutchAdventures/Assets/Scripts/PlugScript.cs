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

    private void Start()
    {
        keyItemsSaver = GameObject.FindGameObjectWithTag("Player").GetComponent<KeyItemsSaver>();
    }

    void Update()
    {
        updatePosRot();
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
            Debug.Log(sqrMag);
            if (sqrMag > maxLength * maxLength)
            {
                lineRenderer.positionCount++;
            }

            lineRenderer.SetPosition(lineRenderer.positionCount - 1, pos);
        }
    }

    private void OnMouseDown()
    {
        if (npc.hasAccepted)
        {
            isDragging = !isDragging;
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
        }
    }
}
