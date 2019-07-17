using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ball : MonoBehaviour {

    // monitor the speed
    public float speed = 30;

    private Rigidbody2D rigidBody;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {

        // connect the rigid body object to the unity object
        rigidBody = GetComponent<Rigidbody2D>();
        // define direction and speed of the ball
        rigidBody.velocity = Vector2.right * speed;

	}

    // Called every time a ball collides with something
    // the object it hit is passed as a parameter
    void OnCollisionEnter2D(Collision2D collision)
    {
        // check if LeftPaddle or RightPaddle was collided with
        if ((collision.gameObject.name == "LeftPaddle") ||
            (collision.gameObject.name == "RightPaddle"))
        {
            // set the angle the ball moves after hitting paddle
            HandlePaddleHit(collision);
        }
        // check if WallBottom or WallTop was collided with
         if ((collision.gameObject.name == "WallTop") ||
            (collision.gameObject.name == "WallBottom"))
        {
            // play a sound 
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.wallBloop);
        }
        // check if LeftGoal or RightGoal was collided with
        if ((collision.gameObject.name == "LeftGoal") ||
            (collision.gameObject.name == "RightGoal"))
        {
            // play a sound 
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.goalBloop);

            // Update the score UI
            if (collision.gameObject.name == "LeftGoal")
            {
                // increment the right score UI
                IncreaseTextUIScore("RightScoreUI");
            }
            if (collision.gameObject.name == "RightGoal")
            {
                // increment the right score UI
                IncreaseTextUIScore("LeftScoreUI");
            }
            // move the ball position to the middle of the screen
            transform.position = new Vector2(0, 0);
        }
    }

    void HandlePaddleHit(Collision2D collision)
    {
        float y = BallHitPaddleWhere(transform.position,
                collision.transform.position,
                collision.collider.bounds.size.y);

        /*
         * Vector info:
         * Straight up is (0,1)
         * Straight down is (0,-1)
         * 
         * High value of 1, low of -1. Range of (-1, 1)
         */
        Vector2 dir = new Vector2();

        if (collision.gameObject.name == "LeftPaddle")
        {
            // hit left paddle, move the ball to the right which is 1
            dir = new Vector2(1, y).normalized;
        }
        if (collision.gameObject.name == "RightPaddle")
        {
            // hit right paddle, move the ball to the left which is -1
            dir = new Vector2(-1, y).normalized;
        }
        /*
        // increment the ball speed by 1
        speed++;
        // display the change in speed
        var BallTextUIComp = GameObject.Find("BallSpeedUI").GetComponent<Text>();

        // get the string that is stored inside the element
        int count = int.Parse(BallTextUIComp.text);
        
        count++;

        // store the new value into the score value
        BallTextUIComp.text = count.ToString();
        */
        // change the velocity direction of the ball
        rigidBody.velocity = dir * speed;
        
        // play a sound 
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.hitPaddleBloop);
    }

    float BallHitPaddleWhere(Vector2 ball, Vector2 paddle, float paddleHeight)
    {
        // return the position where the ball hit the paddle (y direction)
        return (ball.y - paddle.y) / paddleHeight;
    }

    void IncreaseTextUIScore (string textUIName)
    {
        var textUIComp = GameObject.Find(textUIName).GetComponent<Text>();

        // get the string that is stored inside the element
        int score = int.Parse(textUIComp.text);

        score++;

        // store the new value into the score value
        textUIComp.text = score.ToString();
    }
}
