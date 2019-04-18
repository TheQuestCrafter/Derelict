using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.5f;
    [SerializeField]
    private float sensitivityX = 3f;
    [SerializeField]
    private float sensitivityY = 2f;
    [SerializeField]
    CharacterController player;
    [SerializeField]
    private GameObject camera;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float jumpHeight = 2f;

    private Animator animator;

    private bool playerLocked = false;
    
    private float moveFrontBack;
    private float moveLeftRight;

    private float rotationX;
    private float rotationY;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        GetInput();
        Movement();
    }

    void FixedUpdate()
    {
        Jump();
        Crouch();
    }

    private void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("Crouched", true);
        }
        else
        {
            animator.SetBool("Crouched", false);
        }
    }
    
    public void SetLockPlayer(bool locked)
    {
        playerLocked = locked;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(0, jumpHeight, 0);
        }
    }

    private void Movement()
    {
        Vector3 movement = new Vector3(moveLeftRight, rb.velocity.y, moveFrontBack);
        RotationHandling();
        movement = transform.rotation * movement;
        player.Move(movement * Time.deltaTime);
    }

    private void RotationHandling()
    {
        if (playerLocked == false)
        {
            transform.Rotate(0, rotationX, 0);
            camera.transform.localRotation = Quaternion.Euler(rotationY, 0, 0);
        }
    }

    private void GetInput()
    {
        moveFrontBack = Input.GetAxis("Vertical") * speed;
        moveLeftRight = Input.GetAxis("Horizontal") * speed;
        rotationX = Input.GetAxis("Mouse X") * sensitivityX;
        rotationY -= Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, -60f, 60f);
    }
}
