using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour {

    Rigidbody myBody;
    public float speed;
    public float rotY;
    bool isHit = false;

	// Use this for initialization
	void Start () {

        myBody = GetComponent<Rigidbody>();
        Quaternion rot = Quaternion.Euler(90, rotY, 0);
        transform.rotation = rot;
        myBody.AddForce(Vector3.forward * Mathf.Cos(rotY * Mathf.Deg2Rad) * speed);
        myBody.AddForce(Vector3.right * Mathf.Sin(rotY * Mathf.Deg2Rad) * speed);
    }

    // Update is called once per frame
    void Update () {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && !isHit)
        {
            other.GetComponent<EnemyMovement>().TakeDamage(40);
            SinglePlayerManager.instance.UpdateScore(1);
            isHit = true;
            Destroy(this.gameObject);
        }
    }
}
