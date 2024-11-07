using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject titleScreen;
    public GameObject duringGameScreen;
    public GameObject gameOverScreen;
    public GameObject infoPanel;
    public GameObject infoPaneldg;

    public Vector3 startPosition;

    public Collisions collisionsScript; 

    private bool isPaused = false;
    private bool isInGame = false;
    private bool canLaunch = false;

    void StartGame()
    {
        playerRb.transform.position = startPosition;
        playerRb.transform.rotation = Quaternion.identity;

        titleScreen.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(false);
        duringGameScreen.gameObject.SetActive(true);
        infoPanel.gameObject.SetActive(false);
        infoPaneldg.gameObject.SetActive(false);
        continuebutton.gameObject.SetActive(false);
        isInGame = true;
        canLaunch = true;
        Time.timeScale = 1;
    }

    void ExitFunction()
    {
        playerRb.transform.position = startPosition;
        playerRb.transform.rotation = Quaternion.identity;

        duringGameScreen.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(true);
        isInGame = false;
        Time.timeScale = 1;
    }

    void HomeFunction()
    {
        gameOverScreen.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(true);
        isInGame = false;
        Time.timeScale = 1;
    }

    void InfoScreen()
    {
        if (isInGame)
        {
            infoPaneldg.gameObject.SetActive(true);
            infobuttondg.gameObject.SetActive(false);
            Time.timeScale = 0;
            pausebutton.gameObject.SetActive(false);
            exitbutton.gameObject.SetActive(false);
            isPaused = true;
        }
        else
        {
            infobutton.gameObject.SetActive(false);
            infoPanel.gameObject.SetActive(true);
        }
    }

    void CloseInfoScreen()
    {
        if (isInGame)
        {
            infoPaneldg.gameObject.SetActive(false);
            infobuttondg.gameObject.SetActive(true);
            Time.timeScale = 1;
            pausebutton.gameObject.SetActive(true);
            exitbutton.gameObject.SetActive(true);
            isPaused = false;
        }
        else
        {
            infobutton.gameObject.SetActive(true);
            infoPanel.gameObject.SetActive(false);
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        pausebutton.gameObject.SetActive(false);
        continuebutton.gameObject.SetActive(true);
        isPaused = true;
    }

    void ContinueGame()
    {
        Time.timeScale = 1;
        pausebutton.gameObject.SetActive(true);
        continuebutton.gameObject.SetActive(false);
        isPaused = false;
    }

    void RestartFunction()
    {
        gameOverScreen.gameObject.SetActive(false);
        duringGameScreen.gameObject.SetActive(true);
        isInGame = true;
        RestartGame();
    }

    void RestartGame()
    {
        playerRb.transform.position = startPosition;
        playerRb.transform.rotation = Quaternion.identity;

        playerRb.velocity = Vector3.zero;
        playerRb.angularVelocity = Vector3.zero;

        collisionsScript.counter = 0;
        collisionsScript.UpdateCounterText();

        canLaunch = true;


        gameOverScreen.gameObject.SetActive(false);
        duringGameScreen.gameObject.SetActive(true);
        Time.timeScale = 1;
    }



    void Start()
    {
        playerRb = GameObject.Find("Arr").GetComponent<Rigidbody>();
        startPosition = playerRb.transform.position; 
        collisionsScript = GameObject.Find("Arr").GetComponent<Collisions>();

        titleScreen.gameObject.SetActive(true);
        infoPanel.gameObject.SetActive(false);
        infoPaneldg.gameObject.SetActive(false);
        duringGameScreen.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(false);

        startbutton = startbutton.GetComponent<Button>();
        startbutton.onClick.AddListener(StartGame);

        exitbutton = exitbutton.GetComponent<Button>();
        exitbutton.onClick.AddListener(ExitFunction);

        homebutton = homebutton.GetComponent<Button>();
        homebutton.onClick.AddListener(HomeFunction);

        tryagainbutton = tryagainbutton.GetComponent<Button>();
        tryagainbutton.onClick.AddListener(RestartFunction);

        pausebutton = pausebutton.GetComponent<Button>();
        pausebutton.onClick.AddListener(PauseGame);

        infobutton = infobutton.GetComponent<Button>();
        infobutton.onClick.AddListener(InfoScreen);

        closebutton = closebutton.GetComponent<Button>();
        closebutton.onClick.AddListener(CloseInfoScreen);

        infobuttondg = infobuttondg.GetComponent<Button>();
        infobuttondg.onClick.AddListener(InfoScreen);

        closebuttondg = closebuttondg.GetComponent<Button>();
        closebuttondg.onClick.AddListener(CloseInfoScreen);

        restartbutton = restartbutton.GetComponent<Button>();
        restartbutton.onClick.AddListener(RestartGame);

        continuebutton = continuebutton.GetComponent<Button>();
        continuebutton.onClick.AddListener(ContinueGame);
        continuebutton.gameObject.SetActive(false);
    }

    void Update()
    {

    }
}
