using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float speed; //Character movement speed

    private Animator animator;
    private Rigidbody2D myRigidbody;

    [HideInInspector]
    public Vector2 change; //Movement vector
    private Vector2 pointToMoveTo; //Point to move towards

    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Check if the mouse is not over any UI element
            bool overUI = isOverUI();

            //Cast a ray from the camera out towards the ground.
            RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

            //If the object hit by the ray is of the "Ground" tag and the mouse is not over UI
            if (hit)
            {
                if (hit.transform.tag == "Ground" && !overUI)
                {
                    //Set the point to move towards to the point where the ray hit
                    pointToMoveTo = hit.point;
                    change = pointToMoveTo - myRigidbody.position;
                }
            }

        }

        //If the distance to the pointToMoveTo is more then 0.1f: move
        //This prevents the player from jittering when arriving at the pointToMoveTo
        if (change.sqrMagnitude > 0.1f)
        {
            change = pointToMoveTo - myRigidbody.position;
        }
        else
        {
            change = Vector2.zero;
        }
    }

    /// <summary>
    /// Check if input is on the UI object
    /// </summary>
    /// <returns>True or false</returns>
    private bool isOverUI()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return true;
        }
        if(Input.touchCount > 0)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                return true;
            }
        }

        return false;
    }

    private void FixedUpdate()
    {
        UpdateAnimationAndMove();
    }

    /// <summary>
    /// Update movement trough the scene
    /// </summary>
    void UpdateAnimationAndMove()
    {
        if (change != Vector2.zero)
        {
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
            MoveCharacter();
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
    /// <summary>
    /// Move the character on the Tilemap
    /// </summary>
    void MoveCharacter()
    {
        myRigidbody.MovePosition(myRigidbody.position + change.normalized * speed * Time.deltaTime);
    }
}
