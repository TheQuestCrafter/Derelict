using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Detects when the player presses the Interact button while looking at an IInteractive 
/// and then calls that IInteractive's InteractWith method.
/// </summary>
public class InteractWithLookedAt : MonoBehaviour
{
    [SerializeField]
    private DetectLookedAtInteractive detectLookedAtInteractive;

    void Update()
    {
        if (Input.GetButtonDown("Interact") && detectLookedAtInteractive != null)
        {
            detectLookedAtInteractive.LookedAtInteractive.InteractWith();
        }
    }
}
