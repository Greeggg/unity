using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControler : MonoBehaviour
{
    private float speed=10.0f;
    private float launchspeed=100.0f;
    private float forwardInput;
    private float winkelInput;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb=GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.L))
        {
            launchspeed=launchspeed*1.1f;
        }
        forwardInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up*Time.deltaTime*speed*forwardInput);
        winkelInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.forward*Time.deltaTime*speed*winkelInput);
        launch();
        
    }
    private void launch()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(transform.position*launchspeed,ForceMode.Impulse);
            
        }
    
    }
    
    
}
