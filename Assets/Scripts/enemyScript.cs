using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    // Public variable that contains the speed of the enemy
    public int speed = -5;

    public GameObject fireEffect;

    public static int score = 10;
    public static int life = 5;

    public AudioClip myClip;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 v = rb.velocity;
        v.x = 0;
        v.y = speed;
        rb.velocity = v;
        rb.angularVelocity = Random.Range(-200, 200);
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //function called when the enemy collides with another object
    void OnTriggerEnter2D(Collider2D obj)
    {
        string name = obj.gameObject.name;

        // if collided with bullet
        if (name == "bullet(Clone)")
        {
            Instantiate(fireEffect, transform.position,Quaternion.identity);
            AudioSource.PlayClipAtPoint(myClip, transform.position); 
            score += 10; 

            // Destroy itself (the enemy)
            Destroy(gameObject);

            // And destroy the bullet
            Destroy(obj.gameObject);
        }

        // if collided with the spaceship
        if (name == "spaceship")
        {
            Instantiate(fireEffect, transform.position, Quaternion.identity); 
            AudioSource.PlayClipAtPoint(myClip, transform.position); 
            life -= 1;
            // destroy itself (the enemy) to keep things simple
            Destroy(gameObject);
        }
    }

    void OnGUI () {
        GUI.Label(new Rect(100, 0, 400, 400), "Score: " + score);
        GUI.Label(new Rect(100, 25, 400, 400), "Life: " + life);

        if (life <= 0)
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2, 500, 100), "Game Over!");
            Time.timeScale = 0;
        }
    } 

}
