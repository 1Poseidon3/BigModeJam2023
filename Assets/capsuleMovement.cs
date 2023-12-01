using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capsuleMovement : MonoBehaviour
{
    public float speed;
    private float move;
    
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(move * speed, rb.velocity.y);
    }
}
