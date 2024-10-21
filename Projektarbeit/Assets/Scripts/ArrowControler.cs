using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControler : MonoBehaviour
{
    private float speed=10.0f;
    public float launchspeed=10.0f;
    private float forwardInput;
    private float winkelInput;
    private Rigidbody playerRb;

    private GameObject direction;
    private bool inAir;

    public float gravity=100.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb=GetComponent<Rigidbody>();  
        direction = GameObject.FindWithTag("Direction");
        inAir=true;
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.L))
        {
            launchspeed=launchspeed*1.1f;
        }
        if (inAir)
        {
        forwardInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up*Time.deltaTime*speed*forwardInput);
        winkelInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.forward*Time.deltaTime*speed*winkelInput);
        launch();
        // playerRb.AddForce(Vector3.down*gravity,ForceMode.Force);  [Idee es runter zu drücken]
        }
        
    }
    private void launch()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(direction.transform.position*launchspeed,ForceMode.Acceleration);
            
            inAir=false;
        }
    
    }
    
    
}
