using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
    // TODO: Add long description field
    // TODO: Add Icon Field

    [Tooltip("The text that will display in the UI when the player looks at it in the menu.")]
    [SerializeField]
    private string objectName = nameof(InventoryObject);
    
    private Renderer objRenderer;
    private Collider objCollider;

    private void Start()
    {
        objCollider = this.GetComponent<Collider>();
        objRenderer = this.GetComponent<Renderer>();
    }

    public InventoryObject()
    {
        displayText = $"Take {objectName}";
    }
    /// <summary>
    /// When the player interacts with the object it needs to do two things.
    /// 1. Add inventory object to the player inventory script
    /// 2. Remove the object from the game world
    /// </summary>
    public override void InteractWith()
    {
        base.InteractWith();
        PlayerInventory.InventoryObjects.Add(this);
        objCollider.enabled = false;
        objRenderer.enabled = false;        
    }
}
