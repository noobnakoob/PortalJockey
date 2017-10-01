using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

    public float moveForce = 5;
    public GameObject missile;
    public GameObject ac_camera;
    public Transform missilePosition;

    Rigidbody myBody;
    private float axisHoriz;
    private float axisVert;
    private float lastAngle = 0;
    private Vector3 terrainRotation;
    private float terrainRotationY;

	// Use this for initialization
	void Start () {

        myBody = GetComponent<Rigidbody>();
        InvokeRepeating("SpawnMissile", 1f, 0.5f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        axisHoriz = CrossPlatformInputManager.GetAxis("Horizontal");
        axisVert = CrossPlatformInputManager.GetAxis("Vertical");
        
        terrainRotation = ac_camera.transform.rotation.eulerAngles;
        terrainRotationY =(terrainRotation.y - terrainRotation.z + terrainRotation.x);

        float angle = -Mathf.Rad2Deg * Mathf.Atan2(axisVert, axisHoriz) + terrainRotationY;
        transform.rotation = Quaternion.Euler(0, terrainRotation.y, 0);
        lastAngle = terrainRotation.y;

        if (!(Mathf.Abs(axisHoriz) < 0.5f && Mathf.Abs(axisVert) < 0.5f))
        {
            myBody.AddForce(Vector3.forward * Mathf.Cos(angle * Mathf.Deg2Rad) * moveForce * Mathf.Abs(axisHoriz));
            myBody.AddForce(Vector3.right * Mathf.Sin(angle * Mathf.Deg2Rad) * moveForce * Mathf.Abs(axisVert));
        }
    }

    private void SpawnMissile()
    {
        GameObject temp = Instantiate(missile, missilePosition.position, missile.transform.rotation) as GameObject;
        temp.GetComponent<MissileMovement>().rotY = lastAngle;
    }
}
