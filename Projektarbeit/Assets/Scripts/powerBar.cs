using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerBar : MonoBehaviour
{
    public float speed = 15f;
    public float limitleft = 0f;
    public float limitright = 30f;

    private float direction = 1f;
    public GameObject slider;
    static public bool siliderpos;
    static public float poweranzahl;

    void Start()
    {
        siliderpos = true;
        poweranzahl = 0.01f;

        slider.SetActive(true);
        gameObject.SetActive(true);
    }

    void Update()
    {
        if (siliderpos)
        {
            slider.transform.Translate(Vector3.right * speed * direction * Time.deltaTime);

            if (slider.transform.position.x >= limitright || slider.transform.position.x <= limitleft)
            {
                direction *= -1;
            }
        }
        
        if (!siliderpos)
        {
            poweranzahl += slider.transform.position.x / 100.0f;

            slider.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    public void ResetPowerBar()
    {
        slider.transform.position = new Vector3(limitleft, slider.transform.position.y, slider.transform.position.z);
        poweranzahl = 0.01f;  
        siliderpos = true;    
        slider.SetActive(true);
        gameObject.SetActive(true);
    }
}
