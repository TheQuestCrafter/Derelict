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

    public string DisplayText => displayText;
    public string InitalText => initialText;
    public string ItemInteractText => itemInteractText;
    private AudioSource audioSource;

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
        displayText = itemInteractText;
    }

    public void ResetDisplayText()
    {
        displayText = initialText;
    }
}
