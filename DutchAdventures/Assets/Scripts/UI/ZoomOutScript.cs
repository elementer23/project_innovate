using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomOutScript : MonoBehaviour
{
    private bool isZoomedOut;

    [SerializeField]
    private Image spriteRenderer;
    [SerializeField]
    private Sprite zoomInSprite;
    [SerializeField]
    private Sprite zoomOutSprite;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private int zoom = 15;
    [SerializeField]
    float lerpDuration = 1;

    /// <summary>
    /// Zoom the camm smooth out to bigger view
    /// </summary>
    /// <param name="start">Start position</param>
    /// <param name="end">End position</param>
    /// <returns>makes view bigger</returns>
    IEnumerator Lerp(float start, float end)
    {
        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            cam.orthographicSize = Mathf.Lerp(start, end, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        cam.orthographicSize = end;
    }

    /// <summary>
    /// Ben btn is pressed and zoom is out then zoom in other zoom out
    /// </summary>
    public void btn()
    {
        if (isZoomedOut)
        {
            StartCoroutine(Lerp(zoom, 5));
            spriteRenderer.sprite = zoomOutSprite;
            isZoomedOut = false;
        }
        else
        {
            StartCoroutine(Lerp(5, zoom));
            spriteRenderer.sprite = zoomInSprite;
            isZoomedOut = true;
        }
    }
}
