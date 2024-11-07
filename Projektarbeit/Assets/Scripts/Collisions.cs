using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        arrowScript = GameObject.Find("Arr").GetComponent<ArrowControler>();
        playerRb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        UpdateCounterText();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Board") || collision.gameObject.CompareTag("Obstacle"))
        {
            counter++;
            UpdateCounterText();
            hitBoard = collision.gameObject.CompareTag("Board");
            hitObstacle = collision.gameObject.CompareTag("Obstacle");
            ResetDart();
        }
    }

    private void ResetDart()
    {
        arrowScript.swim = false;

        playerRb.transform.position = startPosition;
        playerRb.transform.rotation = Quaternion.identity;

        playerRb.velocity = Vector3.zero;  
        playerRb.angularVelocity = Vector3.zero; 

    }

    public void UpdateCounterText()
    {
        counterText.text = "Versuche: " + counter;
    }
}
