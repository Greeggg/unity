using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControler : MonoBehaviour
{
    private float turnspeed=10.0f;  // Geschwindigkeit beim rotieren
    public float launchspeed=1000.0f; //Anfangs Geschwindigkeit
    private float forwardInput;  
    private float winkelInput;
    private Rigidbody playerRb;    // Rigidbody vom Dartpfeil

    private GameObject direction;  
    private bool grounded;
    public Vector2 turn;


    // Start is called before the first frame update
    void Start()
    {
        playerRb=GetComponent<Rigidbody>();  
        direction = GameObject.FindWithTag("Direction");
        grounded=true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (grounded)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                launchspeed=launchspeed*1.1f;
            }
            forwardInput = -100*Input.GetAxis("Mouse X");
            transform.Rotate(Vector3.up*Time.deltaTime*turnspeed*forwardInput);
            winkelInput = -100*Input.GetAxis("Mouse Y");
            transform.Rotate(Vector3.forward*Time.deltaTime*turnspeed*winkelInput);
            launch();
        }
        
    }
    private void launch()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(direction.transform.position, ForceMode.Acceleration);
            grounded=false;

        }
    
    }
    
    
}