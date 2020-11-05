using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    /* private const int Infinity = 999;

    private int maxReflections = 10;
    private int currentReflections = 0;

    [SerializeField]
    private Vector2 startPoint, direction;
    private List<Vector3> Points;
    private int defaultRayDistance = 100;
    private LineRenderer lr;

    public Transform t;

    // Use this for initialization
    void Start()
    {
        Points = new List<Vector3>();
        lr = transform.GetComponent<LineRenderer>();

        startPoint = t.position;
        Vector2 vector3 = Camera.main.WorldToScreenPoint(Input.mousePosition);
        direction = vector3 - startPoint;
    }

    private void Update()
    {
        var hitData = Physics2D.Raycast(startPoint, (direction - startPoint).normalized, defaultRayDistance);

        currentReflections = 0;
        Points.Clear();
        Points.Add(startPoint);

        if (hitData && !hitData.collider.CompareTag("Player") && !hitData.collider.CompareTag("Laser"))
        {
            ReflectFurther(startPoint, hitData);
        }
        else
        {
            Points.Add(startPoint + (direction - startPoint).normalized * Infinity);
        }

        lr.positionCount = Points.Count;
        lr.SetPositions(Points.ToArray());
    }

    private void ReflectFurther(Vector2 origin, RaycastHit2D hitData)
    {
        if (currentReflections > maxReflections) return;

        Points.Add(hitData.point);
        currentReflections++;

        Vector2 inDirection = (hitData.point - origin).normalized;
        Vector2 newDirection = Vector2.Reflect(inDirection, hitData.normal);

        var newHitData = Physics2D.Raycast(hitData.point + (newDirection * 0.0001f), newDirection * 100, defaultRayDistance);
        if (newHitData && !newHitData.collider.CompareTag("Player") && !newHitData.collider.CompareTag("Laser"))
        {

            ReflectFurther(hitData.point, newHitData);
        }
        else
        {
            Points.Add(hitData.point + newDirection * defaultRayDistance);
        }
    } */

    private void Start()
    {
        Debug.Log(this.gameObject.transform.position);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Debug.Log(this.gameObject.transform.position);
    }
}