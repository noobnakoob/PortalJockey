using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemies : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // Debug.Log("asd");

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {

                    // BUT IT DOES NOT PRINT OUT HIT AND MORE 

                    if (hit.transform.tag == "Enemy")
                    {
                        Destroy(hit.transform.gameObject);
                    }

                    
                }
            }
        }
    }
}
