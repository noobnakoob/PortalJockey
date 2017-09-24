using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

    public GameObject[] levels;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("UnlockedLevel"))
            PlayerPrefs.SetInt("UnlockedLevel", 1);

        for (int i = 0; i < levels.Length; i++)
        {
            if (i + 1 <= PlayerPrefs.GetInt("UnlockedLevel"))
            {
                levels[i].GetComponent<Button>().interactable = true;
                levels[i].transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                levels[i].GetComponent<Button>().interactable = false;
                levels[i].transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    public void OnLevelButtonClicked(int level)
    {
        PlayerPrefs.SetInt("LevelNumber", level);
        SceneManager.LoadScene("SinglePlayer");
    }

    public void OnMultiPlayerButtonClicked()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
