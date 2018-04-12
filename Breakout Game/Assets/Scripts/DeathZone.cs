using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Destroy a block when the ball hits it, and make a nice shiny explosion effect.
	public void OnCollisionEnter(Collision collisionWith)
	{
        // if colided object has tag "Ball" - that has this script
        if (collisionWith.gameObject.tag == "Ball")
        {
            // set ball back to Kinematic - snaps back to paddle
            Rigidbody ballBody = collisionWith.gameObject.GetComponent<Rigidbody>(); // look at start() in PaddleController.cs
            ballBody.isKinematic = true;
            Debug.Log("Ball Falls");
        }

        // if colided object has tag "Ball" - that has this script
        
        else
        {
        }

        
    }
}
