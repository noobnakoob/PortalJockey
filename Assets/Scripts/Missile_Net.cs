using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Missile_Net : NetworkBehaviour
{
    bool isHit = false;

    private void OnTriggerEnter(Collider other)
    {
        if(!isServer)
            return;

        if (other.tag == "Enemy" && !isHit)
        {
            Enemy_Net enemy = other.gameObject.GetComponent<Enemy_Net>();

            if (enemy != null)
                enemy.TakeDamage(40);

            //other.GetComponent<EnemyMovement>().TakeDamage(40);
            //SinglePlayerManager.instance.UpdateScore(1);
            isHit = true;
            NetworkServer.Destroy(this.gameObject);
        }
    }
}
