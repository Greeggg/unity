using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
<<<<<<< Updated upstream
    public float score = 20;
    private bool canhit;      
    private float scoreCooldown = 0.1f; 

    void Start()
    {
        canhit=true;
=======
    public float score = 20;  // Anfangspunktestand
    private bool canhit;      // Verhindert Mehrfach-Treffer
    private float scoreCooldown = 0.1f;  // Verzögerung für den nächsten Treffer
    public TextMeshProUGUI pointsText;  // Referenz zum TextMeshProUI-Text

    void Start()
    {
        canhit = true;  // Initialisiere canhit auf true
        UpdateScoreText(); // Zeigt zu Beginn den aktuellen Punktestand an
>>>>>>> Stashed changes
    }
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (canhit)
        {
<<<<<<< Updated upstream
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
=======
            // Überprüfen, welches Tag der getroffene Ring hat und Punkte abziehen
            if (other.CompareTag("ring1") || other.CompareTag("ring2"))
            {
                Debug.Log("Treffer mit ring1 oder ring2");
                score -= 1;
            }
            else if (other.CompareTag("ring3") || other.CompareTag("ring4"))
            {
                Debug.Log("Treffer mit ring3 oder ring4");
                score -= 3;
            }
            else if (other.CompareTag("ring5") || other.CompareTag("ring6"))
            {
                Debug.Log("Treffer mit ring5 oder ring6");
                score -= 5;
            }
            else if (other.CompareTag("ring7"))
            {
                Debug.Log("Treffer mit ring7");
>>>>>>> Stashed changes
                score -= 10;
            }

            Debug.Log( score);

<<<<<<< Updated upstream
        
            canhit = false;
=======
            Debug.Log("Aktueller Punktestand: " + score);  // Log für Debugging

            // Punkteanzeige im UI aktualisieren
            UpdateScoreText();

            // Verhindern, dass der Pfeil sofort mehrfach zählt
            canhit = false;

            // Nach einer kurzen Pause erlauben wir den nächsten Treffer
>>>>>>> Stashed changes
            StartCoroutine(ScoreCooldown());
        }
    }

<<<<<<< Updated upstream
    // Coroutine to handle the cooldown after the first score
    private IEnumerator ScoreCooldown()
    {
        yield return new WaitForSeconds(scoreCooldown);
        canhit = true; 
    }
}
=======
    // Coroutine für die Verzögerung zwischen Treffern
    private IEnumerator ScoreCooldown()
    {
        // Verzögerung abwarten, bevor wieder ein Treffer akzeptiert wird
        yield return new WaitForSeconds(scoreCooldown);
        canhit = true;  // Nach der Verzögerung den nächsten Treffer erlauben
    }

    // Methode zum Aktualisieren der Punktzahl im UI
    private void UpdateScoreText()
    {
        if (pointsText != null)
        {
            pointsText.text = "Score: " + score;
        }
        else
        {
            Debug.LogError("pointsText ist nicht zugewiesen!");
        }
    }
}
>>>>>>> Stashed changes
