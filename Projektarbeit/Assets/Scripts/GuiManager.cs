using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiManager : MonoBehaviour
{
    public Button startbutton;
    public GameObject titleScreen;

    void StartGame()
    {
        titleScreen.gameObject.SetActive(false);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        startbutton = startbutton.GetComponent<Button>();
        startbutton.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
