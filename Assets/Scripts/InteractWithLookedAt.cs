using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects when the player presses the Interact button while looking at an IInteractive 
/// and then calls that IInteractive's InteractWith method.
/// </summary>
public class InteractWithLookedAt : MonoBehaviour
{
    [Tooltip("Time that it takes for the interacted text to disappear and return to default.")]
    [SerializeField]
    private float timer = 3;

    private IInteractive lookedAtInteractive;
    private float timeAtEnd;
    private bool timerActive = false;

    void Update()
    {
        if (Input.GetButtonDown("Interact") && lookedAtInteractive != null)
        {
            lookedAtInteractive.InteractWith();
            timeAtEnd = Time.time;
            timerActive = true;
        }
        if(timerActive && timeAtEnd + timer <= Time.time)
        {
            lookedAtInteractive?.ResetDisplayText();
            timerActive = false;
        }
    }

    /// <summary>
    /// Event handler for DetectLookedAtInteractive.LookedAtInteractiveChanged
    /// </summary>
    /// <param name="newLookedAtInteractive"></param>
    private void OnLookedAtInteractiveChanged(IInteractive newLookedAtInteractive)
    {
        lookedAtInteractive = newLookedAtInteractive;
    }

    #region Event Subscription / Unsubscription
    private void OnEnable()
    {
        DetectLookedAtInteractive.LookedAtInteractiveChanged += OnLookedAtInteractiveChanged;
    }

    private void OnDisable()
    {
        DetectLookedAtInteractive.LookedAtInteractiveChanged -= OnLookedAtInteractiveChanged;
    }
    #endregion
}
