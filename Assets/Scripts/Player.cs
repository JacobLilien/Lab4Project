using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health, maxHealth = 10f;
    //[Serialized Field] FloatingHealthBar healthBar;
    public float speed = 40f;
    private float horizontalMovement = 0f;
    private bool facingRight = true;

    Rigidbody2D rb;
    public Animator animator;
    
    // Start is called before the first frame update
    private void Awake()
    {
        //healthBar = GetComponentInChildren<FloatingHealthBar>();
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));

        if (horizontalMovement > 0 && !facingRight)
        {
            Flip();
        }

        else if (horizontalMovement < 0 && facingRight)
        {
            Flip();
        }

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovement * Time.fixedDeltaTime, rb.velocity.y);
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
