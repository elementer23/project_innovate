using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float speed; //Character movement speed

    private Animator animator;
    private Rigidbody2D myRigidbody;

    private Vector2 change; //Movement vector
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
            //Cast a ray from the camera out towards the ground.
            RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            
            //Check if the mouse is not over any UI element
            bool isOverUI = EventSystem.current.IsPointerOverGameObject();

            //If the object hit by the ray is of the "Ground" tag and the mouse is not over UI
            if (hit)
            {
                Debug.Log("test");
                if (hit.transform.tag == "Ground" && !isOverUI)
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
    

    private void FixedUpdate()
    {
        UpdateAnimationAndMove();
    }

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

    void MoveCharacter()
    {
        myRigidbody.MovePosition(myRigidbody.position + change.normalized * speed * Time.deltaTime);
    }
}
