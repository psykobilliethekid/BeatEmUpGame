﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public float power = 0.2f;
    public float duration = 0.2f;
    public float slowDownAmount = 1f;
    private bool shouldShake;
    private float initialDuration;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.localPosition;
        initialDuration = duration;
    }

    
    void Update()
    {
        Shake();
    }

    void Shake()
    {
        // Decide if the camera should shake
        if(shouldShake)
        {
            if(duration > 0f)
            {
                transform.localPosition = startPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            } else
            {
                shouldShake = false;
                duration = initialDuration;
                transform.localPosition = startPosition;
            }
        }
    }


    // Creating Camera Shake accessors
    public bool ShouldShake
    {
        get
        {
            return shouldShake;
        }

        set
        {
            shouldShake = value;
        }
    }

} // class
