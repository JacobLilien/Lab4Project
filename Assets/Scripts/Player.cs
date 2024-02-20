using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public float health, maxHealth = 10f;
    //[Serialized Field] FloatingHealthBar healthBar;
    public float speed = 40f;
    private float horizontalMovement = 0f;
    private bool facingRight = true;
    private AudioSource soundeffect;
    public UnityEvent myEvents;


    Rigidbody2D rb;
    public Animator animator;
    //public new Animation animation;
    
    // Start is called before the first frame update
    private void Awake()
    {
        //healthBar = GetComponentInChildren<FloatingHealthBar>();
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //animation = GetComponent<Animation>();
        soundeffect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));
        //animator.SetBool("Collides", false);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Play the animation named "YourAnimationClipName"
            print(animator.name);
            //Play("YourAnimationClipName");
        }
        horizontalMovement = Input.GetAxisRaw("Horizontal") * speed;

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
        rb.velocity = new Vector2(7 * horizontalMovement * Time.fixedDeltaTime, rb.velocity.y);
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject collidedObject = col.gameObject;
        animator.SetTrigger("Jump");

        // Now you can do something with the collided object
        Debug.Log("Collided with: " + collidedObject.name);
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 10);
        if (collidedObject.name == "Grass-2")
        {

        }
        else
        {
            Destroy(collidedObject);
            soundeffect.Play();
        }       

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (myEvents == null)
        {

        }
        else
        {
            myEvents.Invoke();
        }
    }
    
}