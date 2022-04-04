using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{

    public int speed = 6;

    // Start is called before the first frame update
    void Start()
    {
        // Set the vertical speed to make the bullet move upward
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 v = rb.velocity;
        v.y = speed;
        rb.velocity = v;
    }

    // Gets called when the object goes out of the screen
    void OnBecameInvisible()
    {
        // Destroy the bullet
        Destroy(gameObject);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
