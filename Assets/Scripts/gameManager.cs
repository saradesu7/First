using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static float Score;
    [SerializeField] private Text m_score;
    [SerializeField] private TMPro.TextMeshProUGUI highScore1;
    [SerializeField] private TMPro.TextMeshProUGUI highScore2;
    [SerializeField] private TMPro.TextMeshProUGUI currentScore;
    [SerializeField] private GameObject Character;
    [SerializeField] private Button archerButton;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameScreen;
    [SerializeField] private GameObject endScreen1;
    [SerializeField] private GameObject endScreen2;
    [SerializeField] private GameObject howToPlay;
    [SerializeField] private GameObject castle;
    private void Start()
    {
        Time.timeScale = 0;
        Score = 500;
        mainMenu.SetActive(true);
        pauseMenu.SetActive(false);
        gameScreen.SetActive(false);
        howToPlay.SetActive(false);
        //PlayerPrefs.SetFloat("HighScore", 0f);
    }

    private void FixedUpdate()
    {
        m_score.text = Score.ToString();
        if (Score >= 500)
            archerButton.interactable = true;

        if (castle.activeSelf == false)
        {
            currentScore.text = Score.ToString();
            highScore1.text = PlayerPrefs.GetFloat("HighScore").ToString();
            if (PlayerPrefs.GetFloat("HighScore") < Score)
            {
                PlayerPrefs.SetFloat("HighScore", Score);
                highScore2.text = PlayerPrefs.GetFloat("HighScore").ToString();
                endScreen2.SetActive(true);
            }
            else
                endScreen1.SetActive(true);
            gameScreen.SetActive(false);
            Time.timeScale = 0;
        }

    }
    public void OnClickSpawnButton()
    {
        if (Score < 500f)
        {
            archerButton.interactable = false;
        }
        else if (Score >= 500f)
        {
            Instantiate(Character, null);
            Score -= 500f;
        }
    }

    public void OnClickPlayButton()
    {
        Time.timeScale = 1;
        mainMenu.SetActive(false);
        gameScreen.SetActive(true);
    }

    public void OnClickPauseButton()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void OnClickResumeButton()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnClickGoBack()
    {
        howToPlay.SetActive(false);
    }

    public void OnClickHowToPlay()
    {
        howToPlay.SetActive(true);
    }

    public void onClickQuit()
    {
        Application.Quit();
    }

}
