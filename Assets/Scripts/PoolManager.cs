using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {

    public static PoolManager instance;

    public GameObject enemyPrefab;
    public float timer;
    public float spawnTimerDelay;

    private int enemiesNo = 5;
    private float currentTimer;
    private float spawnTimer;
    private GameObject temp;
    private int currentNoOfEnemies = 0;
    private bool isStarted = false;

    // Use this for initialization
    void Start() {

        instance = this;
    }

    // Update is called once per frame
    void Update() {

        if (isStarted)
        {
            if (currentTimer < Time.time)
            {
                if (spawnTimer < Time.time)
                {
                    if (currentNoOfEnemies < enemiesNo)
                    {
                        Debug.Log("Instantiate");
                        temp = Instantiate(enemyPrefab, transform.position, Quaternion.identity) as GameObject;
                        spawnTimer += spawnTimerDelay;
                        currentNoOfEnemies++;
                    }
                    else
                    {
                        spawnTimer = Time.time + timer;
                        currentTimer += timer;
                        enemiesNo++;
                        currentNoOfEnemies = 0;
                    }
                }
            }
        }
    }

    public void StartGame()
    {
        isStarted = true;
        currentTimer = Time.time;
        spawnTimer = currentTimer + spawnTimerDelay;
    }
}
