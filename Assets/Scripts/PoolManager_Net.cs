using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PoolManager_Net : NetworkBehaviour
{
    [SerializeField] public GameObject enemyPrefab;

    private int numberOfPlayers;
    private int numberOfEnemies;
    private int currentNoOfEnemies = 0;
    private float spawnTimer;
    private float spawnTimerDelay = 1;
    private float currentTimer;
    private float timer = 10;
    private GameObject temp;

    // Use this for initialization
    void Start()
    {
        numberOfPlayers = Network.connections.Length;
        numberOfEnemies = numberOfPlayers;
        currentTimer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isServer)
            return;

        if (currentTimer < Time.time)
        {
            if (spawnTimer < Time.time)
            {
                if (currentNoOfEnemies < numberOfEnemies)
                {
                    temp = Instantiate(enemyPrefab, transform.position, Quaternion.identity) as GameObject;
                    NetworkServer.Spawn(temp);
                    spawnTimer += spawnTimerDelay;
                    currentNoOfEnemies++;
                }
                else
                {
                    spawnTimer = Time.time + timer;
                    currentTimer += timer;
                    numberOfEnemies++;
                    currentNoOfEnemies = 0;
                }
            }
        }
    }
}
