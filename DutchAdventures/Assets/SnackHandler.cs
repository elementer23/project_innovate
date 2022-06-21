using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnackHandler : MonoBehaviour
{
    public FryingHander handler;
    private Animator animator;
    [SerializeField]
    private Animator fryingPanAnim;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Play", true);
    }

    private void OnMouseDown()
    {
        handler.hasSnack = true;
        fryingPanAnim.SetBool("Play", true);
        Destroy(gameObject);
    }
}
