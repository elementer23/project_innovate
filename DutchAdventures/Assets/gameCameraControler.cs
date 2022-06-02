using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameCameraControler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform pomp;
    [SerializeField]
    private Vector2 minClamp = Vector3.one * -100;
    [SerializeField]
    private Vector2 maxClamp = Vector3.one * 100;

    private void Start()
    {
        //Set the camera position to the position of the player on start.
        //This prevents a jerk of the camera when a scene loads.
        Vector3 PompPos = pomp.position;
        //The -10 makes the camera be set back a little so the camera is far enough from the scene.
        PompPos.z = -10;
        transform.position = PompPos;
    }

    private void FixedUpdate()
    {
        //Set the camera position to the position of the player every frame.
        Vector3 pointToLerpTo = pomp.position;

        Vector3 cameraPos = new Vector3(
            Mathf.Clamp(pointToLerpTo.x, minClamp.x, maxClamp.x),
            Mathf.Clamp(pointToLerpTo.y, minClamp.y, maxClamp.y),
            -10
        );
    }
}
