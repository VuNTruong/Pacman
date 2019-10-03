using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    Rigidbody2D rb; // Rigidbody physics component
    Animator anim; // Animator component

    public string targettag = "pacman";
    public float speed = 0.01f;
    private bool goHome = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the target object with this tag
        GameObject targetObject = GameObject.FindWithTag(targettag);

        // Get its Rigidbody component so can get its position
        Rigidbody2D targetRb = targetObject.GetComponent<Rigidbody2D>();

        if (goHome == false)
        {
            // Get difference between current and target location
            Vector2 delta = targetRb.position - rb.position;

            delta.Normalize();

            // Multiply be speed
            delta = delta * speed;

            // Use this to change position
            rb.position += delta;
        }
        else
        {
            // Go back to the house
            
            // House position
            float houseX = 0f;
            float houseY = 0f;

            // House position vector 
            Vector2 housePositionVector = new Vector2(houseX, houseY);
            // Get difference between current and target location
            Vector2 delta = housePositionVector - rb.position;

            
            delta.Normalize();

            // Multiply be speed
            delta = delta * speed;

            // Use this to change position
            rb.position += delta;
           
        }

    }

    void OnCollisionEnter2D (Collision2D col)
    {
        GameObject gameObject = col.gameObject;

        if (gameObject.CompareTag("pacman"))
        {
            speed = 0;
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        GameObject gameObject = col.gameObject;

        if (gameObject.CompareTag("key"))
        {
            // Change the animation to ghost eye and go back to the house
            // Make the ghost go home by setting goHome to true
            goHome = true;

            // Change animation to ghost eye
            anim.SetBool("gohome", true);
        }
        if (gameObject.CompareTag("home"))
        {
            // Bring the ghost back 
            // Set the goHome variable to false, so that the ghost start
            // chasing the player again
            goHome = false;

            // Change the animation to ghost animation
            anim.SetBool("gohome", false);
        }
    }

}
