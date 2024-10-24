using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiManager : MonoBehaviour
{
    public Button startbutton;
    public Button exitbutton;
    public Button homebutton;
    public Button tryagainbutton;
    public Button pausebutton;
    public Button continuebutton;
    public GameObject titleScreen;
    public GameObject duringGameScreen;
    public GameObject gameOverScreen;

    private bool isPaused = false;
    void StartGame()
    {
        titleScreen.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(false);
        duringGameScreen.gameObject.SetActive(true);
        continuebutton.gameObject.SetActive(false);
        Time.timeScale = 1;

    }
    
    void ExitFunction()
    {
        duringGameScreen.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    void HomeFunction()
    {
        gameOverScreen.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(true);
        Time.timeScale = 1;
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
    }





    // Start is called before the first frame update
    void Start()
    {
        titleScreen.gameObject.SetActive(true);
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

        continuebutton = continuebutton.GetComponent<Button>();
        continuebutton.onClick.AddListener(ContinueGame);
        continuebutton.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }
    
}
