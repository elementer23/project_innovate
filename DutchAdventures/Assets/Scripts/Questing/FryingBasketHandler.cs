using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FryingBasketHandler : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private GameObject particles;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Image sliderImg;
    [SerializeField]
    private Animator completeBtn;
    [SerializeField]
    private GameObject backbtn;
    [SerializeField]
    private GameObject world;
    [SerializeField]
    private GameObject minigame;

    private SpriteRenderer sr;
    private Animator anim;

    [SerializeField]
    private Sprite rawSprite;
    [SerializeField]
    private Sprite cookedSprite;
    [SerializeField]
    private Sprite downSprite;
    [SerializeField]
    private Gradient sliderColors;
    [SerializeField]
    private BoxCollider2D tableCol;

    [SerializeField]
    public bool hasSnack = false;
    [SerializeField]
    private bool isHolding = false;
    [SerializeField]
    bool isOverFryingpan = false;
    [SerializeField]
    bool isDoneFrying = false;

    [SerializeField]
    private float timer;
    [SerializeField]
    private float timeToBake = 5;

    bool hasCompleted;

    void Start()
    {
        sr = transform.GetChild(0).GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        tableCol.enabled = false;
        backbtn.SetActive(false);
    }

    void Update()
    {
        //If the plyer is holding the pan:
        if (isHolding == true)
        {
            //Move the pan according to the players finger position
            Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            transform.position = pos;

            //Change the sprite to make the pan fry
            if (isOverFryingpan)
            {
                sr.sprite = downSprite;
            }
            else
            {
                sr.sprite = rawSprite;
            }
        }

        //When not done frying:
        if (!isDoneFrying)
        {
            //Increase the timer is the player is holding the pan over the fryer
            if (isOverFryingpan)
            {
                timer += Time.deltaTime;
                if (timer < timeToBake)
                {
                    slider.value = timer / timeToBake;
                }
            }
            //Else reset the timer
            else
            {
                timer = 0;
                slider.value = 0;
            }
        }
        //if the pan is done, make the sprite a cooked item
        else
        {
            sr.sprite = cookedSprite;
        }

        //Set the slider active when over the fryer
        slider.gameObject.SetActive(isOverFryingpan);

        //Set the color of the slider according to it's value
        sliderImg.color = sliderColors.Evaluate(slider.value);

        //Activate the particles when frying
        particles.SetActive(isOverFryingpan && !isDoneFrying);

        //Activate the back button when done
        backbtn.SetActive(isDoneFrying && !isHolding);

        //Enable the table collider
        isDoneFrying = timer >= timeToBake;
        tableCol.enabled = isDoneFrying;

        if (isDoneFrying && !hasCompleted)
        {
            completeBtn.SetTrigger("Play");
            hasCompleted = true;
        }
    }

    /// <summary>
    /// When clicked on the pan, change the sprites
    /// </summary>
    private void OnMouseDown()
    {
        if (hasSnack && !isDoneFrying)
        {
            sr.sprite = rawSprite;
            anim.SetBool("Play", false);
            isHolding = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "PanHitbox")
        {
            isOverFryingpan = true;
        }
        else if (collision.collider.name == "Table")
        {
            isHolding = false;
            transform.position = new Vector2(-1.375f, 0.37f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name == "PanHitbox")
        {
            isOverFryingpan = false;
        }
    }
    /// <summary>
    /// Returns to world after completion mini game
    /// </summary>
    public void backToWorld()
    {
        world.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<KeyItemsSaver>().setItem("Frikandel", true);
    }
}
