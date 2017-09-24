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

    // Use this for initialization
    void Start()
    {
        if (!isLocalPlayer)
        {
            Destroy(this);
            return;
        }

        myBody = GetComponent<Rigidbody>();
        //InvokeRepeating("SpawnMissile", 1f, 0.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        axisHoriz = CrossPlatformInputManager.GetAxis("Horizontal");
        axisVert = CrossPlatformInputManager.GetAxis("Vertical");

        float angle = -Mathf.Rad2Deg * Mathf.Atan2(axisVert, axisHoriz);

        if (!(Mathf.Abs(axisHoriz) < 0.1f && Mathf.Abs(axisVert) < 0.1f))
        {
            transform.rotation = Quaternion.Euler(0, angle, 0);
            lastAngle = angle;
        }

        if (!(Mathf.Abs(axisHoriz) < 0.5f && Mathf.Abs(axisVert) < 0.5f))
        {
            myBody.AddForce(Vector3.forward * Mathf.Cos(angle * Mathf.Deg2Rad) * moveForce * Mathf.Abs(axisHoriz));
            myBody.AddForce(Vector3.right * Mathf.Sin(angle * Mathf.Deg2Rad) * moveForce * Mathf.Abs(axisVert));
        }
    }

    //private void SpawnMissile()
    //{
    //    GameObject temp = Instantiate(missile, missilePosition.position, missile.transform.rotation) as GameObject;
    //    temp.GetComponent<MissileMovement>().rotY = lastAngle;
    //}
}
