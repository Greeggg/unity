using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerbar: MonoBehaviour
{
      // Movement speed of the object
    public float speed = 5f;

    // Limits for the X-axis movement
    public float limit = 30f;

    // Private variable to track the movement direction
    private int direction = 1;
    public GameObject silider;

    void Update()
    {
        // Move the object along the X-axis
        silider.transform.Translate(Vector3.right * speed * direction * Time.deltaTime);

        // Check if the object has reached the X limit, and reverse direction if it has
        if (transform.position.x >= limit || transform.position.x <= -limit)
        {
            direction *= -1; 
        }
    }
}
