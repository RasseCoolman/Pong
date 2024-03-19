using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallUp : MonoBehaviour
{
    public Rigidbody2D rb;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector2.right * 0.02f, ForceMode2D.Force);
    }
    void OnCollisionEnter(Collision collision)
    {
        {
            // Check if collision is with a wall
            if (collision.collider.CompareTag("Wall"))
            {

                // Calculate the reflection vector
                Vector2 reflection = Vector2.Reflect(rb.velocity, collision.contacts[0].normal);
                // Apply the reflection vector as a force
                rb.AddForce(reflection, ForceMode2D.Force);
            }
        }
    }
}
