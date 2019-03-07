using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class InteractiveObject : MonoBehaviour, IInteractive
{
    [SerializeField]
    private string initialText = nameof(InteractiveObject);
    [SerializeField]
    private string displayText = nameof(InteractiveObject);
    [SerializeField]
    private string itemInteractText;
    public string DisplayText { get { return displayText; } }

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        ResetDisplayText();
    }
    public void InteractWith()
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
