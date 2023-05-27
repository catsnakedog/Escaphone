using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow : MonoBehaviour
{
    public List<Vector2> waypoints = new List<Vector2>();
    public float speed = 5f;

    private int currentWaypoint = 0;
    private bool isMoving = false;

    private void Update()
    {
        if (isMoving && currentWaypoint < waypoints.Count)
        {

            Vector2 direction = waypoints[currentWaypoint] - (Vector2)transform.position;

            float distanceToMove = speed * Time.deltaTime;
            Vector2 movement = direction.normalized * distanceToMove;

            transform.Translate(movement);

            if (Vector2.Distance(transform.position, waypoints[currentWaypoint]) <= distanceToMove)
            {
                currentWaypoint++;
            }
        }
    }

    private void OnMouseDown()
    {
        if (!isMoving)
        {
            isMoving = true;
        }
    }

    public void AddWaypoint(Vector2 waypoint)
    {
        waypoints.Add(waypoint);
    }
}
