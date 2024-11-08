using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float score = 20;
    private bool canhit;      
    private float scoreCooldown = 0.1f; 

    void Start()
    {
        canhit=true;
    }
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (canhit)
        {
            if (other.CompareTag("ring1"))
            {
                Debug.Log("ring1");
                score -= 1;
            }
            else if (other.CompareTag("ring2"))
            {
                Debug.Log("ring2");
                score -= 1;
            }
            else if (other.CompareTag("ring3"))
            {
                Debug.Log("ring3");
                score -= 3;
            }
            else if (other.CompareTag("ring4"))
            {
                Debug.Log("ring4");
                score -= 3;
            }
            else if (other.CompareTag("ring5"))
            {
                Debug.Log("ring5");
                score -= 5;
            }
            else if (other.CompareTag("ring6"))
            {
                Debug.Log("ring6");
                score -= 5;
            }
            else if (other.CompareTag("ring7"))
            {
                Debug.Log("ring7");
                score -= 10;
            }

            Debug.Log( score);

        
            canhit = false;
            StartCoroutine(ScoreCooldown());
        }
    }

    // Coroutine to handle the cooldown after the first score
    private IEnumerator ScoreCooldown()
    {
        yield return new WaitForSeconds(scoreCooldown);
        canhit = true; 
    }
}