using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {

	public float moveSpeed = 200f;
	public GameObject ball;

    public float ballForceMagnitude;  // this will show up on the interface 

    //Cache this reference so we don't need to look it up over and over
    private Rigidbody ballBody;
	// Use this for initialization
	void Start () {
		ballBody = ball.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		if(ballBody.isKinematic)
		{
			//We can use Sin to oscillate between 1 and -1.
			ball.transform.position = new Vector3(this.transform.position.x + Mathf.Sin(Time.realtimeSinceStartup), this.transform.position.y + 1f, this.transform.position.z);
		}

		if( Input.GetKey(KeyCode.RightArrow) && this.transform.position.x < GameObject.Find("Board").GetComponent<GameBoardGenerator>().boardWidth + 1 )  //position of paddle (<:less than) boardWidth
		{
			this.transform.position = new Vector3((this.transform.position.x + (moveSpeed * Time.deltaTime)), this.transform.position.y, this.transform.position.z);

        }

		if(Input.GetKey(KeyCode.LeftArrow) && this.transform.position.x > GameObject.Find("Board").GetComponent<GameBoardGenerator>().boardWidth - 4) // 4 should be witdh of paddle? = this.transform.localScale.x (Width of Paddle)_
        {
			this.transform.position = new Vector3(this.transform.position.x - (moveSpeed * Time.deltaTime), this.transform.position.y, this.transform.position.z);
		}

		if(Input.GetKey(KeyCode.Space))
		{
			if(ballBody.isKinematic) // gets ball moving
			{
				ballBody.isKinematic = false; //set to become boundry - but continues to move 
				ball.transform.LookAt(this.gameObject.transform);
                ballBody.AddForce(ball.transform.forward.normalized * ballForceMagnitude, ForceMode.VelocityChange);  
                //ballBody.AddForce(ball.transform.forward.normalized * 5f, ForceMode.VelocityChange);
            }

		}

	}

    // destroy paddle when collide with walls
    public void OnCollisionEnter(Collision collisionWith)
    {
        // if colided object has tag "Ball" - that has this script
       // if (col.gameObject.name == "prop_powerCube")
       // {
            // set ball back to Kinematic - snaps back to paddle
        //    Rigidbody ballBody = collisionWith.gameObject.GetComponent<Rigidbody>(); // look at start() in PaddleController.cs
        //    ballBody.isKinematic = true;
       // }


       if (collisionWith.gameObject.tag == "Wall")
        {
            Debug.Log("Wall collison");
        }
    }


}








