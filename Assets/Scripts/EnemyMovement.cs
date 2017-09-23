using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed;

    private Vector3 endPosition;
    private float angleRot;
    private float angleMove;
    private float sinAngle;
    private float cosAngle;

	// Use this for initialization
	void Start () {

        angleRot = Random.Range(0, 360);
        angleMove = Mathf.Deg2Rad * angleRot;
        sinAngle = Mathf.Sin(angleMove);
        Debug.Log("SIN: " + sinAngle);
        cosAngle = Mathf.Cos(angleMove);
        Debug.Log("COS: " + cosAngle);
        //transform.rotation = Quaternion.AngleAxis(360 - angle, Vector3.up);
        transform.Rotate(new Vector3(0, angleRot - 180, 0));
        //endPosition = new Vector3(Mathf.Cos(angle) * 100, Mathf.Sin(angle) * 100, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(transform.position.x + sinAngle * speed, transform.position.y , transform.position.z + cosAngle * speed);
    }
}
