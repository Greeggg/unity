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
    
    public GameObject menuPanel;
    public GameObject titleScreen;
    public GameObject duringGameScreen;
    public GameObject gameOverScreen;
    public GameObject infoPanel;
    public GameObject infoPaneldg;

    public Vector3 startPosition;

    public Collisions collisionsScript; 
    public ArrowControler arrowScript;

    private bool isPaused = false;
    private bool isInGame = false;

    void StartGame()
    {
        playerRb.transform.position = startPosition;
        playerRb.transform.rotation = Quaternion.identity;

        titleScreen.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(false);
        duringGameScreen.gameObject.SetActive(true);
        infoPanel.gameObject.SetActive(false);
        infoPaneldg.gameObject.SetActive(false);
        continuebutton.gameObject.SetActive(true);
        menuPanel.gameObject.SetActive(false);
        isInGame = true;
        Time.timeScale = 1;
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
            menuPanel.gameObject.SetActive(false);
            Time.timeScale = 0;
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
            menuPanel.gameObject.SetActive(true);
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
        isPaused = true;
        menuPanel.gameObject.SetActive(true);

    }

    void ContinueGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        menuPanel.gameObject.SetActive(false);
    }

    void RestartFunction()
    {
        gameOverScreen.gameObject.SetActive(false);
        duringGameScreen.gameObject.SetActive(true);
        isInGame = true;
        menuPanel.gameObject.SetActive(false);
        RestartGame();
    }

    void RestartGame()
    {
        arrowScript.swim = false;

        playerRb.transform.position = startPosition;
        playerRb.transform.rotation = Quaternion.identity;

        playerRb.velocity = Vector3.zero;  
        playerRb.angularVelocity = Vector3.zero; 

        collisionsScript.counter = 0;
        collisionsScript.UpdateCounterText();

        menuPanel.gameObject.SetActive(false);

        gameOverScreen.gameObject.SetActive(false);
        duringGameScreen.gameObject.SetActive(true);
        Time.timeScale = 1;
    }



    void Start()
    {
        playerRb = GameObject.Find("Arr").GetComponent<Rigidbody>();
        startPosition = playerRb.transform.position; 
        collisionsScript = GameObject.Find("Arr").GetComponent<Collisions>();
        arrowScript = GameObject.Find("Arr").GetComponent<ArrowControler>();

        titleScreen.gameObject.SetActive(true);
        infoPanel.gameObject.SetActive(false);
        infoPaneldg.gameObject.SetActive(false);
        duringGameScreen.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(false);
        menuPanel.gameObject.SetActive(false);

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
