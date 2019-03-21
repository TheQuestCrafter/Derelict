using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    private Animator animator;
    private bool open = false;
    private int shouldOpenAnimParameter = Animator.StringToHash("shouldOpen");
    
    /// <summary>
    /// Using a constructor to initialize displayText in the editor
    /// </summary>
    public Door()
    {
        displayText = nameof(Door);
        itemInteractText = nameof(Door);
        initialText = nameof(Door);
    }

    public override void InteractWith()
    {
        base.InteractWith();
        animator.SetBool(shouldOpenAnimParameter, !open);
        open = !open;
    }

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }
}
