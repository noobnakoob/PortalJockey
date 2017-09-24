using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour {

    private GameObject[] enemies;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            Destroy(other.gameObject);
    }
}
