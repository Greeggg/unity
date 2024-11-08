using System.Collections;
using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{
    public float score = 20;
    private bool canhit;
    private float scoreCooldown = 0.1f;
    public TextMeshProUGUI pointsText;  // TextMeshProUGUI f�r die Punkteanzeige
    public GameObject gameOverScreen;   // Game Over Canvas

    void Start()
    {
        canhit = true;
        gameOverScreen.SetActive(false);  // Canvas zu Beginn deaktivieren
        UpdateScoreText();  // Zu Beginn die Punkteanzeige setzen
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canhit)
        {
            Debug.Log("Kollision erkannt mit: " + other.gameObject.name); // Zum Debuggen

            // �berpr�fen, welcher Ring getroffen wurde und den Punktestand anpassen
            if (other.CompareTag("ring1") || other.CompareTag("ring2"))
                score -= 1;
            else if (other.CompareTag("ring3") || other.CompareTag("ring4"))
                score -= 3;
            else if (other.CompareTag("ring5") || other.CompareTag("ring6"))
                score -= 5;
            else if (other.CompareTag("ring7"))
                score -= 10;

            // Wenn der Score unter 0 f�llt, setze ihn auf 0
            if (score < 0)
                score = 0;

            UpdateScoreText();  // Score-Anzeige aktualisieren
            CheckGameOver();    // �berpr�fen, ob das Spiel vorbei ist
            canhit = false;     // Kollisionen f�r kurze Zeit deaktivieren
            StartCoroutine(ScoreCooldown());  // Verz�gerung einbauen, um mehrfaches Z�hlen zu verhindern
        }
    }

    private IEnumerator ScoreCooldown()
    {
        yield return new WaitForSeconds(scoreCooldown);  // Verz�gerung
        canhit = true;  // Nach der Verz�gerung wieder Kollisionen zulassen
    }

    private void UpdateScoreText()
    {
        // Aktualisieren des Textes im UI-Element
        Debug.Log("Aktueller Score: " + score);  // Zum Debuggen
        pointsText.text = "Score: " + score;
    }

    private void CheckGameOver()
    {
        // Wenn der Score 0 oder kleiner ist, Game Over anzeigen
        if (score <= 0)
        {
            gameOverScreen.SetActive(true);  // Game Over Screen aktivieren
            Time.timeScale = 0;  // Das Spiel pausieren
        }
    }
}
