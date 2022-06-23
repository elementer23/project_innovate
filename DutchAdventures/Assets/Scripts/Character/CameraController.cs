using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private float lerpSpeed = 5;
    [SerializeField]
    private Vector2 minClamp = Vector3.one * -100;
    [SerializeField]
    private Vector2 maxClamp = Vector3.one * 100;

    private void Start()
    {
        //Set the camera position to the position of the player on start.
        //This prevents a jerk of the camera when a scene loads.
        Vector3 playerPos = player.position;
        //The -10 makes the camera be set back a little so the camera is far enough from the scene.
        playerPos.z = -10;
        transform.position = playerPos;
    }

    private void FixedUpdate()
    {
        //Set the camera position to the position of the player every frame.
        Vector3 pointToLerpTo = player.position;

        Vector3 cameraPos = new Vector3(
            Mathf.Clamp(pointToLerpTo.x, minClamp.x, maxClamp.x),
            Mathf.Clamp(pointToLerpTo.y, minClamp.y, maxClamp.y),
            -10
        );

        transform.position = Vector3.Lerp(transform.position, cameraPos, Time.deltaTime * lerpSpeed);
    }
}
