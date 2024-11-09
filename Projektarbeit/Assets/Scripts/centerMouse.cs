using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class centerMouse : MonoBehaviour
{
    private bool locked;
    void Start()
    {
        
    }
    void Update()
    {
        if(locked) 
        {
            Cursor.lockState = CursorLockMode.None; // Der Cursor kann sich frei bewegen
            locked = false; // Setzt "locked" auf false, damit dieser Block nicht erneut ausgeführt wird
        }

        if (Input.GetKeyDown("e"))  // Wenn die Taste "E" gedrückt wird, dann wird ...
        {
            Cursor.lockState = CursorLockMode.Locked;  // Der Cursor in die Mitte des Bildschirms fixiert und kann nicht bewegt werden
            locked = true; // Setzt "locked" auf true, wodurch der obige Block im nächsten Frame ausgeführt wird
        }
    }
}
