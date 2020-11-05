using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    /* private float backSpace = 50f;
    private Vector2 dir;
    private Vector3 mouse; */

    private Vector3 ballPoint;
    private Vector3 clickPoint;

    public Rigidbody2D rb;

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
        /* mouse = new Vector2(Camera.main.WorldToScreenPoint(Input.mousePosition).x, Camera.main.WorldToScreenPoint(Input.mousePosition).y);
        dir = new Vector2(Camera.main.WorldToScreenPoint(Input.mousePosition).x, Camera.main.WorldToScreenPoint(Input.mousePosition).y) - rb.position;
        rb.AddForce(Vector2.left * backSpace);

        Debug.Log(dir); */

        ballPoint = rb.position;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        clickPoint = ray.GetPoint(10);
        clickPoint.z = 0;

        // Debug.Log("Player positon: " + ballPoint);
        // Debug.Log("ClickPoint: " + ray + " | " + clickPoint);

        Vector3 newVector = ballPoint - clickPoint;
        newVector.Normalize();

        Debug.Log("New Vector: " + newVector);

        rb.AddForce(newVector * 20, ForceMode2D.Impulse);
    }
}