using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wayPointMover : MonoBehaviour
{
    // Stores a reference to the waypoint system.
    [SerializeField] private waypoints waypoints;

    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private float distanceThreshold = 0.1f;

    private Transform currentWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        //This is to set the player at the original waypoint
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        //Getting to the next waypoint
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        }
    }
}