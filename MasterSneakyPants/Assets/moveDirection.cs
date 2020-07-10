using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveDirection : MonoBehaviour
{
    public GameObject thisWaypointSet;
    public GameObject firstWaypoint;
    public GameObject secondWaypoint;
    public GameObject thirdWaypoint;

    public void moveForward()
    {
        firstWaypoint.GetComponent<moveToNext>().nextWayPoint = secondWaypoint;
        secondWaypoint.GetComponent<moveToNext>().nextWayPoint = thirdWaypoint;
        thirdWaypoint.GetComponent<moveToNext>().nextWayPoint = secondWaypoint;
    }

    public void moveBackward()
    {
        firstWaypoint.GetComponent<moveToNext>().nextWayPoint = secondWaypoint;
        secondWaypoint.GetComponent<moveToNext>().nextWayPoint = firstWaypoint;
        thirdWaypoint.GetComponent<moveToNext>().nextWayPoint = secondWaypoint;
    }
}
