using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateApples : MonoBehaviour
{
    // Link to prefab added to script in inspector
    public GameObject thing;

    // Number of apples in each dimension
    public int numberOfApples = 7;

    // Initial position for the first apple 
    public float initialX = -10f;
    public float initialY = 3f;

    // Distance between apples in y axis (vertical)
    public float distance = 0.7f;

    // Distance between apples in x axis (horizontal)
    public float distanceHorizontal = 3f;

    // Start is called before the first frame update
    void Start()
    {
        // Generate apples for the y axis
        for (int i = 0; i < numberOfApples; i++)
        {
            float y = initialY - i * distance;

            Debug.Log("X: " + initialX + " Y: " + y);

            Instantiate(thing, new Vector3(initialX, y, 0), Quaternion.Euler(0, 0, 0));
        }

        for (int i = 0; i < numberOfApples; i++)
        {
            float y = initialY - i * distance;

            Instantiate(thing, new Vector3(initialX + 18, y, 0), Quaternion.Euler(0, 0, 0));
        }

        // Generate apples for the x axis
        for (int i = 0; i < numberOfApples; i++)
        {
            float x = initialX + i * distanceHorizontal;

            Instantiate(thing, new Vector3(x, initialY + distance, 0), Quaternion.Euler(0, 0, 0));
        }

        for (int i = 0; i < numberOfApples; i++)
        {
            float x = initialX + i * distanceHorizontal;

            Instantiate(thing, new Vector3(x, -3.3f, 0), Quaternion.Euler(0, 0, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
