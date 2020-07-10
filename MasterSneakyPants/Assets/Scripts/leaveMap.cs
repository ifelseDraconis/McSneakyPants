using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leaveMap : MonoBehaviour
{
    public GameManager instance;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "Player") & GameManager.instance.canEndGame())
        {
            // code to end the game
            UnityEngine.Debug.Log("You have beaten the game!");
        }
        else
        {
            UnityEngine.Debug.Log("You can't leave without the key ring.");
        }
    }
}
