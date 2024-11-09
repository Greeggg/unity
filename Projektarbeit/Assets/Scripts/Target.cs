using System.Collections;
using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{
    public float score = 20;
    private bool canhit;
    private float scoreCooldown = 0.01f;
    public ParticleSystem fierwork;

    public TextMeshProUGUI pointsText;
    private Collisions collisionsScript;
    public GameObject gameOverScreen;
    public TextMeshProUGUI gameOverText;
    private ArrowControler arrowScript;  

    public GameObject powerBar; 
    public GameObject cursor; 

    void Start()
    {
        pointsText = GameObject.Find("PointsText").GetComponent<TextMeshProUGUI>();
        GameObject dart = GameObject.FindWithTag("Arrow");
        collisionsScript = dart.GetComponent<Collisions>();
        arrowScript = dart.GetComponent<ArrowControler>(); 
        gameOverScreen.SetActive(false);

        canhit = true;
        UpdatePointsText();
    }

    void Update()
    {
        if (score <= 0)
        {
            ShowGameOverScreen();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canhit)
        {
            if (other.CompareTag("ring1"))
            {
                fierwork.gameObject.SetActive(true);
                fierwork.Play();
                score -= 1;
            }
            else if (other.CompareTag("ring2"))
            {
                fierwork.gameObject.SetActive(true);
                fierwork.Play();
                if(score>=2)
                {
                    score -= 2;

                }
            }
            else if (other.CompareTag("ring3"))
            {
                fierwork.gameObject.SetActive(true);
                fierwork.Play();
                if(score>=3)
                {
                    score -= 3;
                }
            }
            else if (other.CompareTag("ring4"))
            {
                fierwork.gameObject.SetActive(true);
                fierwork.Play();
                if(score>=4)
                {
                    score -= 4;
                }
            }
            else if (other.CompareTag("ring5"))
            {
                fierwork.gameObject.SetActive(true);
                fierwork.Play();
                if(score>=5)
                {
                    score -= 5;
                }
            }
            else if (other.CompareTag("ring6"))
            {
                fierwork.gameObject.SetActive(true);
                fierwork.Play();
                if(score>=7)
                {
                    score -= 7;
                }
            }
            else if (other.CompareTag("ring7"))
            {
                fierwork.gameObject.SetActive(true);
                fierwork.Play();
                if(score>=11)
                {
                    score-=10;
                }
                    
            }


            UpdatePointsText();
            collisionsScript.ResetDartAndUpdate(); 

            canhit = false;
            StartCoroutine(ResetCanHit());
            collisionsScript.counter++;
            collisionsScript.UpdateCounterText();
            cursor.gameObject.SetActive(true);

            
            powerBar powerBarScript = powerBar.GetComponent<powerBar>();
            if (powerBarScript != null)
            {
                powerBarScript.ResetPowerBar(); 
            }
        }
    }

    private IEnumerator ResetCanHit()
    {
        yield return new WaitForSeconds(scoreCooldown);
        canhit = true;
    }

    public void UpdatePointsText()
    {
        if (pointsText != null)
        {
            pointsText.text = "Score: " + Mathf.Max(0, score).ToString();
        }
    }

    void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
        gameOverText.text = "Attempts: " + collisionsScript.counter.ToString();
    }

    public void ResetScore()
    {
        score = 20; 
        UpdatePointsText();
    }

 
}
