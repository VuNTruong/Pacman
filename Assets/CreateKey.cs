using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateKey : MonoBehaviour
{
    // Link to prefab added to script in inspector
    public GameObject thing;
    
    // Create key at these points
    public float X1 = -8f;
    public float Y1 = 2f;

    public float X2 = 8f;
    public float Y2 = -2f;

    public float X3 = -8f;
    public float Y3 = -2;

    public float X4 = 8f;
    public float Y4 = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(thing, new Vector3(X1, Y1, 0), Quaternion.Euler(0, 0, 0));
        Instantiate(thing, new Vector3(X2, Y2, 0), Quaternion.Euler(0, 0, 0));
        Instantiate(thing, new Vector3(X3, Y3, 0), Quaternion.Euler(0, 0, 0));
        Instantiate(thing, new Vector3(X4, Y4, 0), Quaternion.Euler(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
