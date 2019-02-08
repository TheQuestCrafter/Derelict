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

    private float moveFrontBack;
    private float moveLeftRight;

    private float rotationX;
    private float rotationY;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Movement();
    }

    void FixedUpdate()
    {
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space));
        {
            Debug.Log("Jump");
            rb.AddForce(0, jumpHeight, 0);
        }
    }

    private void Movement()
    {
        Vector3 movement = new Vector3(moveLeftRight, rb.velocity.y, moveFrontBack);
        transform.Rotate(0, rotationX, 0);
        camera.transform.localRotation = Quaternion.Euler(rotationY, 0, 0);
        movement = transform.rotation * movement;
        player.Move(movement * Time.deltaTime);
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
