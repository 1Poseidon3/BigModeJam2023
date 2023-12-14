using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class capsuleMovement : MonoBehaviour
{
    public float speed = 2f;
    public float jump = 200f;
    public float wallCheckDistance = 0.001f;

    private bool canJump = true;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        Jump();
        if (Input.GetKeyDown(KeyCode.A))
        {
            spriteRenderer.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.flipX = false;
        }
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && canJump)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            canJump = false;
            FMODUnity.RuntimeManager.PlayOneShot("event:/MiniGame_Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Lava")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            FMODUnity.RuntimeManager.PlayOneShot("event:/MiniGame_Death");
        }
        else if (collision.transform.tag == "Ground")
        {
            canJump = true;
        }

    }




    
    

}
