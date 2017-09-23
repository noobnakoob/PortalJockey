using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed;

    private Vector3 endPosition;
    private float angle;
    private float sinAngle;
    private float cosAngle;

	// Use this for initialization
	void Start () {

        angle = Random.Range(0, 360);
        sinAngle = Mathf.Sin(angle);
        cosAngle = Mathf.Cos(angle);
        //endPosition = new Vector3(Mathf.Cos(angle) * 100, Mathf.Sin(angle) * 100, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(transform.position.x + cosAngle * speed, transform.position.y , transform.position.z + sinAngle * speed);
    }
}
