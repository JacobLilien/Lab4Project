using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncing : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the Rigidbody2D component if not assigned in the Inspector
    }

    // Update is called once per frame
    void Update()
    {
        // Check for the "ui_up" key press
        if (Input.GetKey("up"))
        {
            Vector2 move = new Vector2(0, 10);
        }
    }
}