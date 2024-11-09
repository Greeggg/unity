using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControler : MonoBehaviour
{
    public Rigidbody rb;
    private float turnSpeed = 50.0f;
    public float forceStrength = 0.1f;
    private Vector3 pos;
    private GameObject direction;
    public bool swim; // True, sobald der Pfeil in Bewegung ist. Der Name 'swim' ist unglücklich gewählt, wurde jedoch nicht geändert, da er in mehreren Skripten verwendet wird.
    public GameObject cursor;
    public float gravity = 0.1f;
    private Vector3 kraft;
    private float mouseX;
    private float mouseY;
    private Vector3 direct;
    private float rightLeft; // Wert, ob die Kraft nach rechts oder links wirkt.
    public float stärke = 0;
    public GameObject arrow;
    private float center;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        direction = GameObject.Find("Direction");
        swim = false;
        center = Screen.width * 0.5f; // Mittelpunkt des Bildschirms.
    }
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Wenn die Leertaste gedrückt wird...
        {
            swim = true;    
            powerBar.siliderpos = false; // siliderpos des PowerBar-Skripts wird auf false gesetzt.
            cursor.gameObject.SetActive(false); // Cursor wird ausgeblendet.
        }

        if (!powerBar.siliderpos) // Funktion, um die Position der PowerBar zu übernehmen. Nicht direkt bei "Wenn Leertaste gedrückt wird", da das PowerBar-Skript sonst keine Zeit zur Ausführung hat.
        {
            forceStrength = powerBar.poweranzahl;
        }

        if (swim) // Wenn der Pfeil in der Luft ist...
        {
            mouseX = Input.mousePosition.x; // Position des Zeigers.

            if (mouseX > center)  // Zeiger auf der rechten Seite.
            {
                rightLeft = stärke;
            }
            if (mouseX < center) // Zeiger auf der linken Seite.
            {
                rightLeft = -stärke;
            }
            direct = new Vector3(1, 0, 0); // Vektor, um nach links oder rechts zu steuern.
        }

        float moveX = Input.GetAxis("Horizontal"); 
        float moveY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveX, moveY, 0) * turnSpeed * Time.deltaTime; 
        cursor.transform.position += movement;

        pos = direction.transform.position; // Position des GameObjects "direction", das auf dem Cursor liegt.
        kraft = new Vector3(0, -1, 0); // Vektor für die Gravitation. Zeigt nach unten.
    }

    private void FixedUpdate() // Funktion für physikbasierte Funktionen.
    {
        if (swim)
        {
            rb.AddForce(pos * forceStrength); // Kraft in Richtung des Vektors "pos".
            rb.AddForce(kraft * gravity); // Kraft für die Gravitation.
            rb.AddForce(direct * rightLeft); // Kraft zum Steuern nach links oder rechts.
        }
    }
}
