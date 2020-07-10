using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class moveToNext : MonoBehaviour
{
    public GameObject thisWayPoint;
    public Transform thisLocation;
    public GameObject nextWayPoint;
    private GameObject ordersTo;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // passes guidance orders to the zombie pawn when it hits the waypoint
        if (other.tag == "Baddie")
        {
            ordersTo = GameObject.FindWithTag("Baddie");
            ordersTo.GetComponent<ZombieThisness>().theNextWaypoint = nextWayPoint;
            ordersTo.GetComponent<ZombieThisness>().nextWaypointLocation = nextWayPoint.GetComponent<Transform>();
        }
    }
}
