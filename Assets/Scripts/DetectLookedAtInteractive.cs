﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects interactive elements that the player is looking at.
/// </summary>

public class DetectLookedAtInteractive : MonoBehaviour
{
    [Tooltip("Starting point of raycast used to detect interactives.")]
    [SerializeField]
    private Transform raycastOrigin;

    [Tooltip("How far from the raycast origin that we will search for interactive elements.")]
    [SerializeField]
    private float maxDetectionRange = 5.0f;

    void FixedUpdate()
    {
        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxDetectionRange, Color.red);

        RaycastHit hitInfo;

        bool objectedDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxDetectionRange);

       

        if (objectedDetected)
        {
            Debug.Log($"Player is looking at: {hitInfo.collider.gameObject.name}");
        }
    }
}
