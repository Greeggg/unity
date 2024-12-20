using System.Collections;
using UnityEngine;
using TMPro;

public class Collisions : MonoBehaviour
{
    public Rigidbody playerRb;
    public float counter = 0f;
    public TextMeshProUGUI counterText;
    public Vector3 startPosition;
    public ArrowControler arrowScript;
    public GameObject powerBar;
    public GameObject ziel;
    public ParticleSystem explosion;  // Reference to the firework particle system



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
            explosion.gameObject.SetActive(true);
            explosion.Play();
            counter++; 
            UpdateCounterText(); 

            ResetDartAndUpdate();

            powerBar powerBarScript = powerBar.GetComponent<powerBar>();
            if (powerBarScript != null)
            {
                powerBarScript.ResetPowerBar();
            }
            ziel.gameObject.SetActive(true);
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
