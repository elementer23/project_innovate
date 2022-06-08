using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugScript : MonoBehaviour
{
    [SerializeField]
    private LineRenderer lineRenderer;

    private bool isDragging = false;

    void Update()
    {
        updateRot();

        if (isDragging)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;

            if (pos != Vector3.zero)
            {
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, pos - lineRenderer.transform.position);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            lineRenderer.positionCount++;
        }
    }

    void updateRot()
    {
        Vector2 pos1 = lineRenderer.GetPosition(lineRenderer.positionCount - 1);
        Vector2 pos2 = lineRenderer.GetPosition(lineRenderer.positionCount - 2);
        transform.localPosition = pos1;

        Vector2 diff = pos1 - pos2;

        float theta = Mathf.Atan2(diff.y, diff.x);
        float angle = theta * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 180);
    }

    private void OnMouseDown()
    {
        isDragging = !isDragging;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "ElectricityBox")
        {
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, collision.transform.position - lineRenderer.transform.position - new Vector3(0, 0.5f, 0));
            isDragging = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
