using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncing : MonoBehaviour
{
    public float jumpForce = 10;  // Adjust the jump force as needed
    private AudioSource soundeffect;
    private Rigidbody2D ball;
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
        soundeffect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ball.velocity = new Vector2(ball.velocity.x, ball.velocity.y + 5);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ball.velocity = new Vector2(ball.velocity.x, ball.velocity.y -2);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ball.velocity = new Vector2(ball.velocity.x -2, ball.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ball.velocity = new Vector2(ball.velocity.x + 2, ball.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        soundeffect.Play();
        ball.velocity = new Vector2(ball.velocity.x, ball.velocity.y + 10);

    }

}

