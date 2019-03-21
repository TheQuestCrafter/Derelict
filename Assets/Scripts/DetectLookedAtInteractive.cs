using System;
using System.Collections;
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

    /// <summary>
    /// Event raised when the player looks at a different IInteractive
    /// </summary>
    public static event Action<IInteractive> LookedAtInteractiveChanged;

    public IInteractive LookedAtInteractive
    {
        get { return lookedAtInteractive; }
        private set
        {
            bool isInteractiveChanged = value != lookedAtInteractive;
            if (isInteractiveChanged)
            {
                lookedAtInteractive = value;
                LookedAtInteractiveChanged?.Invoke(lookedAtInteractive);
            }
        }
    }

    private IInteractive lookedAtInteractive;

    void FixedUpdate()
    {
        LookedAtInteractive = GetLookedAtInteractive();
    }

    /// <summary>
    /// Raycasts forward from camera to look for IInteractives.
    /// </summary>
    /// <returns>The first IInteractive detected, or null if none are found.</returns>
    private IInteractive GetLookedAtInteractive()
    {
        RaycastHit hitInfo;
        bool objectedDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxDetectionRange);
        IInteractive interactive = null;
        LookedAtInteractive = interactive;
        if (objectedDetected)
        {
            interactive = hitInfo.collider.gameObject.GetComponent<IInteractive>();
        }
        return interactive;
    }
}
