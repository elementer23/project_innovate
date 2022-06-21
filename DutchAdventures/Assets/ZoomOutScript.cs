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
