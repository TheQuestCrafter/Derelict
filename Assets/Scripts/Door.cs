using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    [Tooltip("Text that is displayed when interacted with and the door is locked.")]
    [SerializeField]
    private string lockedDoorText = "Locked";

    [Tooltip("Text that is displayed when interacted with and the door is unlocked.")]
    [SerializeField]
    private string openDoorText = "Opened Door";

    [Tooltip("Audioclip for locked door.")]
    [SerializeField]
    private AudioClip lockedDoorSound;

    [Tooltip("Audioclip for unlocked door.")]
    [SerializeField]
    private AudioClip unlockedDoorSound;

    [Tooltip("Audioclip for unpowered door.")]
    [SerializeField]
    private AudioClip unpoweredDoorSound;

    [Tooltip("The inventory object that will open the door if locked. If key is added door will start locked.")]
    [SerializeField]
    private InventoryObject key;

    [Tooltip("Text displayed if door is powered down.")]
    [SerializeField]
    private string poweredDownText;

    [Tooltip("Acts like a key but is activated upon interacting with a different object.")]
    [SerializeField]
    private InteractiveObject dataKey;

    private bool poweredOn = true;
    private bool HasKey => PlayerInventory.InventoryObjects.Contains(key);
    private bool isLocked = false;
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
        if (isLocked && !HasKey && poweredOn)
        {
            audioSource.clip = lockedDoorSound;
            itemInteractText = lockedDoorText;
        }
        else if(poweredOn)
        {
            switch (isLocked)
            {
                case false:
                    itemInteractText = openDoorText;
                    break;

                case true:
                    itemInteractText = $"{key.name} has been used.";
                    isLocked = !isLocked;
                    PlayerInventory.InventoryObjects.Remove(key);
                    break;
            }
            OpenDoor();
        }
        base.InteractWith(); //Plays sound effect
    }

    private void OpenDoor()
    {
        audioSource.clip = unlockedDoorSound;
        animator.SetBool(shouldOpenAnimParameter, !open);
        open = !open;
    }

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        IsLocked();
        IsPowered();
    }

    private void IsPowered()
    {
        if (dataKey != null)
        {
            itemInteractText = poweredDownText;
            poweredOn = false;
        }
    }

    private void IsLocked()
    {
        if (key != null)
        {
            isLocked = true;
        }
    }

    private void FixedUpdate()
    {
        if (!poweredOn)
        {
            poweredOn = dataKey.checkPowered();
        }
    }
}
