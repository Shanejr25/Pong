using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour {

    // create instance of the ball object
    public Ball theBall;

    public float speed = 30;

    // create a smooth transition from one position to another postion
    // using lerpTweak
    public float lerpTweak = 2f;

    private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {

        // get the rigidbody component
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
        // make the paddle move in relation to the change in y value of the ball
        if(theBall.transform.position.y > transform.position.y)
        {
            Vector2 dir = new Vector2(0, 1).normalized;

            // time.deltatime is used to move the paddle in relation to the games frame rate
            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, dir * speed,
                lerpTweak * Time.deltaTime); 
        
        // if the ball position is lower than the paddle position, do something else
        } else if (theBall.transform.position.y < transform.position.y)
            {
                // decrease the y position of the paddle
                Vector2 dir = new Vector2(0, -1).normalized;

                // time.deltatime is used to move the paddle in relation to the games frame rate
                rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, dir * speed,
                    lerpTweak * Time.deltaTime);
            }
        else {
            // set the paddle to the center of the wall
            Vector2 dir = new Vector2(0, 0).normalized;
            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, dir * speed,
                    lerpTweak * Time.deltaTime);
        }
    }
}
