using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerFire_Net : NetworkBehaviour {

    public GameObject missile;
    public Transform missilePosition;
    public float power;

    private float shootTimer;

	// Use this for initialization
	void Start () {

        shootTimer = Time.time + 0.5f;
	}
	
	// Update is called once per frame
	void Update () {

        if (!isLocalPlayer)
            return;

        if (shootTimer < Time.time)
        {
            CmdFireMissile();
            shootTimer += 0.5f;
        }
	}

    [Command]
    void CmdFireMissile()
    {
        GameObject instance = Instantiate(missile, missilePosition.position, missilePosition.rotation) as GameObject;
        instance.GetComponent<Rigidbody>().AddForce(missilePosition.forward * power);

        NetworkServer.Spawn(instance);
    }
}
