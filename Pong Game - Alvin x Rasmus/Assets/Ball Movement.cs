using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    [SerializeField] private float initialSpeed = 10;
    [SerializeField] private float speedIncrease = 0.25f;
    [SerializeField] private Text player1Score;
    [SerializeField] private Text player2Score;

    private int hitCounter;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("StartBall", 2f);
    }
    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, initialSpeed + (speedIncrease * hitCounter));
    }
    private void StartBall()
    {
        rb.velocity = new Vector2(-1, 0) * (initialSpeed + speedIncrease * hitCounter); 
    }
    private void ResetBall()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
        Invoke("StartBall", 2f); 
    }

    private void PlayerBounce(Transform myObject)
    {
        hitCounter++;
        Vector2 ballPos = transform.position;
        Vector2 playerPos = myObject.position;

        float xDirection, yDirection; 
        if(transform.position.x > 0)
        {
            xDirection = -1; 
        }
        else
        {
            xDirection = 1; 
        }
        yDirection = (ballPos.y - playerPos.y) / myObject.GetComponent<Collider2D>().bounds.size.y; 
        if(yDirection == 0)
        {
            yDirection = 0.25f;  
        }
        rb.velocity = new Vector2(xDirection, yDirection) * (initialSpeed + (speedIncrease * hitCounter)); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player" || collision.gameObject.name == "Player2")
        {
            PlayerBounce(collision.transform);
            AudioSource audio = collision.transform.GetComponent<AudioSource>();
            audio.Play(0);
        }
        else if(collision.gameObject.CompareTag("Wall"))
        {
            AudioSource audio = collision.transform.GetComponent<AudioSource>();
            audio.Play(0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.x > 0)
        {
            ResetBall();
            player1Score.text = (int.Parse(player1Score.text) + 1).ToString();
        }
        else if (transform.position.x < 0) ;
        {
            ResetBall();
            player2Score.text = (int.Parse(player2Score.text) + 1).ToString(); 
        }

    }
}
