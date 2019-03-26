using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    public GameObject pauseMenu;
    public GameObject endMenu;
    public Text endTimerText;
    public Text timerText;

    private float startTime;
    private float levelDuration;
    public float silverTime;
    public float goldTime;

    private void Start ()
    {
        instance = this;
        pauseMenu.SetActive(false);
        endMenu.SetActive(false);
        startTime = Time.time;

    }

    private void Update()
    {
        levelDuration = Time.time - startTime;
        string minutes = ((int)levelDuration / 60).ToString("00");
        string seconds = (levelDuration % 60).ToString("00.00");
        timerText.text = minutes + ":" + seconds;

    }

    public void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        Time.timeScale = (pauseMenu.activeSelf) ? 0 : 1;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void Victory()
    {

        foreach(Transform t in endMenu.transform.parent)
        {
            t.gameObject.SetActive(false);
        }

        endMenu.SetActive(true);

        levelDuration = Time.time - startTime;
        string minutes = ((int)levelDuration / 60).ToString("00");
        string seconds = (levelDuration % 60).ToString("00.00");
        endTimerText.text = minutes + ":" + seconds;

        if (levelDuration < goldTime)
        {
            CompleteGameManager.Instance.currency += 150;
            endTimerText.color = Color.yellow;
        }
        else if (levelDuration < silverTime)
        {
            CompleteGameManager.Instance.currency += 75;
            endTimerText.color = Color.gray;
        }
        else
        {
            CompleteGameManager.Instance.currency += 30;
            endTimerText.color = new Color (0.8f,0.5f,0.2f,1.0f);
        }
        CompleteGameManager.Instance.Save();

        string saveString = "";

        LevelData level = new LevelData(SceneManager.GetActiveScene().name);
        saveString += (level.BestTime > levelDuration || level.BestTime ==0.0f) ? levelDuration.ToString() : level.BestTime.ToString();
        saveString += '&';
        saveString += silverTime.ToString();
        saveString += '&';
        saveString += goldTime.ToString();
        PlayerPrefs.SetString(SceneManager.GetActiveScene().name, saveString);

    }



}
