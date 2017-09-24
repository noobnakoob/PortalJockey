using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {

    public static PoolManager instance;
    public GameObject enemyPrefab;
    public float timer;
    public float spawnTimerDelay;

    private int enemiesNo;
    private float currentTimer;
    private float spawnTimer;
    private GameObject temp;
    private int currentNoOfEnemies = 0;
    private bool isStarted = false;
    private int levelNumber;
    private int waveNumber;
    private int currentWaveNumber = 1;

    // Use this for initialization
    void Start()
    {
        levelNumber = PlayerPrefs.GetInt("LevelNumber");
        waveNumber = 5 + levelNumber - 1;
        enemiesNo = levelNumber;

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted)
        {
            if (currentWaveNumber <= waveNumber)
            {
                if (currentTimer < Time.time)
                {
                    if (spawnTimer < Time.time)
                    {
                        if (currentNoOfEnemies < enemiesNo)
                        {
                            temp = Instantiate(enemyPrefab, transform.position, Quaternion.identity) as GameObject;
                            spawnTimer += spawnTimerDelay;
                            currentNoOfEnemies++;
                        }
                        else
                        {
                            spawnTimer = Time.time + timer;
                            currentTimer += timer;
                            enemiesNo++;
                            currentWaveNumber++;
                            currentNoOfEnemies = 0;
                        }
                    }
                }
            }
            else
            {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                if (enemies.Length == 0)
                    EndGame();
            }
        }
    }

    public void StartGame()
    {
        isStarted = true;
        currentTimer = Time.time;
        spawnTimer = currentTimer + spawnTimerDelay;
    }

    public void EndGame()
    {
        isStarted = false;
        SinglePlayerManager.instance.FinishLevel(levelNumber);
    }
}
