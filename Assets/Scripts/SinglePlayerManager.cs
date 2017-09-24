using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SinglePlayerManager : MonoBehaviour {

    public static SinglePlayerManager instance;
    public GameObject mobileStickControl;
    public TextMeshProUGUI scoreText;
    public GameObject startButton;
    public GameObject player;
    public GameObject finishPanel;
    public TextMeshProUGUI finishPanelText;
    public TextMeshProUGUI finishPanelScore;


    private int currentScore = 0;

	// Use this for initialization
	void Start () {

        instance = this;
        scoreText.text = "SCORE: " + currentScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateScore(int newScore)
    {
        currentScore += newScore;
        scoreText.text = "SCORE: " + currentScore.ToString();
    }

    public void OnPlayClicked()
    {
        startButton.SetActive(false);
        mobileStickControl.SetActive(true);
        player.SetActive(true);
        PoolManager.instance.StartGame();
    }

    public void FinishLevel(int i)
    {
        finishPanel.SetActive(true);
        finishPanelScore.text = "SCORE: " + currentScore.ToString();

        int minScore = ((2 * i + 3) * (2 * i + 4) - ((i - 1) * i)) * 2;

        if (minScore <= currentScore)
        {
            finishPanelText.text = "LEVEL COMPLETED";
            if (PlayerPrefs.GetInt("UnlockedLevel") < 3)
                PlayerPrefs.SetInt("UnlockedLevel", ((i + 1) < 3) ? i + 1 : 3);
        }
        else
            finishPanelText.text = "LEVEL FAILED";

    }

    public void OnExitButtonClicked()
    {
        SceneManager.LoadScene("MainScene");
    }
}
