using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GuiManager : MonoBehaviour
{
    Rigidbody playerRb;
    public Button startbutton;
    public Button exitbutton;
    public Button homebutton;
    public Button tryagainbutton;
    public Button pausebutton;
    public Button continuebutton;
    public Button infobutton;
    public Button closebutton;
    public Button infobuttondg;
    public Button closebuttondg;
    public Button restartbutton;

    public TMP_Dropdown difficultyDropdown;
    public GameObject titleScreen;
    public GameObject duringGameScreen;
    public GameObject gameOverScreen;
    public GameObject infoPanel;
    public GameObject infoPaneldg;
    public GameObject menuPanel;
    public GameObject powerBar;
    public GameObject slider;
    public GameObject ziel;
    public Vector3 startPosition;

    public Collisions collisionsScript;
    public ArrowControler arrowScript;
    public Target targetScript;

    private bool isPaused = false;
    private bool isInGame = false;

    void StartGame()
    {
        playerRb.transform.position = startPosition;
        playerRb.transform.rotation = Quaternion.identity;

        titleScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        duringGameScreen.SetActive(true);
        infoPanel.SetActive(false);
        infoPaneldg.SetActive(false);
        menuPanel.SetActive(false);
        isInGame = true;
        difficultyDropdown.gameObject.SetActive(false);
        Time.timeScale = 1;
        powerBar.SetActive(true);
        slider.SetActive(true);
        ziel.SetActive(true);
        targetScript.score = 20;
        targetScript.UpdatePointsText();
    }

    void ExitFunction()
    {
        arrowScript.swim = false;
        playerRb.transform.position = startPosition;
        playerRb.transform.rotation = Quaternion.identity;

        playerRb.velocity = Vector3.zero;
        playerRb.angularVelocity = Vector3.zero;

        collisionsScript.counter = 0;
        collisionsScript.UpdateCounterText();

        menuPanel.SetActive(false);

        duringGameScreen.SetActive(false);
        titleScreen.SetActive(true);
        difficultyDropdown.gameObject.SetActive(true);
        isInGame = false;
        Time.timeScale = 1;
    }


    void InfoScreen()
    {
        if (isInGame)
        {
            infoPaneldg.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
            menuPanel.SetActive(false);
        }
        else
        {
            infobutton.gameObject.SetActive(false);
            infoPanel.SetActive(true);
            difficultyDropdown.gameObject.SetActive(false);
        }
    }

    void CloseInfoScreen()
    {
        if (isInGame)
        {
            infoPaneldg.SetActive(false);
            menuPanel.SetActive(true);
            Time.timeScale = 1;
            pausebutton.gameObject.SetActive(true);
            isPaused = false;
        }
        else
        {
            infobutton.gameObject.SetActive(true);
            infoPanel.SetActive(false);
            difficultyDropdown.gameObject.SetActive(true);
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        menuPanel.SetActive(true);
        isPaused = true;
    }

    void ContinueGame()
    {
        Time.timeScale = 1;
        menuPanel.SetActive(false);
        isPaused = false;
    }

    void RestartGame()
    {
        arrowScript.swim = false;

        playerRb.transform.position = startPosition;
        playerRb.transform.rotation = Quaternion.identity;

        playerRb.velocity = Vector3.zero;
        playerRb.angularVelocity = Vector3.zero;

        menuPanel.SetActive(false);

        collisionsScript.counter = 0;
        collisionsScript.UpdateCounterText();

        gameOverScreen.SetActive(false);
        duringGameScreen.SetActive(true);
        Time.timeScale = 1;
        targetScript.score = 20;
        targetScript.UpdatePointsText();

        powerBar powerBarScript = powerBar.GetComponent<powerBar>();
        powerBarScript.ResetPowerBar();
        ziel.SetActive(true);
    }

    void Start()
    {
        targetScript = GameObject.Find("Arr").GetComponent<Target>();
        playerRb = GameObject.Find("Arr").GetComponent<Rigidbody>();
        startPosition = playerRb.transform.position;
        collisionsScript = GameObject.Find("Arr").GetComponent<Collisions>();
        arrowScript = GameObject.Find("Arr").GetComponent<ArrowControler>();

        titleScreen.SetActive(true);
        infoPanel.SetActive(false);
        infoPaneldg.SetActive(false);
        duringGameScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        menuPanel.SetActive(false);

        startbutton.onClick.AddListener(StartGame);
        exitbutton.onClick.AddListener(ExitFunction);
        homebutton.onClick.AddListener(ExitFunction);
        tryagainbutton.onClick.AddListener(RestartGame);
        pausebutton.onClick.AddListener(PauseGame);
        infobutton.onClick.AddListener(InfoScreen);
        closebutton.onClick.AddListener(CloseInfoScreen);
        infobuttondg.onClick.AddListener(InfoScreen);
        closebuttondg.onClick.AddListener(CloseInfoScreen);
        restartbutton.onClick.AddListener(RestartGame);
        continuebutton.onClick.AddListener(ContinueGame);
    }

    void Update()
    {
    }
}
