using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControler : MonoBehaviour
{
    private float speed=10.0f;
    private float forwardInput;
    private float winkelInput;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward*Time.deltaTime*speed*forwardInput);
        winkelInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up*Time.deltaTime*speed*winkelInput);
    }
}
