using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody rb;
    public float moveSpeed;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        // object actually move by setting the velocity of the Rigidbody 

        
    }

    // Update is called once per frame
    void Update () {

        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(inputH, 0, inputV);

        rb.velocity = direction * moveSpeed;


        //inputs range from -5 to 5, 
        // velocity will be between those values in either the x or z 
        //directions with a max of (5,0,5) and a min of (-5,0,-5) 



        // makes the bear look toward the direction it is going !!!
        if (rb.velocity.magnitude > 0)
        {
            transform.forward = direction;
        }
    }
}
