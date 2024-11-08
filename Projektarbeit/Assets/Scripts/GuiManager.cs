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
<<<<<<< Updated upstream
    public GameObject powerBar;
    public GameObject slider;
    public GameObject ziel;
=======

>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        continuebutton.gameObject.SetActive(true);
=======
>>>>>>> Stashed changes
        menuPanel.gameObject.SetActive(false);
        isInGame = true;
        difficultyDropdown.gameObject.SetActive(false);
        Time.timeScale = 1;
        powerBar.SetActive(true);
        slider.SetActive(true);
        ziel.SetActive(true);
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

        menuPanel.gameObject.SetActive(false);

        duringGameScreen.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(true);
        difficultyDropdown.gameObject.SetActive(true);
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
            Time.timeScale = 0;
            isPaused = true;
            menuPanel.gameObject.SetActive(false);
<<<<<<< Updated upstream
            difficultyDropdown.gameObject.SetActive(false);  // Dropdown ausblenden
=======
>>>>>>> Stashed changes
        }
        else
        {
            infobutton.gameObject.SetActive(false);
            infoPanel.gameObject.SetActive(true);
            difficultyDropdown.gameObject.SetActive(false);  
        }
    }

    void CloseInfoScreen()
    {
        if (isInGame)
        {
            infoPaneldg.gameObject.SetActive(false);
<<<<<<< Updated upstream
            infobuttondg.gameObject.SetActive(true);
            Time.timeScale = 0;
=======
            menuPanel.gameObject.SetActive(true);
            Time.timeScale = 1;
>>>>>>> Stashed changes
            pausebutton.gameObject.SetActive(true);
            isPaused = false;
            menuPanel.gameObject.SetActive(true);
            difficultyDropdown.gameObject.SetActive(true);  

        }
        else
        {
            infobutton.gameObject.SetActive(true);
            infoPanel.gameObject.SetActive(false);
            difficultyDropdown.gameObject.SetActive(true);  
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        menuPanel.gameObject.SetActive(true);
        isPaused = true;

    }

    void ContinueGame()
    {
        Time.timeScale = 1;
<<<<<<< Updated upstream
=======
        pausebutton.gameObject.SetActive(true);
>>>>>>> Stashed changes
        menuPanel.gameObject.SetActive(false);
        isPaused = false;
    }

    void RestartFunction()
    {
        gameOverScreen.gameObject.SetActive(false);
        duringGameScreen.gameObject.SetActive(true);
        menuPanel.gameObject.SetActive(false);
        isInGame = true;
        RestartGame();
    }

    void RestartGame()
    {
        arrowScript.swim = false;

        playerRb.transform.position = startPosition;
        playerRb.transform.rotation = Quaternion.identity;

        playerRb.velocity = Vector3.zero;  
        playerRb.angularVelocity = Vector3.zero; 

        menuPanel.gameObject.SetActive(false);

        collisionsScript.counter = 0;
        collisionsScript.UpdateCounterText();

        menuPanel.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(false);
        duringGameScreen.gameObject.SetActive(true);
        Time.timeScale = 1;

        powerBar powerBarScript = powerBar.GetComponent<powerBar>();
        powerBarScript.ResetPowerBar();
        ziel.SetActive(true);
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
<<<<<<< Updated upstream
        continuebutton.gameObject.SetActive(true);

=======
>>>>>>> Stashed changes

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

    }

    void Update()
    {

    }
}
