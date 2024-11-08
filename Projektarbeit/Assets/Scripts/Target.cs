using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{
    public float score = 20;  // Der Anfangspunktestand
    private bool canhit;
    private float scoreCooldown = 0.1f;

    public TextMeshProUGUI pointsText;  // TextMeshProUGUI für die Punkteanzeige
    public GameObject gameOverScreen;   // Game Over Canvas

    public float detectionRadius = 3f;  // Erkennungsradius für die Ringe
    public Transform[] rings;  // Alle Ringe als Transform-Array
    
    void Start()
    {
        canhit = true;
        gameOverScreen.SetActive(false);  // Game Over Canvas zu Beginn deaktivieren
        UpdateScoreText();  // Zu Beginn die Punkteanzeige setzen
    }

    void Update()
    {
        if (canhit)
        {
            // Überprüfe, ob sich der Dart in der Nähe eines Rings befindet
            foreach (var ring in rings)
            {
                float distance = Vector3.Distance(transform.position, ring.position);
                Debug.Log($"Dart Position: {transform.position}, Ring Position: {ring.position}, Distance: {distance}");

                if (distance <= detectionRadius)  // Wenn der Dart innerhalb des Erkennungsradius ist
                {
                    HandleRingHit(ring);  // Die Funktion aufrufen, um Punkte zu zählen
                    canhit = false;
                    StartCoroutine(ScoreCooldown());
                    break;
                }
            }
        }
    }

    // Funktion zur Behandlung des Treffers eines Rings
    private void HandleRingHit(Transform ring)
    {
        // Überprüfen, welches Tag der Ring hat und den Score anpassen
        if (ring.CompareTag("ring1") || ring.CompareTag("ring2"))
        {
            Debug.Log("Treffer mit ring1 oder ring2");
            score -= 1;
        }
        else if (ring.CompareTag("ring3") || ring.CompareTag("ring4"))
        {
            Debug.Log("Treffer mit ring3 oder ring4");
            score -= 3;
        }
        else if (ring.CompareTag("ring5") || ring.CompareTag("ring6"))
        {
            Debug.Log("Treffer mit ring5 oder ring6");
            score -= 5;
        }
        else if (ring.CompareTag("ring7"))
        {
            Debug.Log("Treffer mit ring7");
            score -= 10;
        }

        // Wenn der Score unter 0 fällt, setze ihn auf 0
        if (score < 0)
            score = 0;

        UpdateScoreText();  // Aktualisiere die Score-Anzeige
        CheckGameOver();    // Überprüfe, ob das Spiel vorbei ist
    }

    private IEnumerator ScoreCooldown()
    {
        yield return new WaitForSeconds(scoreCooldown);  // Verzögerung, um Mehrfachzählungen zu vermeiden
        canhit = true;  // Nach der Verzögerung wieder Kollisionen zulassen
    }

    // Update der Punkteanzeige im UI
    private void UpdateScoreText()
    {
        pointsText.text = "Score: " + score;  // Den Text des UI-Elements auf den aktuellen Punktestand setzen
    }

    // Überprüfen, ob das Spiel vorbei ist (wenn der Score 0 oder kleiner ist)
    private void CheckGameOver()
    {
        if (score <= 0)
        {
            gameOverScreen.SetActive(true);  // Game Over Canvas aktivieren
            Time.timeScale = 0;  // Das Spiel pausieren
        }
    }
}
