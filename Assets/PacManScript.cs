using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManScript : MonoBehaviour
{
    public float speed = 0.01f;
    Rigidbody2D rb;

    // boolean to decide if the game has ended or not
    bool isEndGame = false;

    // variable to hold number of apples
    // will decrement each time collide with apple
    int appleCount = 28;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component of this object
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        // Set initial endgame to false
        anim.SetBool("endgame", false);
    }

    // Update is called once per frame
    void Update()
    {

        // Amount to move in each dimension
        float dx = 0;
        float dy = 0;

        // Input.GetKey(key) returns true if that key is currently down
        // KeyCode.keyname is used for keys that don'w correspond to an ASCII char

        if (!isEndGame && appleCount > 0)
        {
            // Move up
            if (Input.GetKey(KeyCode.UpArrow))
            {
                dy = speed;
                rb.SetRotation(90);
            }
            // Move down
            if (Input.GetKey(KeyCode.DownArrow))
            {
                dy = -speed;
                rb.SetRotation(270);
            }
            // Move left
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                dx = -speed;
                rb.SetRotation(180);
            }
            // Move right
            if (Input.GetKey(KeyCode.RightArrow))
            {
                dx = speed;
                rb.SetRotation(0);
            }
        }
        else
        {
            GameObject ghost = GameObject.FindWithTag("ghost");
            ghost.GetComponent<Rigidbody2D>().isKinematic = true;
        }

        // Move by that amount
        rb.position += new Vector2(dx, dy);

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject gameObject = col.gameObject;

        if (gameObject.CompareTag("apple"))
        {
            GameObject.Destroy(gameObject);

            // Decrement the apple count
            appleCount -= 1;
        }

        if (gameObject.CompareTag("ghost"))
        {
            // Set the boolean for endgame to true when collide with the ghost
            anim.SetBool("endgame", true);

            // Set the isEndGame to true so that pacman will stop moving
            isEndGame = true;
        }
    }

}
