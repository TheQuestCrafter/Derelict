using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class InteractiveObject : MonoBehaviour, IInteractive
{
    [Tooltip("Text of the object, generally the name.")]
    [SerializeField]
    protected private string initialText = nameof(InteractiveObject);

    [SerializeField]
    protected private string displayText = nameof(InteractiveObject);

    [Tooltip("Description of the object that is interacted with, when clicked will display this text.")]
    [SerializeField]
    protected private string itemInteractText;

    [Tooltip("Text displayed on interaction when enabled by the player interacting with a different object.")]
    [SerializeField]
    protected private string hiddenDataText;

    [SerializeField]
    protected private InteractiveObject itemWithHidden;

    [SerializeField]
    protected private bool usesHiddenObject;

    public string DisplayText => displayText;
    public string InitalText => initialText;
    public string ItemInteractText => itemInteractText;
    protected AudioSource audioSource;
    private bool powered = false;

    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        ResetDisplayText();
    }

    public virtual void InteractWith()
    {
        try
        {
            audioSource.Play();
        }
        catch (System.Exception)
        {
            throw new System.Exception("Missing Audiosource");
        }

        if (usesHiddenObject)
        {
            itemWithHidden.ShowHasHiddenData();
        }
        powered = true;
        UpdateDisplayText();
    }

    protected void UpdateDisplayText()
    {
        displayText = itemInteractText;
    }

    public void ResetDisplayText()
    {
        displayText = initialText;
    }

    public void ShowHasHiddenData()
    {
        itemInteractText = hiddenDataText;
    }

    public bool checkPowered()
    {
        return powered;
    }
}
