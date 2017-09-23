using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour {

    public GameObject mainPanel;
    public GameObject gamePanel;


	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnSinglePlayerButtonClicked()
    {
        mainPanel.SetActive(false);
        PoolManager.instance.StartGame();
    }

    public void OnMultiPlayerButtonClicked()
    {
        mainPanel.SetActive(false);
    }

    public void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
