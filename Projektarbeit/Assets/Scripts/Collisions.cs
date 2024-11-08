using System.Collections;
using UnityEngine;
using TMPro;

public class Collisions : MonoBehaviour
{
    Rigidbody playerRb;
    public bool hitBoard = false;
    public bool hitObstacle = false;
    public float counter = 0f;
    public TextMeshProUGUI counterText;
    public Vector3 startPosition;
    public ArrowControler arrowScript;
    private bool isResetting = false;
    public GameObject powerBar;
    public GameObject slider;
    public GameObject ziel;

    void Start()
    {
        arrowScript = GameObject.Find("Arr").GetComponent<ArrowControler>();
        playerRb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        UpdateCounterText();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isResetting) return;

        if (collision.collider.CompareTag("Obstacle") || 
            collision.collider.CompareTag("ring1") || 
            collision.collider.CompareTag("ring2") || 
            collision.collider.CompareTag("ring3") || 
            collision.collider.CompareTag("ring4") || 
            collision.collider.CompareTag("ring5") || 
            collision.collider.CompareTag("ring6") || 
            collision.collider.CompareTag("ring7"))
        {
            counter++;
            UpdateCounterText();

            hitBoard = collision.collider.CompareTag("Board");
            hitObstacle = collision.collider.CompareTag("Obstacle");

            StartCoroutine(ResetDart());

            powerBar powerBarScript = powerBar.GetComponent<powerBar>();
            if (powerBarScript != null)
            {
                powerBarScript.ResetPowerBar();
            }

            ziel.SetActive(true);
        }
    }

    private IEnumerator ResetDart()
    {
        isResetting = true;
        arrowScript.swim = false;
        
        yield return new WaitForSeconds(0.5f); 
        
        playerRb.transform.position = startPosition;
        playerRb.transform.rotation = Quaternion.identity;
        playerRb.velocity = Vector3.zero;
        playerRb.angularVelocity = Vector3.zero;

        isResetting = false;
    }

    public void UpdateCounterText()
    {
        if(counterText != null)
            counterText.text = "Versuche: " + counter;
    }
}
