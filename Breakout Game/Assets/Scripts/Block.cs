using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	
	public GameObject explosionEffect;

	//Destroy a block when the ball hits it, and make a nice shiny explosion effect.
	public void OnCollisionEnter(Collision collisionWith)
	{
        // if collided object has this script, and is collided with object tagged ball
		if(collisionWith.gameObject.tag == "Ball")
		{
            /// This Destroy method destroys an explosion object in 0.5 seconds after it is created with Instantiate
			Destroy((GameObject)Instantiate(explosionEffect, collisionWith.gameObject.transform.position, collisionWith.gameObject.transform.rotation), 0.5f);
			Destroy(this.gameObject); // destroys the block
		}
	}
}
