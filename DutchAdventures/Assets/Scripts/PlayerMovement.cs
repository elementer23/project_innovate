using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
    public class PlayerMovement : MonoBehaviour
{
<<<<<<< Updated upstream
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;

    // Start is called before the first frame update
=======
    public float speed; //Character movement speed
    private Animator animator;
    private Rigidbody2D myRigidbody;
    private Vector2 change; //Movement vector
    private Vector2 pointToMoveTo; //Point to move towards

>>>>>>> Stashed changes
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        UpdateAnimationAndMove();
    }
    void UpdateAnimationAndMove() 
    {
        if (change != Vector3.zero)
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
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
 

/*
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        UpdateAnimationAndMove();
    }
    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
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
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
*/