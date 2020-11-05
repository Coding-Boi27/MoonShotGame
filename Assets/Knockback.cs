using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    private float backSpace = 50f;
    private Vector3 dir;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        dir = Camera.main.WorldToScreenPoint(Input.mousePosition) - rb.position;
        rb.AddForce(Vector2.left * backSpace);
    }
}
