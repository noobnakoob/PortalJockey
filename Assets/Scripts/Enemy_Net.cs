using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Enemy_Net : NetworkBehaviour
{
    [SerializeField] public float speed;

    private GameObject healthBar;
    private float health = 100;
    private Vector3 endPosition;
    private float angleRot;
    private float angleMove;
    private float sinAngle;
    private float cosAngle;
    private bool isDead = false;

    // Use this for initialization
    void Start()
    {
        healthBar = transform.GetChild(0).gameObject;
        healthBar.GetComponent<MeshRenderer>().material.color = Color.green;
        angleRot = Random.Range(0, 360);
        angleMove = Mathf.Deg2Rad * angleRot;
        sinAngle = Mathf.Sin(angleMove);
        cosAngle = Mathf.Cos(angleMove);
        transform.Rotate(new Vector3(0, angleRot, 0));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isServer)
            return;

        if (health > 0)
        {
            transform.position = new Vector3(transform.position.x + sinAngle * speed, transform.position.y, transform.position.z + cosAngle * speed);
            Vector2 pos = Camera.main.WorldToScreenPoint(this.transform.position);
            if (health > 70)
                healthBar.GetComponent<MeshRenderer>().material.color = Color.green;
            else if (health <= 70 && health > 30)
                healthBar.GetComponent<MeshRenderer>().material.color = Color.yellow;
            else if (health < 30)
                healthBar.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isServer || health <= 0)
            return;

        health -= damage;

        if (health <= 0)
        {
            GetComponent<Animator>().SetBool("isDead", true);
            healthBar.GetComponent<MeshRenderer>().material.color = Color.grey;
            isDead = true;
            //SinglePlayerManager.instance.UpdateScore(5);
            NetworkServer.Destroy(gameObject);
        }
    }
}
