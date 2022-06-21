using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingHander : MonoBehaviour
{
    public GameObject fryParticles;

    bool hasSnack = false;
    bool basBasket = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
            if (hit.transform.name == "FryingBasket")
            {
                basBasket = true;
                Destroy(hit.transform.gameObject);
            }
            else if (hit.transform.name == "Pan 1" || hit.transform.name == "Pan 2")
            {

            }
            else if (hit.transform.name == "Snacks")
            {
                hasSnack = true;
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
