using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowArrow : MonoBehaviour
{
    public GameObject Arrow;
    private Vector3 offset=new Vector3(0,2,-20);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position=Arrow.transform.position+ offset;
    }
}