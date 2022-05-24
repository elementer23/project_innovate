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
        pointToLerpTo.z = -10;
        transform.position = Vector3.Lerp(transform.position, pointToLerpTo, Time.deltaTime * lerpSpeed);
    }
}
/*
public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            //Zodat de camera niet buiten de scene gaat
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
*/

