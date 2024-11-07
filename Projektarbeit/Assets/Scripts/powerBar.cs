using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerBar : MonoBehaviour
{
    public float speed = 5f;
    public float limitleft = 0f;
    public float limitright = 30f;

    private float  direction = 1f;
    public GameObject slider;
    static public bool siliderpos;
    static public float poweranzahl;
    void Start()
    {
        siliderpos=true;
        poweranzahl=0.01f;
        
    }

    void Update()
    {
        // Move the object along the X-axis
        slider.transform.Translate(Vector3.right * speed * direction * Time.deltaTime);

        if (siliderpos)
        {
            slider.transform.Translate(Vector3.right * speed * direction * Time.deltaTime);
            if (slider.transform.position.x >= limitright || slider.transform.position.x <= limitleft)
             {
                direction *= -1; 
             }
        }
        if(!siliderpos)
        {
            poweranzahl += slider.transform.position.x/100.0f;

            slider.gameObject.SetActive(false);
            gameObject.SetActive(false);
            
        }
    }
}
