using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float moveSpeed = 5f;
    private Vector2 movement;

    public Rigidbody2D rb;
    public SpriteRenderer sr; 

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (movement.x < 0)
        {
            sr.flipX = true;
        } else if (movement.x > 0)
        {
            sr.flipX = false;
        }

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
