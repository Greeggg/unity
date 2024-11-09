using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControler : MonoBehaviour
{
    public Rigidbody rb;
    private float turnspeed = 50.0f;
    private float forwardInput;  
    private float winkelInput;
    public float forceStrenght = 0.1f;
    float forceControl;
    private Vector3 pos ;
    private GameObject direction;
    public bool swim;
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

    void Start()
    {
        rb=GetComponent<Rigidbody>();  
        direction = GameObject.Find("Direction");
        swim=false;
        center= Screen.width * 0.5f;
        
    }
 
    // Update is called once per frame
void Update()
{

    if (Input.GetKeyDown(KeyCode.Space)) // Wenn Space gedrückt wird...
    {
        swim = true;    
        powerBar.siliderpos=false;      
        cursor.gameObject.SetActive(false);
    }
    if (!powerBar.siliderpos)
    {
        forceStrenght=powerBar.poweranzahl;
    }

    if (swim)
    {
        mouseX = Input.mousePosition.x;


        if (mouseX > center)
        {
            rightleft = stärke;
        }
        if (mouseX < center)
        {
            rightleft = -stärke;
        }
        direct = new Vector3(1, 0, 0);
    }

    float moveX = Input.GetAxis("Horizontal");
    float moveY = Input.GetAxis("Vertical");
    Vector3 movement = new Vector3(moveX, moveY, 0) * turnspeed * Time.deltaTime;
    cursor.transform.position += movement;

    pos = direction.transform.position;
    kraft = new Vector3(0, -1, 0);
}

    private void FixedUpdate()
    {
        if (swim)
        {
            rb.AddForce(pos * forceStrenght);
            rb.AddForce(kraft * gravity);
            rb.AddForce(direct * rightleft);
        }
    }


}