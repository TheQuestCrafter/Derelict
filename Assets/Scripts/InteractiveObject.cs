using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour, IInteractive
{
    [SerializeField]
    private string initialText = nameof(InteractiveObject);
    [SerializeField]
    private string displayText = nameof(InteractiveObject);
    [SerializeField]
    private string itemInteractText;
    public string DisplayText { get { return displayText; } }

    void Awake()
    {
        ResetDisplayText();
    }
    public void InteractWith()
    {
        displayText = itemInteractText;
    }
    public void ResetDisplayText()
    {
        displayText = initialText;
    }
}
