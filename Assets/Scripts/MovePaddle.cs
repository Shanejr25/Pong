using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour {

    // global paddle speed that can be changed within Unity
    public float speed = 30;

    Rigidbody2D rb;
    bool currentPlatformAndroid = false;

     void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        #if UNITY_ANDROID
            currentPlatformAndroid = true;

        #else
            currentPlatformAndroid = false;
        #endif
    }

    void FixedUpdate()
    {
        if (currentPlatformAndroid == true)
        {
            // android specific code
            TouchMove();
        }
        else
        {
            float vertPress = Input.GetAxisRaw("Vertical");

            // set the velocity for the paddles
            // parameters (horizontal, vertical)
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, vertPress) * speed;
        }
    }

    void TouchMove()
    {
        if (Input.touchCount > 0)
        {
            // store the first touch
            Touch touch = Input.GetTouch(0);

            // check where the touch is on the screen
            float middle = Screen.width / 2;

            // touchphase began used to
            if (touch.position.x < middle && touch.phase == TouchPhase.Began)
            {
                MoveUp();
            }
            else if (touch.position.x > middle && touch.phase == TouchPhase.Began)
            {
                MoveDown();
            } 
        }
        else {
            SetVelocityZero();
        }
    }

    // Use this for initialization
    void Start () {
		if (currentPlatformAndroid == true)
        {
            Debug.Log("Android");
        } else
        {
            Debug.Log("Windows");
        }
	}
	public void MoveUp()
    {
        // give it a positive velocity so it moves up
        rb.velocity = new Vector2(0, speed);
    } 
    public void MoveDown()
    {
        rb.velocity = new Vector2(0, -speed);
    } 
    public void SetVelocityZero()
    {
        rb.velocity = new Vector2(0,0);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
