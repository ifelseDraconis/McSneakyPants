using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class killYou : MonoBehaviour
{
    public GameObject thisPlayer;
    private Transform thisPricksLocation;
    private float killDistance;
    public GameObject thisZombie;

    void Start()
    {
        if (thisPlayer == null)
        {
            thisPlayer = GameObject.FindWithTag("Player");
            thisPricksLocation = thisPlayer.GetComponent<Transform>();
            killDistance = GameManager.instance.killDistance;

        }
    }
    // this script triggers when the player gets punched in the face
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            float dist = Vector3.Distance(thisZombie.GetComponent<Transform>().localPosition, thisPlayer.GetComponent<Transform>().localPosition);
            if (dist <= killDistance) 
            { 
                // code to kill the player character
                other.GetComponent<PlayerController>().arrghMyFace();
            }
        }

    }
}
