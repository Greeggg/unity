using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiManager : MonoBehaviour
public Button button;
{
    // Start is called before the first frame update
    void Start()
    {
        Button startbutton = button.GetComponent<Button>();
        startbutton.OnClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void StartGame()
    {
        titleScreen.gameObject.SetActive(false);
    }
}
