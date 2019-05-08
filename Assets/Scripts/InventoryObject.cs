using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
    [Tooltip("Description text for each item in the inventory.")]
    [SerializeField]
    [TextArea(2,8)]
    private string description;

    [Tooltip("Icon displayed in the menu to give a representation of the object.")]
    [SerializeField]
    private Sprite icon;

    [Tooltip("The text that will display in the UI when the player looks at it in the menu.")]
    [SerializeField]
    private string objectName = nameof(InventoryObject);

    [Tooltip("When you pick up the object, should it disappear?")]
    [SerializeField]
    private bool doesDisappear = true;

    public Sprite Icon => icon;
    public string ObjectName => objectName;
    public string Description => description;
    private bool alreadyInteractedWith = false;
    
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
        
        if (!alreadyInteractedWith)
        {
            PlayerInventory.InventoryObjects.Add(this);
            InventoryMenu.Instance.AddItemToMenu(this);
        }
        if (doesDisappear)
        {
            objCollider.enabled = false;
            objRenderer.enabled = false;
        }
        alreadyInteractedWith = true;
    }
}
