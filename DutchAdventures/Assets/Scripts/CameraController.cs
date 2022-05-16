using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float lerpSpeed = 5;

    private void Start()
    {
        Vector3 playerPos = player.position;
        playerPos.z = -10;
        transform.position = playerPos;
    }

    private void FixedUpdate()
    {
        Vector3 pointToLerpTo = player.position;
        pointToLerpTo.z = -10;
        transform.position = Vector3.Lerp(transform.position, pointToLerpTo, Time.deltaTime * lerpSpeed);
    }
}
