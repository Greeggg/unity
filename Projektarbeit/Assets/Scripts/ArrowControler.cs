using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControler : MonoBehaviour
{
    public Rigidbody rb;
    private float turnspeed = 5.0f;
    private float forwardInput;  
    private float winkelInput;
    public float forceStrenght = 0.1f;
    float forceControl;
    private Vector3 pos ;
    private GameObject direction;
    private bool swim;
    public GameObject cursor;
    public float gravity = 0.1f;
    private Vector3 kraft;
    private float mouseX;
    private float mouseY;
    private Vector3 direct;
    private float rightleft;
    public  float stärke = 50;
    public GameObject arrow;
    private float center;
    private float  boarder = 750.0f;
   

    void Start()
    {
        rb=GetComponent<Rigidbody>();  
        direction = GameObject.Find("Direction");
        swim=false;
        //arrow.transform.Rotate(0,0,90, Space.Self);
        center= Screen.width * 0.5f;
     
        
    }
 
    // Update is called once per frame
    void Update()
    {
        

        float moveX = Input.GetAxis("Horizontal"); // Left (-1) and Right (+1)
        float moveY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveX, moveY, 0) * turnspeed * Time.deltaTime;
        cursor.transform.position += movement;
        
        if(swim)
        {
            mouseX =  Input.mousePosition.x;
            
        if( mouseX > center )
        {
            rightleft= stärke;
        }
        
        if( mouseX < center  )
        {
            rightleft= -stärke;
           
        }
            direct = new Vector3(1,0,0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
           swim=true;
           cursor.gameObject.SetActive(false);
           
        }
        pos = direction.transform.position;
        kraft = new Vector3(0,-1,0);
        
        
    }
    private void FixedUpdate()
    {
        if(swim)
        {
        rb.AddForce(pos*forceStrenght);
        rb.AddForce(kraft*gravity);
        rb.AddForce(direct * rightleft);
        }
       

        
    }

}