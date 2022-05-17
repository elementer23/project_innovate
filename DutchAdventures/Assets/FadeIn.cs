using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    // Start is called before the first frame update

    Renderer renderer;
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Color oldCol = renderer.material.color;
        Color newCol = new Color(oldCol.r, oldCol.g, oldCol.b, oldCol.a - 0.01f);
        renderer.material.color = newCol;
    }

    public float speed = 1f;
    private float _t = 0f;

    void fadeIn()
    {
      //  _t += Time.deltaTime * speed;
      //  gameObject.canvasRenderer.alpha = Mathf.PingPong(_t, 1f);
    }
}
