using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject ring1;
    public GameObject ring2;
    public GameObject ring3;
    public GameObject ring4;
    public GameObject ring5;
    public GameObject ring6;
    public GameObject ring7;
    public float score = 20 ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter( Collider other)
    {
        if (other.gameObject == ring1)
        {
            Debug.Log("ring1");
            score-=1;
        }
        if (other.gameObject == ring2)
        {
            Debug.Log("ring2");
            score-=1;
        }
        if (other.gameObject == ring3)
        {
            Debug.Log("ring3");
            score-=3;
        }
        if (other.gameObject == ring4)
        {
            Debug.Log("ring4");
            score-=3;
        }
        if (other.gameObject == ring5)
        {
            Debug.Log("ring5");
            score-=5;
        }
        if (other.gameObject == ring6)
        {
            Debug.Log("ring6");
            score-=5;
        }
        if (other.gameObject == ring7)
        {
            Debug.Log("ring7");
            score-=10;
        }
        Debug.Log(score);
    }
}
