using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static float Score;
    [SerializeField] private Text m_score;
    [SerializeField] private Text highScore;
    [SerializeField] private Text currentScore;
    [SerializeField] private GameObject Character;
    [SerializeField] private Button archerButton;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameScreen;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject howToPlay;
    [SerializeField] private GameObject castle;
    [SerializeField] private Animator gameName;
    private void Start()
    {
        gameName.Play("GameName");
        Time.timeScale = 0;
        Score = 500;
        mainMenu.SetActive(true);
        pauseMenu.SetActive(false);
        gameScreen.SetActive(false);
    }

    private void FixedUpdate()
    {
        m_score.text = Score.ToString();
        if (Score >= 500)
            archerButton.interactable = true;

        if(PlayerPrefs.GetFloat("HighScore") < Score)
            PlayerPrefs.SetFloat("HighScore", Score);

        if (castle.activeSelf == false)
        {
            currentScore.text = Score.ToString();
            highScore.text = PlayerPrefs.GetFloat("HighScore").ToString();
            endScreen.SetActive(true);
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

}
