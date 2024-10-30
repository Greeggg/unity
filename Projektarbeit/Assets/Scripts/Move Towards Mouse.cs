using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsMouse : MonoBehaviour
{
    public float turnspeed = 10.0f; // Speed of rotation
    public float offset = -140.0f; // Distance from the camera
    private GameObject direction;   
    private Rigidbody playerRb;




    void Start()
    {
        playerRb=GetComponent<Rigidbody>();  
        direction = GameObject.FindWithTag("Direction");
    }
    void Update()
    {

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = offset; 
        direction.transform.position = Camera.main.ScreenToWorldPoint(mousePos);

    }
}