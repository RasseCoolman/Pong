using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody r;
    public float speed = 100;
    public float jump = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && transform.position.y < 4)
        {
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y > -4)
        {
            transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
        }
    }

    
}
