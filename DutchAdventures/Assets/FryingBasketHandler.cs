using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingBasketHandler : MonoBehaviour
{
    [SerializeField]
    private FryingHander handler;
    private SpriteRenderer sr;
    [SerializeField]
    private Sprite rawSprite;
    [SerializeField]
    private Sprite coockedSprite;
    private Animator anim;
    public Camera cam;
    bool hasSnack = false;
    bool isOnFryingpan = false;

    void Start()
    {
        sr = transform.GetChild(0).GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(hasSnack == true)
        {
            Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            transform.position = pos;
        }
    }

    private void OnMouseDown()
    {
        if (handler.hasSnack)
        {
            sr.sprite = rawSprite;
            anim.SetBool("Play", false);
            hasSnack = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "pan1" || collision.collider.name == "pan2")
        {
            isOnFryingpan = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name == "pan1" || collision.collider.name == "pan2")
        {
            isOnFryingpan = true;
        }
    }
}
