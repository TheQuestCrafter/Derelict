using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    [Tooltip("Check this box to lock the door.")]
    [SerializeField]
    private bool isLocked = false;

    [Tooltip("Text that is displayed when interacted with and the door is locked.")]
    [SerializeField]
    private string lockedDoorText = "Locked";

    [Tooltip("Text that is displayed when interacted with and the door is unlocked.")]
    [SerializeField]
    private string unlockedDoorText = "Opened Door";

    [Tooltip("Audioclip for locked door.")]
    [SerializeField]
    private AudioClip lockedDoorSound;

    [Tooltip("Audioclip for unlocked door.")]
    [SerializeField]
    private AudioClip unlockedDoorSound;

    private Animator animator;
    private bool open = false;
    private int shouldOpenAnimParameter = Animator.StringToHash("shouldOpen");
    
    /// <summary>
    /// Using a constructor to initialize displayText in the editor
    /// </summary>
    public Door()
    {
        displayText = nameof(Door);
    }

    public override void InteractWith()
    {
        if (!isLocked)
        {
            audioSource.clip = unlockedDoorSound;
            itemInteractText = unlockedDoorText;
            animator.SetBool(shouldOpenAnimParameter, !open);
            open = !open;
        }
        else
        {
            audioSource.clip = lockedDoorSound;
            itemInteractText = lockedDoorText;
        }
        base.InteractWith(); //Plays sound effect
    }

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }
}
