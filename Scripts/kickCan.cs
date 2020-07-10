﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kickCan : MonoBehaviour
{
    private float noiseAmount;

    // determines the amount of sound generated by a step
    public float noisePerStep;

    // determines the rate at which the noise decays
    public float noiseDecayRate;

    public CircleCollider2D thisSoundRadius;

    void Start()
    {
        // this fetches the Collider Component
        thisSoundRadius = GetComponent<CircleCollider2D>();
        noiseAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // this code makes it so that the maxium amount of sound produced can't be more than a single footstep
        if (noiseAmount > noisePerStep)
        {
            noiseAmount = noisePerStep;
        }

        // this readjusts the size of the noise making circle when the player moves
        thisSoundRadius.radius = noiseAmount;

        // this decays the noise amount stored locally, allowing for the sound to 'fade'
        noiseAmount -= noiseDecayRate;

        // this disables the collider if the player hasn't made noise recently, and re-enables it if it is disabled and the player makes noise.
        if (noiseAmount <= 0)
        {
            thisSoundRadius.enabled = false;
        }
        else
        {
            if (thisSoundRadius.enabled == false)
            {
                thisSoundRadius.enabled = true;
            }
        }
    }

    public void tookAStep()
    {
        noiseAmount += noisePerStep;
    }
}
