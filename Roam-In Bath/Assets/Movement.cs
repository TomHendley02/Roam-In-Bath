using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform[] waypoints;//it is public so it show the inspector.
    private int currentWaypointIndex;
    private float speed = 1;

    private float waitTime = 36f; //This is in seconds.
    private float waitCounter = 0f;
    private bool waiting = false;

    private void Update()
    {
        if (waiting)
        {
            waitCounter += Time.deltaTime;
            if (waitCounter < waitTime)
            {
                return;
                waiting = false;
            }
        }

        Transform wp = waypoints[currentWaypointIndex];
        if (Vector3.Distance(transform.position, wp.position) < 0.01f)
        {
            transform.position = wp.position;
            waitCounter = 0f;
            waiting = true;

            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, wp.position, (speed % 2) * Time.deltaTime);
        }
    }
}
