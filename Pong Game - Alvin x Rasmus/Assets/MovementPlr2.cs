using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlr2 : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float speed = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.K))
        {
            transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
        }
    }
}
