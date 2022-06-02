using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PompMotionControl : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    private GameObject world;
    private GameObject mingame;

    private void Awake()
    {
        world = GameObject.Find("World");
        mingame = GameObject.Find("Minigame");
}
    void Start()
    {
        world.SetActive(false);
        mingame.SetActive(true);
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        switchScene();
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            //Check if the mouse is not over any UI 
            animator.SetTrigger("isTouched");
            animator.SetInteger("amountOfPomps", animator.GetInteger("amountOfPomps") + 1);
        }
    }
    private bool isOverUI()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return true;
        }
        if (Input.touchCount > 0)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                return true;
            }
        }

        return false;
    }

    private void switchScene() {
        if (animator.GetInteger("amountOfPomps") == 10)
        {
            world.SetActive(false);
            mingame.SetActive(true);
        }
       
    }
}
