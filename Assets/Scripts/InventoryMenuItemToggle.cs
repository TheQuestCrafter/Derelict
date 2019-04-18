using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuItemToggle : MonoBehaviour
{
    [Tooltip("Image component associated with the object that appears in menu.")]
    [SerializeField]
    private Image iconImage;

    public static event Action<InventoryObject> InventoryMenuItemSelected;

    private InventoryObject associatedInventoryObject;

    public InventoryObject AssociatedInventoryObject
    {
        get { return associatedInventoryObject; }
        set
        {
            associatedInventoryObject = value;
            iconImage.sprite = associatedInventoryObject.Icon;
        }
    }

    /// <summary>
    /// Called whenever the toggle is clicked. Connected to the OnValueChanged in the editor.
    /// </summary>
    public void InventoryMenuItemToggled(bool isOn)
    {
        if (isOn)
            InventoryMenuItemSelected?.Invoke(associatedInventoryObject);
    }

    private void Awake()
    {
        Toggle toggle = GetComponent<Toggle>();
        ToggleGroup toggleGroup = GetComponentInParent<ToggleGroup>();
        toggle.group = toggleGroup;
    }
}
