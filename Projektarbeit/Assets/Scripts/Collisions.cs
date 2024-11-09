using System.Collections;
using UnityEngine;
using TMPro;

public class Collisions : MonoBehaviour
{
    Rigidbody playerRb;
    public float counter = 0f;
    public TextMeshProUGUI counterText;
    public Vector3 startPosition;
    public ArrowControler arrowScript;
    public GameObject powerBar;

    void Start()
    {
        arrowScript = GameObject.Find("Arr").GetComponent<ArrowControler>();
        playerRb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        UpdateCounterText();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            counter++; 
            UpdateCounterText(); 

            ResetDartAndUpdate();

            powerBar powerBarScript = powerBar.GetComponent<powerBar>();
            if (powerBarScript != null)
            {
                powerBarScript.ResetPowerBar();
            }
        }
    }

    public void ResetDartAndUpdate()
    {
        ResetDart();
    }

    public void ResetDart()
    {
        arrowScript.swim = false;

        playerRb.transform.position = startPosition; 
        playerRb.transform.rotation = Quaternion.identity; 
        playerRb.velocity = Vector3.zero;  
        playerRb.angularVelocity = Vector3.zero; 
    }

    public void UpdateCounterText()
    {
        if (counterText != null)
            counterText.text = "Versuche: " + counter;
    }
}
