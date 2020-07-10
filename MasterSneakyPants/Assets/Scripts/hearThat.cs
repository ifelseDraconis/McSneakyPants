using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hearThat : MonoBehaviour
{
    private GameObject thatPrick;
    private Transform thatPricksLocation;
    private ZombieThisness heyMaggotBait;
    public GameObject thisZombie;

    private int x, y;

    void Start()
    {
        heyMaggotBait = thisZombie.GetComponent<ZombieThisness>();
        if (thatPrick == null)
        {
            thatPrick = GameObject.FindWithTag("Player");
            thatPricksLocation = thatPrick.GetComponent<Transform>();
        }
        if (thatPricksLocation == null)
        {
            thatPricksLocation = thatPrick.GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // this is to deal with the player object being created and destroyed as an instance
        if (thatPrick == null)
        {
            thatPrick = GameObject.FindWithTag("Player");
            thatPricksLocation = thatPrick.GetComponent<Transform>();
        }
        if (thatPricksLocation == null)
        {
            thatPricksLocation = thatPrick.GetComponent<Transform>();
        }
        
    }

    // this collision only does something when the zombie collides with the player noise,
    // could also be used to check collision with other things
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerNoise")
        {
            // Code here to trigger that the player was heard
            UnityEngine.Debug.Log("I heard the player at " + thatPricksLocation.localPosition.x + " and " + thatPricksLocation.localPosition.y + "!");
        }
    }
}
