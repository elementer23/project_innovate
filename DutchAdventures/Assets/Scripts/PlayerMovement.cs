using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector2 change;
    private Animator animator;

    private Vector2 pointToMoveTo;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            
            if(hit.transform.tag == "Ground")
            {
                pointToMoveTo = hit.point;
                change = pointToMoveTo - myRigidbody.position;
            }
        }
        
        if (change.sqrMagnitude > 0.1f)
        {
            change = pointToMoveTo - myRigidbody.position;
        } else
        {
            change = Vector2.zero;
        }

        //change.x = Input.GetAxisRaw("Horizontal");
        //change.y = Input.GetAxisRaw("Vertical");
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
