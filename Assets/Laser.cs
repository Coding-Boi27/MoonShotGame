using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    /* private LineRenderer lineRenderer;
    private int maxLenght = 100;
    private int maxReflections = 5;
    private int countLaser = 1;

    private Vector3 pos = new Vector3();
    private Vector3 dir = new Vector3();

    private bool isActive = true;

    // Start is called before the first frame update
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            DrawLaser();
        }
    }

    private void DrawLaser()
    {
        lineRenderer.positionCount = 0;

        isActive = true;
        pos = transform.position;
        dir = Camera.main.WorldToScreenPoint(Input.mousePosition) - pos;

        lineRenderer.positionCount = countLaser;
        lineRenderer.SetPosition(0, pos);

        while (isActive)
        {
            RaycastHit2D hit = Physics2D.Raycast(pos, dir, maxLenght);

            if (hit && !hit.collider.CompareTag("Player") && !hit.collider.CompareTag("Laser"))
            {

                Debug.Log("We hit: " + hit.collider.tag);

                countLaser++;

                lineRenderer.positionCount = countLaser;

                dir = Vector2.Reflect(dir, hit.normal);
                pos = hit.point;

                lineRenderer.SetPosition(countLaser - 1, pos);
            } else
            {
                countLaser++;

                lineRenderer.positionCount = countLaser;
                lineRenderer.SetPosition(countLaser - 1, pos + (dir.normalized * maxLenght));

                isActive = false;
            }

            if (countLaser > maxReflections)
            {
                isActive = false;
            }
        }
    } */

    private const int Infinity = 999;

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
    }
}