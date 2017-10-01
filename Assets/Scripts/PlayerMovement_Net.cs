using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;

public class PlayerMovement_Net : NetworkBehaviour
{
    public float moveForce = 5;
    //public GameObject missile;
    //public Transform missilePosition;

    Rigidbody myBody;
    private float axisHoriz;
    private float axisVert;
    private float lastAngle = 0;


    private Vector3 terrainRotation;
    private float terrainRotationY;

    // Use this for initialization
    void Start()
    {
        if (!isLocalPlayer)
        {
            Destroy(this);
            return;
        }

        myBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        axisHoriz = CrossPlatformInputManager.GetAxis("Horizontal");
        axisVert = CrossPlatformInputManager.GetAxis("Vertical");

        terrainRotation = GameObject.Find("ARCamera").transform.rotation.eulerAngles;
        terrainRotationY = (terrainRotation.y - terrainRotation.z + terrainRotation.x);

        float angle = -Mathf.Rad2Deg * Mathf.Atan2(axisVert, axisHoriz) + terrainRotationY;
        transform.rotation = Quaternion.Euler(0, terrainRotation.y, 0);
        lastAngle = terrainRotation.y;

        if (!(Mathf.Abs(axisHoriz) < 0.5f && Mathf.Abs(axisVert) < 0.5f))
        {
            myBody.AddForce(Vector3.forward * Mathf.Cos(angle * Mathf.Deg2Rad) * moveForce * Mathf.Abs(axisHoriz));
            myBody.AddForce(Vector3.right * Mathf.Sin(angle * Mathf.Deg2Rad) * moveForce * Mathf.Abs(axisVert));
        }
    }
}
